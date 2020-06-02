using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks.Components;

namespace testCsharp.Model.Decks
{
    public class DiscardDeck : IDeck
    {
        private List<Card> Deck;

        // constructor
        public DiscardDeck()
        {
            Deck = new List<Card>();
        }

        // methods
        public void addCard(Card card)
        {
            // adds a card to the discard pile
            Deck.Add(card);
        }

        public List<Card> clearDiscardPile()
        {
            // returns all cards in the discard pile

            // hold all the card references in a separate list as the original will be emptied
            List<Card> discardPile = new List<Card>();
            discardPile.AddRange(Deck);
            // empty out the deck
            Deck.Clear();
            // return temp list of cards
            return discardPile;
        }

        // interface methods
        public int getCount()
        {
            return Deck.Count;
        }
    }
}
