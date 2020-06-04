using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using testCsharp.Model.Decks;

namespace testCsharp.Model
{
    public class PlayerHand : INotifyPropertyChanged
    {
        public ObservableCollection<Card> Cards { get; private set; }
        private int _totalPoints { get; set; }
        public int TotalPoints
        {
            get { return _totalPoints; }
            private set { _totalPoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPoints))); }
        }

        // notification event
        public event PropertyChangedEventHandler PropertyChanged;

        // constructor
        public PlayerHand()
        {
            Cards = new ObservableCollection<Card>();
            TotalPoints = 0;
        }

        // method
        public void addToHand(Card card)
        {
            //if (FirstCard == null)
            //    // self explainatory
            //    FirstCard = card;
            //else
            // add card to player's hand
            Cards.Add(card);

            // calculate total points in hand
            reevaluteHandTotal();
        }

        private void reevaluteHandTotal()
        {
            int NumberOfAces = 0;
            int acePointDifference = 0;

            // sum value of all cards. Sum alternative value of aces
            TotalPoints = 0;
            foreach (Card card in Cards)
            {
                if (card.Display != "A")
                    TotalPoints += card.Value;
                else
                {
                    NumberOfAces++;
                    TotalPoints += card.AlternativeValue;
                    if (acePointDifference == 0)
                        acePointDifference = card.Value - card.AlternativeValue;
                }
            };
            // determine if aces can take a value of 11 instead
            for (int i = 0; i < NumberOfAces; i++)
            {
                if (Settings.BlackJackTarget - TotalPoints >= acePointDifference)
                    TotalPoints += acePointDifference;
            }
        }

        public bool hasExceeded()
        {
            if (TotalPoints > Settings.BlackJackTarget)
                return true;
            return false;
        }

        // reset
        public void resetHand()
        {
            Cards.Clear();
            TotalPoints = 0;
        }
    }
}
