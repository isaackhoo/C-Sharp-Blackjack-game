using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace testCsharp.Model
{
    public class SettingsChangedEventArgs : EventArgs
    {
        public string Input { get; private set; }

        public SettingsChangedEventArgs(string input)
        {
            Input = input;
        }

    }

    public static class Settings
    {
        // notify variable changes
        public static event EventHandler<SettingsChangedEventArgs> SettingsStaticPropertyChanged;

        // player settings
        private static string _playerName { get; set; }
        public static string PlayerName
        {
            get { return _playerName; }
            private set { _playerName = value; NotifyStaticPropertyChanged(nameof(PlayerName)); }
        }

        // game settings
        private static int _numberOfDecks { get; set; }
        public static int NumberOfDecks
        {
            get { return _numberOfDecks; }
            private set { _numberOfDecks = value; NotifyStaticPropertyChanged(nameof(NumberOfDecks)); }
        }
        private static int _blackJackTarget { get; set; }
        public static int BlackJackTarget
        {
            get { return _blackJackTarget; }
            private set { _blackJackTarget = value; NotifyStaticPropertyChanged(nameof(BlackJackTarget)); }
        }

        // game play
        public static int initialCardDrawCount { get; private set; }
        public static int BlackJackCardCount { get; private set; }
        public static int DealerStopDraw { get; private set; }

        // game conclusion
        public static Hashtable PossibleGamePointsTypes = new Hashtable()
        {
            { "blackjack", 15 },
            { "win", 10 },
            { "push", 0 },
            { "lose", -10 }
        };
        public static int ActiveDeckReshuffleTarget { get; private set; }

        // Methods
        internal static void NotifyStaticPropertyChanged(string propertyName)
        {
            if (SettingsStaticPropertyChanged != null)
                SettingsStaticPropertyChanged(null, new SettingsChangedEventArgs(propertyName));
            else
                Console.WriteLine("Settings static property change is null");
        }

        public static void updatePlayerName(string name)
        {
            PlayerName = name;
        }

        public static void updateNumberOfDecks(int numberOfDecks)
        {
            // prevent updating with invalid numbers
            if (numberOfDecks >= 1)
                NumberOfDecks = numberOfDecks;
        }
        public static void updateNumberOfDecks(string numberOfDecks)
        {
            // prevents updating with empty strings
            int _nod = NumberOfDecks;

            if (int.TryParse(numberOfDecks, out _nod))
            {
                updateNumberOfDecks(_nod);
            }
        }

        public static void updateBlackjackTarget(int blackjackTarget)
        {
            // prevent updating with invalid numbers
            if (blackjackTarget >= 2)
                BlackJackTarget = blackjackTarget;
        }
        public static void updateBlackjackTarget(string blackjackTarget)
        {
            // prevents updating with empty strings
            int _bjt = BlackJackTarget;

            if (int.TryParse(blackjackTarget, out _bjt))
            {
                updateBlackjackTarget(_bjt);
            }
        }

        // static constructor
        static Settings()
        {
            PlayerName = "Player 1";

            NumberOfDecks = 1;
            BlackJackTarget = 21;


            initialCardDrawCount = 2;
            BlackJackCardCount = 2;
            DealerStopDraw = BlackJackTarget - 5; // 16. This is to cater for different blackjack target values

            ActiveDeckReshuffleTarget = 15;
        }
    }
}
