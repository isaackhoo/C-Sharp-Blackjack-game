using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace testCsharp.Model.Decks
{
    public class DiscardDeck : IDeck
    {
        public ObservableCollection<Card> Deck { get; private set; }

        // constructor
        public DiscardDeck()
        {
            Deck = new ObservableCollection<Card>();
        }

        // methods
        public void addCard(Card card)
        {
            // adds a card to the discard pile
            Deck.Add(card);
        }

        public void discardMultipleCards(List<Card> cards)
        {
            // observable collection doesnt have add range method. add one by one
            cards.ForEach(card => addCard(card));
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
