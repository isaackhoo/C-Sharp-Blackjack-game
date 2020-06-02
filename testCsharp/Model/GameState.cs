using System;
using System.Collections.Generic;
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
        // determines if the game is local or online
        public static GameTypeEnum GameType { get; private set; }

        // controls the state of the game
        public static GameStatusEnum GameStatus { get; private set; }
        public static ActiveDeck Deck { get; private set; }
        public static DiscardDeck DiscardDeck { get; private set; }
        private static Dealer TableDealer { get; set; }
        public static List<Player> Players { get; private set; }

        private static int PlayerTurnIndex { get; set; }

        // publishers
        // ----------
        public static event EventHandler<GameStateEventArgs> OnGameEnded = delegate { };

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

            // initialize and create deck
            Deck = new ActiveDeck();
            Deck.createDeck(Settings.NumberOfDecks);
            DiscardDeck = new DiscardDeck();

            // initialise actors
            TableDealer = createDealer();
            Players = new List<Player>();
            PlayerTurnIndex = 0;
        }
        public static void createGameState()
        {
            createGameState(GameTypeEnum.Local);
        }

        // Dealer
        // ----------
        private static Dealer createDealer()
        {
            Dealer _dealer = new Dealer();

            // subscribe to dealer events
            IEventsPlayer IEPlayer = _dealer;
            IEPlayer.OnPlayerWin += (sender, e) => onPlayerWinHandler(e);
            IEPlayer.OnPlayerLose += (sender, e) => OnPlayerLoseHandler(e);
            IEPlayer.OnPlayerHit += (sender, e) => OnPlayerHithandler(e);
            IEPlayer.OnPlayerStay += (sender, e) => OnPlayerStayHandler(e);
            IEPlayer.OnPlayerRevealHandPoints += (sender, e) => OnPlayerRevealHandPointsHandler(e);

            return _dealer;
        }

        // Player methods
        // ----------
        public static bool addPlayer(Player player)
        {
            try
            {
                // subscribe to player events
                IEventsPlayer IEPlayer = player;
                IEPlayer.OnPlayerWin += (sender, e) => onPlayerWinHandler(e);
                IEPlayer.OnPlayerLose += (sender, e) => OnPlayerLoseHandler(e);
                IEPlayer.OnPlayerHit += (sender, e) => OnPlayerHithandler(e);
                IEPlayer.OnPlayerStay += (sender, e) => OnPlayerStayHandler(e);
                IEPlayer.OnPlayerRevealHandPoints += (sender, e) => OnPlayerRevealHandPointsHandler(e);

                // adds player to player list
                Players.Add(player);

                return true;
            } catch (Exception ex)
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

        public static void endGame()
        {
            try
            {
                GameStatus = GameStatusEnum.Ended;
                OnGameEnded(null, new GameStateEventArgs(GameStatus));
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void triggerDealerEvents()
        {
            TableDealer.triggerEvents();
        }
    }
}