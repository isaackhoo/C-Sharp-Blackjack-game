using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using testCsharp.Model.Decks;
using testCsharp.Model.EventsInterface;

namespace testCsharp.Model
{

    public class Player : IEventsPlayer, INotifyPropertyChanged
    {
        // notification event
        public event PropertyChangedEventHandler PropertyChanged;

        // player variables
        // ----------
        public Guid _id { get; private set; }
        public string Name { get; private set; }
        public PlayerHand Hand { get; private set; }
        private int _totalGamePoints { get; set; }
        public int TotalGamePoints
        {
            get { return _totalGamePoints; }
            private set { _totalGamePoints = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalGamePoints))); }
        }

        private string _gameWinLoseStatus { get; set; }
        public string GameWinLoseStatus
        {
            get { return _gameWinLoseStatus; }
            private set { _gameWinLoseStatus = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameWinLoseStatus))); }
        }

        // Publisher
        // ----------
        public event EventHandler<PlayerEventArgs> OnPlayerLose = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerNextTurn = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerStay = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerDiscardHand = delegate { };

        // constructor
        // ----------
        public Player(string name)
        {
            _id = Guid.NewGuid();
            Name = name;
            Hand = new PlayerHand();
            TotalGamePoints = 0;
            GameWinLoseStatus = "";
        }

        // destructor
        // ----------
        ~Player()
        {
            // clear all event handlers
            if (OnPlayerLose != null)
                foreach (Delegate d in OnPlayerLose.GetInvocationList())
                    OnPlayerLose -= (EventHandler<PlayerEventArgs>)d;

            if (OnPlayerNextTurn != null)
                foreach (Delegate d in OnPlayerNextTurn.GetInvocationList())
                    OnPlayerNextTurn -= (EventHandler<PlayerEventArgs>)d;

            if (OnPlayerStay != null)
                foreach (Delegate d in OnPlayerStay.GetInvocationList())
                    OnPlayerStay -= (EventHandler<PlayerEventArgs>)d;
        }

        // Event emitters
        // ----------
        protected void emitOnPlayerLose()
        {
            Console.WriteLine($"{Name} emitted lose event");
            OnPlayerLose(this, new PlayerEventArgs(_id));
        }
        protected void emitOnPlayerNextTurn()
        {
            Console.WriteLine($"{Name} emitted next turn event");
            OnPlayerNextTurn(this, new PlayerEventArgs(_id));
        }

        public void emitOnPlayerStay()
        {
            Console.WriteLine($"{Name} emitted stay event");
            OnPlayerStay(this, new PlayerEventArgs(_id));
        }

        private void emitOnPlayerDiscardHand()
        {
            Console.WriteLine($"{Name} emitted discarded hand event");
            OnPlayerDiscardHand(this, new PlayerEventArgs(_id, Hand.Cards.ToList()));
            // reset hand
            Hand.resetHand();
        }

        // subscription handlers
        // ----------
        public void subscribeToGameStateEvents()
        {
            // subscribe to game state events
            GameState.OnGameEnded += (sender, e) => OnGameEndedHandler(e);
        }

        protected virtual void OnGameEndedHandler(GameEndEventArgs e)
        {
            // check for lose condition by exceeding
            if (Hand.TotalPoints > Settings.BlackJackTarget)
            {
                sumTotalGamePoints("lose");
                GameWinLoseStatus = "You Lost!";
            }         
            // check for win by dealer exceeded 
            else if (e.DealerHandScore > Settings.BlackJackTarget)
            {
                sumTotalGamePoints("win");
                GameWinLoseStatus = "You Won!";
            }
            // both dealer and player did not burst
            else
            {
                // hand total points less than or equal to 21

                // check for blackjack win condition
                if (Hand.TotalPoints == Settings.BlackJackTarget
                    && Hand.Cards.Count == Settings.initialCardDrawCount
                    && Hand.TotalPoints > e.DealerHandScore)
                {
                    sumTotalGamePoints("blackjack");
                    GameWinLoseStatus = "BlackJack!";
                }                  
                // check for normal win condition 
                //  - dealer exceeds black jack value
                //  - player points > dealer points
                else if (e.DealerHandScore > Settings.BlackJackTarget
                    || Hand.TotalPoints > e.DealerHandScore)
                {
                    sumTotalGamePoints("win");
                    GameWinLoseStatus = "You Won!";
                }                  
                // check for draw / push condition
                else if (Hand.TotalPoints == e.DealerHandScore)
                {
                    sumTotalGamePoints("push");
                    GameWinLoseStatus = "Its a Draw!";
                }                
                // check for lose condition
                else if (Hand.TotalPoints < e.DealerHandScore)
                {
                    sumTotalGamePoints("lose");
                    GameWinLoseStatus = "You Lost!";
                }
            }
        }

        // Game handlers
        public void receiveCard(Card card)
        {
            Hand.addToHand(card);

            if (Hand.Cards.Count >= Settings.initialCardDrawCount)
                // start to determine next player action only after 2 cards are drawn
                determineNextAction();
        }

        public virtual void determineNextAction()
        {
            // see if player can continue with next turn or hand has exceeded and lost
            if (Hand.TotalPoints > Settings.BlackJackTarget)
            {
                // declare loss when points exceed black jack target value
                emitOnPlayerLose();
            }
            else
            {
                // player is able to continue to his next turn
                emitOnPlayerNextTurn();
            }
        }

        // Game points addition
        // ----------
        private void sumTotalGamePoints(string pointType)
        {
            try
            {
                // adds a stipulated number of points that can be both negative or positive
                if (Settings.PossibleGamePointsTypes.ContainsKey(pointType))
                {
                    // retrieve the point value from possible game point types
                    int gamePointValue = (int)Settings.PossibleGamePointsTypes[pointType];

                    // if the player loses, do not allow points to fall into negative range
                    if (gamePointValue < 0)
                    {
                        // just for clarity. insead of += (negative number) and confuse everyone
                        int absGamePointValue = Math.Abs(gamePointValue);
                        if (TotalGamePoints - absGamePointValue < 0)
                            TotalGamePoints = 0;
                        else
                            TotalGamePoints -= absGamePointValue;
                    }
                    else
                    {
                        TotalGamePoints += gamePointValue; // for all other scenarios, just add the points
                    }
                }
                else
                    throw new ArgumentException("Invalid point type");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        // reset player for next game
        // ---------
        public void reset()
        {
            // reset player hand
            emitOnPlayerDiscardHand();
            // reset non-game related variables
            GameWinLoseStatus = "";
        }
    }
}
