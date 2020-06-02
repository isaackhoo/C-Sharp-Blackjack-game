using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace testCsharp.Model.Decks
{
    public class Card
    {
        public Guid _id { get; private set; } 
        public string Display { get; private set; }
        public int Value { get; private set; }
        public int AlternativeValue { get; private set; }
        public string Suit { get; private set; }
        public string Color { get; private set; }

        // constructor
        public Card(Hashtable cardDetails, Hashtable cardSuit)
        {
            // create a unique id to identify card easily
            _id = Guid.NewGuid();

            // Value to display
            if (cardDetails["display"] == null)
                throw new ArgumentException("Card display should not be null");
            Display = (string)cardDetails["display"];

            // Card points to use to count
            if (cardDetails["value"] == null)
                throw new ArgumentException("Card value should not be null");
            Value = (int)cardDetails["value"];

            // Alternative card points
            if (cardDetails["alternativeValue"] == null)
                throw new ArgumentException("Card alternativeValue should not be null");
            AlternativeValue = (int)cardDetails["alternativeValue"];

            // Card suit
            if (cardSuit["suit"] == null)
                throw new ArgumentException("Card suit should not be null");
            Suit = (string)cardSuit["suit"];

            // Color of suit
            if (cardSuit["color"] == null)
                throw new ArgumentException("Card color should not be null");
            Color = (string)cardSuit["color"];                 
        }

        // methods
        public string getId()
        {
            // combines card display and suit for easy comparison of cards
            return Display + "_" + Suit;
        }
    }
}
