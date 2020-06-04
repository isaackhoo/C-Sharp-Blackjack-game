using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using testCsharp.Model.Decks.Constants;

namespace testCsharp.Model.Decks
{
    public class ActiveDeck : IDeck
    {
        public ObservableCollection<Card> Deck { get; private set; }

        // constructor
        public ActiveDeck()
        {
            Deck = new ObservableCollection<Card>();
        }

        // methods
        public void createDeck(int NumberOfDecks = 1)
        {
            try
            {
                for (int i = 0; i < NumberOfDecks; i++)
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
            Card drawnCard = null;
            try
            {
                // if there are no cards left in the deck, return null
                if (Deck.Count == 0)
                    throw new InvalidOperationException("No cards left to draw");

                // if there are still cards,
                // randomly draw a card

                // create a new random generator with unique seed
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                // randomly get an index to draw from
                int randIndex = rnd.Next(0, Deck.Count);

                // retrieve the card at random index 
                drawnCard = Deck[randIndex];

                // remove card from deck
                Deck.RemoveAt(randIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // return drawn card
            return drawnCard;
        }

        // interface methods
        public int getCount()
        {
            return Deck.Count;
        }
    }
}

