using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using testCsharp.Model.Decks;
using testCsharp.Model.EventsInterface;

namespace testCsharp.Model
{
    // enums
    // ----------
    public enum GameTypeEnum { Local, Online }
    public enum GameStatusEnum { InProgress, Ended };

    // game state event args
    // ----------
    public class GameStateEventArgs : EventArgs
    {
        public GameStatusEnum GameStatus { get; set; }

        public GameStateEventArgs(GameStatusEnum status)
        {
            GameStatus = status;
        }
    }

    public class GameEndEventArgs : EventArgs
    {
        public int DealerHandScore { get; private set; }

        public GameEndEventArgs(int dealerScore)
        {
            DealerHandScore = dealerScore;
        }
    }

    // ----------
    // game state static class
    // ----------
    public static class GameState
    {
        // notify variable changes
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        // determines if the game is local or online
        public static GameTypeEnum GameType { get; private set; }
        private static Visibility _nextGameControlsVisibility;
        public static Visibility NextGameControlsVisibility
        {
            get { return _nextGameControlsVisibility; }
            private set { _nextGameControlsVisibility = value; NotifyStaticPropertyChanged(nameof(NextGameControlsVisibility)); }
        }
        private static Visibility _activeGameControlsVisibility;
        public static Visibility ActiveGameControlsVisibility
        {
            get { return _activeGameControlsVisibility; }
            private set { _activeGameControlsVisibility = value; NotifyStaticPropertyChanged(nameof(ActiveGameControlsVisibility)); }
        }

        // controls the state of the game
        public static GameStatusEnum GameStatus { get; private set; }

        private static ActiveDeck ActiveDeck { get; set; }
        private static string _activeDeckCount;
        public static string ActiveDeckCount
        {
            get { return _activeDeckCount; }
            set { _activeDeckCount = value; NotifyStaticPropertyChanged(nameof(ActiveDeckCount)); }
        }

        private static DiscardDeck DiscardDeck { get; set; }
        private static string _discardDeckCount;
        public static string DiscardDeckCount
        {
            get { return _discardDeckCount; }
            set { _discardDeckCount = value; NotifyStaticPropertyChanged(nameof(DiscardDeckCount)); }
        }
        public static Dealer TableDealer { get; private set; }
        private static Visibility _dealerHandVisibility;
        public static Visibility DealerHandVisibility
        {
            get { return _dealerHandVisibility; }
            private set { _dealerHandVisibility = value; NotifyStaticPropertyChanged(nameof(DealerHandVisibility)); }
        }
        public static List<Player> Players { get; private set; }

        private static int PlayerTurnIndex { get; set; }

        // publishers
        // ----------
        public static event EventHandler<GameEndEventArgs> OnGameEnded = delegate { };

        internal static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (StaticPropertyChanged != null)
                StaticPropertyChanged(null, new PropertyChangedEventArgs(propertyName));
            else
                Console.WriteLine("static property change is null");
        }

        static GameState()
        {
            createGameState();
        }

        // methods
        // ----------
        // create initial game state
        // ----------
        public static void createGameState(GameTypeEnum gameType)
        {
            GameType = gameType;
            GameStatus = GameStatusEnum.InProgress;

            // initialize decks
            ActiveDeck = new ActiveDeck();
            ActiveDeckCount = "0";
            DiscardDeck = new DiscardDeck();
            DiscardDeckCount = "0";

            // initialise actors
            TableDealer = createDealer();
            DealerHandVisibility = Visibility.Hidden;

            NextGameControlsVisibility = Visibility.Hidden;
            ActiveGameControlsVisibility = Visibility.Visible;

            // initialise players list
            Players = new List<Player>();
            PlayerTurnIndex = 0;

            // clear all event delegates
            clearEventDelegates();
        }
        public static void createGameState()
        {
            createGameState(GameTypeEnum.Local);
        }

        public static void startNextGame()
        {
            // take cards from dealer and players and add to discard pile
            TableDealer.reset();
            Players.ForEach(player => player.reset());

            // if active deck has less than shuttle trigger value,
            // reset discard deck and active deck
            if (ActiveDeck.getCount() < Settings.ActiveDeckReshuffleTarget)
            {
                ActiveDeck = new ActiveDeck();
                ActiveDeck.createDeck();
                updateActiveDeckCount();

                DiscardDeck = new DiscardDeck();
                updateDiscardDeckCount();
            }

            // reset game status
            GameStatus = GameStatusEnum.InProgress;
            PlayerTurnIndex = 0;

            // retoggle visibility handlers
            DealerHandVisibility = Visibility.Hidden;

            NextGameControlsVisibility = Visibility.Hidden;
            ActiveGameControlsVisibility = Visibility.Visible;

            // deal initial hand
            dealInititalHand();
        }

        // Events
        // ----------
        private static void clearEventDelegates()
        {
            if (OnGameEnded == null) return;
            foreach (Delegate d in OnGameEnded.GetInvocationList())
                OnGameEnded -= (EventHandler<GameEndEventArgs>)d;
        }

        // Decks
        // ----------
        private static void updateActiveDeckCount()
        {
            ActiveDeckCount = ActiveDeck.getCount().ToString();
        }

        private static void updateDiscardDeckCount()
        {
            DiscardDeckCount = DiscardDeck.getCount().ToString();
        }

        // Dealer
        // ----------
        private static Dealer createDealer()
        {
            Dealer _dealer = new Dealer();

            // subscribe to dealer events
            subscribeToPlayerEvents(_dealer);

            return _dealer;
        }

        public static void toggleDealerHandVisibility()
        {
            DealerHandVisibility = DealerHandVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        public static void toggleGameControlsVisibility()
        {
            NextGameControlsVisibility = NextGameControlsVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
            ActiveGameControlsVisibility = ActiveGameControlsVisibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        // Player methods
        // ----------
        private static void subscribeToPlayerEvents(Player player)
        {
            IEventsPlayer IEPlayer = player;
            IEPlayer.OnPlayerLose += (sender, e) => OnPlayerLoseHandler(e);
            IEPlayer.OnPlayerNextTurn += (sender, e) => onPlayerNextTurnHandler(e);
            IEPlayer.OnPlayerStay += (sender, e) => onPlayerStayHandler(e);
            IEPlayer.OnPlayerDiscardHand += (sender, e) => onPlayerDiscardHandHandler(e);
        }

        public static bool addPlayer(Player player)
        {
            try
            {
                // subscribe to player events
                subscribeToPlayerEvents(player);

                // adds player to player list
                Players.Add(player);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        // Player subscriptions
        // ----------
        private static void OnPlayerLoseHandler(PlayerEventArgs e)
        {
            if (e.Uuid != TableDealer._id)
            {
                // if a player exceeds blackjack value
                // move to next player
                PlayerTurnIndex++;

                // if its dealers turn, check if there are any players left to play against.
                // if not end the game directly
                if (PlayerTurnIndex == Players.Count
                    && Players.Any(player => !player.Hand.hasExceeded())
                    && TableDealer.shouldDrawCard())
                {
                    // there more more players to win against, draw cards if needed
                    hitForCurrentPlayer();
                }
                else
                {
                    endGame();
                }
            }
            else
            {
                // dealer lost by exceeding
                endGame();
            }
        }
        private static void onPlayerNextTurnHandler(PlayerEventArgs e)
        {
            if (e.Uuid == TableDealer._id)
            {
                // check if dealer should still draw a card or end the game
                if (TableDealer.shouldDrawCard())
                    hitForCurrentPlayer();
                else
                    endGame();
            }
            return; // do nothing for normal players
        }

        private static void onPlayerStayHandler(PlayerEventArgs e)
        {
            if (e.Uuid != TableDealer._id)
            {
                // if its a player that called for stay,
                // increment player turn index
                PlayerTurnIndex++;

                // check if index exceeds index of players.
                // if it does, it is the dealers turn to draw
                if (PlayerTurnIndex == Players.Count)
                {
                    if (TableDealer.shouldDrawCard())
                        hitForCurrentPlayer();
                    else
                        TableDealer.emitOnPlayerStay();
                }
            }
            else
            {
                // dealer emit stay event
                // end the game
                endGame();
            }
        }

        private static void onPlayerDiscardHandHandler(PlayerEventArgs e)
        {
            // place discarded cards in discard pile
            DiscardDeck.discardMultipleCards(e.Cards);
            updateDiscardDeckCount();
        }

        // Game play methods
        // ----------
        public static void startNewGame()
        {
            // get dealer and players to subscribe to game state events
            TableDealer.subscribeToGameStateEvents();
            Players.ForEach(player => player.subscribeToGameStateEvents());

            // create active deck
            ActiveDeck.createDeck(Settings.NumberOfDecks);
            updateActiveDeckCount();

            // deal initial hand
            dealInititalHand();
        }

        private static void dealInititalHand()
        {
            // give out 2 cards to dealer
            for (int i = 0; i < Settings.initialCardDrawCount; i++)
            {
                Card card = ActiveDeck.drawCard();
                updateActiveDeckCount();
                TableDealer.receiveCard(card);
            }

            // give out 2 cards to each player
            Players.ForEach(player =>
            {
                for (int i = 0; i < Settings.initialCardDrawCount; i++)
                {
                    Card card = ActiveDeck.drawCard();
                    updateActiveDeckCount();
                    player.receiveCard(card);
                }
            });
        }

        public static void hitForCurrentPlayer()
        {
            // track the player that took an action
            Player player = null;

            // draw a random card from active deck
            Card drawnCard = ActiveDeck.drawCard();
            updateActiveDeckCount();

            // get current player
            if (PlayerTurnIndex == Players.Count)
            {
                // no more players to iterate.
                // its the dealer's turn
                // give dealer the drawn card
                player = TableDealer;
            }
            else
            {
                // give card to player
                // retrieve the player
                player = Players[PlayerTurnIndex];
            }

            // give card to player
            player.receiveCard(drawnCard);
        }

        public static void stayForCurrentPlayer()
        {
            // get player to emit stay event
            Players[PlayerTurnIndex].emitOnPlayerStay();
        }

        public static void endGame()
        {
            try
            {
                GameStatus = GameStatusEnum.Ended;

                // reveal dealer hand
                toggleDealerHandVisibility();

                // change game controls visibility
                toggleGameControlsVisibility();

                // emit game ended event
                OnGameEnded(null, new GameEndEventArgs(TableDealer.Hand.TotalPoints));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}