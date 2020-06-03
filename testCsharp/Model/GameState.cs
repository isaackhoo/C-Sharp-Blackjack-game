using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

    // ----------
    // game state static class
    // ----------
    public static class GameState
    {
        // notify variable changes
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        // determines if the game is local or online
        public static GameTypeEnum GameType { get; private set; }

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
        public static List<Player> Players { get; private set; }

        private static int PlayerTurnIndex { get; set; }

        // publishers
        // ----------
        public static event EventHandler<GameStateEventArgs> OnGameEnded = delegate { };

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
            Players = new List<Player>();
            PlayerTurnIndex = 0;
        }
        public static void createGameState()
        {
            createGameState(GameTypeEnum.Local);
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

        // Player methods
        // ----------
        private static void subscribeToPlayerEvents(Player player)
        {
            IEventsPlayer IEPlayer = player;
            IEPlayer.OnPlayerWin += (sender, e) => onPlayerWinHandler(e);
            IEPlayer.OnPlayerLose += (sender, e) => OnPlayerLoseHandler(e);
            IEPlayer.OnPlayerHit += (sender, e) => OnPlayerHithandler(e);
            IEPlayer.OnPlayerStay += (sender, e) => OnPlayerStayHandler(e);
            IEPlayer.OnPlayerRevealHandPoints += (sender, e) => OnPlayerRevealHandPointsHandler(e);
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
        private static void onPlayerWinHandler(PlayerEventArgs e)
        {
            Console.WriteLine($"{e.PlayerName} in onPlayerWinHandler");
        }

        private static void OnPlayerLoseHandler(PlayerEventArgs e)
        {
            Console.WriteLine($"{e.PlayerName} in OnPlayerLoseHandler");
        }

        private static void OnPlayerHithandler(PlayerEventArgs e)
        {
            Console.WriteLine($"{e.PlayerName} in OnPlayerHithandler");
        }

        private static void OnPlayerStayHandler(PlayerEventArgs e)
        {
            Console.WriteLine($"{e.PlayerName} in OnPlayerStayHandler");
        }

        private static void OnPlayerRevealHandPointsHandler(PlayerEventArgs e)
        {
            Console.WriteLine($"{e.PlayerName} in OnPlayerRevealHandPointsHandler");
        }

        // Game play methods
        // ----------
        public static void startGame()
        {
            // get dealer and players to subscribe to game state events
            TableDealer.subscribeToGameStateEvents();
            Players.ForEach(player => player.subscribeToGameStateEvents());

            // create active deck
            ActiveDeck.createDeck(Settings.NumberOfDecks);
            updateActiveDeckCount();
        }

        public static void hitForCurrentPlayer()
        {
            // track the player that took an action
            Guid playerUuid = Guid.Empty;
            Player player = null;

            // draw a random card from active deck
            Card drawnCard = ActiveDeck.drawCard();
            updateActiveDeckCount();

            // get current player
            if (PlayerTurnIndex >= Players.Count)
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

            // record player uuid for event emit
            playerUuid = TableDealer._id;
            // give card to player
            TableDealer.receiveCard(drawnCard); // TO REMOVE
            player.receiveCard(drawnCard);

            // determine next event that may take place after card has been hit
            Console.WriteLine($"User hand points {player.Hand.TotalPoints}");

        }

        public static void endGame()
        {
            try
            {
                ActiveDeckCount = "Nil";
                GameStatus = GameStatusEnum.Ended;
                OnGameEnded(null, new GameStateEventArgs(GameStatus));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}