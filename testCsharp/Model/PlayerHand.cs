using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks;

namespace testCsharp.Model
{
    public class PlayerHand
    {
        private List<Card> hand;
        private int totalPoints;

        // constructor
        public PlayerHand()
        {
            hand = new List<Card>();
            totalPoints = 0;
        }

        // method
        public void addToHand(Card card)
        {
            // add card to player's hand
            hand.Add(card);
            // calculate total points in hand
            reevaluteHandTotal();
        }

        private void reevaluteHandTotal()
        {
            int NumberOfAces = 0;
            int acePointDifference = 0;

            // sum value of all cards. Sum alternative value of aces
            totalPoints = 0;
            hand.ForEach(card =>
            {
                if (card.Display != "A")
                    totalPoints += card.Value;
                else
                {
                    NumberOfAces++;
                    totalPoints += card.AlternativeValue;
                    if (acePointDifference == 0)
                        acePointDifference = card.Value - card.AlternativeValue;
                }
            });
            // determine if aces can take a value of 11 instead
            for (int i = 0; i < NumberOfAces; i++)
            {
                if (Settings.blackjackTarget - totalPoints >= acePointDifference)
                    totalPoints += acePointDifference;
            }
        }
    }
}
