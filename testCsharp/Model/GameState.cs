using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks;

namespace testCsharp.Model
{
    public static class GameState
    {
        // determines if the game is local or online
        public static string gameType { get; set; }

        // controls the state of the game
        public static ActiveDeck deck { get; private set; }
        public static DiscardDeck discardDeck { get; private set; }
        public static List<Player> players { get; private set; }


    }
}