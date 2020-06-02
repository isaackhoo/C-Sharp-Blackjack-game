using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testCsharp.Model.Decks.Components;
using testCsharp.Model.Decks.Constants;

namespace testCsharp.Model.Decks
{
    public class ActiveDeck : IDeck
    {
        private List<Card> Deck;

        // constructor
        public ActiveDeck ()
        {
            Deck = new List<Card>();
        }

        // methods
        public void createDeck(int NumberOfDecks = 1)
        {
            try
            {
                for (int i = 0; i <NumberOfDecks; i++)
                {
                    CardConstants.cardSuits.ForEach(suitDetails =>
                    {
                        CardConstants.cardTypes.ForEach(cardDetails =>
                        {
                            Card card = new Card(cardDetails, suitDetails);
                            Deck.Add(card);
                        });
                    });                                 
                }
            }
            catch (Exception e) { throw e; }
        }
        public Card drawCard()
        {
            // if there are no cards left in the deck, return null
            if (getCount() == 0)
                return null;
            // if there are still cards,
            // randomly draw a card

            // create a new random generator with unique seed
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            // randomly get an index to draw from
            int randIndex = rnd.Next(0, getCount());

            // retrieve the card at random index 
            Card drawnCard = Deck[randIndex];

            // remove card from deck
            Deck.RemoveAt(randIndex);

            // return drawnc ard
            return drawnCard;
        }

        // interface methods
        public int getCount()
        {
            return Deck.Count;
        }

        //public void displayAllCards()
        //{
        //    Deck.ForEach(card =>
        //    {
        //        Console.WriteLine($"{card._id} - {card.getId()}");
        //    });
        //}
    }
}

