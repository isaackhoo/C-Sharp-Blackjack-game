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
        private Card _firstCard;
        public Card FirstCard { 
            get { return _firstCard;  } 
            private set { _firstCard = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstCard))); } 
        }
        public ObservableCollection<Card> HandWithoutFirstCard { get; private set; }
        private int _totalPoints; 
        public int TotalPoints {
            get { return _totalPoints; }
            private set { _totalPoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPoints))); }
        }

        // notification event
        public event PropertyChangedEventHandler PropertyChanged;

        // constructor
        public PlayerHand()
        {
            FirstCard = null;
            HandWithoutFirstCard = new ObservableCollection<Card>();
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
                HandWithoutFirstCard.Add(card);

            // calculate total points in hand
            reevaluteHandTotal();
        }

        private void reevaluteHandTotal()
        {
            int NumberOfAces = 0;
            int acePointDifference = 0;

            List<Card> temp = new List<Card>(HandWithoutFirstCard);
            if (FirstCard != null)
                temp.Add(FirstCard);

            // sum value of all cards. Sum alternative value of aces
            TotalPoints = 0;
            temp.ForEach(card =>
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
            });
            // determine if aces can take a value of 11 instead
            for (int i = 0; i < NumberOfAces; i++)
            {
                if (Settings.BlackJackTarget - TotalPoints >= acePointDifference)
                    TotalPoints += acePointDifference;
            }
        }
    }
}
