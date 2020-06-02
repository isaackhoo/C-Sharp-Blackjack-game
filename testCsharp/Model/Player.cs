using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using testCsharp.Model.EventsInterface;

namespace testCsharp.Model
{

    public class Player : IEventsPlayer
    {
        // constant enum
        // ----------
        private Hashtable PossibleGamePointsTypes = new Hashtable()
        {
            {"blackjack", 15 },
            {"win", 10 },
            {"draw", 0 },
            {"lose", -10 }
        };

        // player variables
        // ----------
        public Guid _id { get; private set; }
        public string Name { get; private set; }
        private PlayerHand Hand { get; set; }
        public uint TotalGamePoints { get; private set; }

        // publisher
        // ----------
        public event EventHandler<PlayerEventArgs> OnPlayerWin = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerLose = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerHit = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerStay = delegate { };

        public event EventHandler<PlayerEventArgs> OnPlayerRevealHandPoints = delegate { };

        // constructor
        // ----------
        public Player(string name)
        {
            _id = Guid.NewGuid();
            Name = name;
            Hand = new PlayerHand();
            TotalGamePoints = 0;

            // subscribe to game state events
            GameState.OnGameEnded += (sender, e) => OnGameStateEndedHandler(e);
        }

        // subscription handlers
        // ----------
        private void OnGameStateEndedHandler(GameStateEventArgs e)
        {
            Console.WriteLine($"Game status {e.GameStatus}");
            // game has ended, and player will emit event to have his hand points revealed
            Console.WriteLine($"{Name} revealing hand points");
        }

        // Game points addition
        // ----------
        private void sumTotalGamePoints(string pointType)
        {
            try
            {
                // adds a stipulated number of points that can be both negative or positive
                if (PossibleGamePointsTypes.ContainsKey(pointType))
                {
                    // retrieve the point value from possible game point types
                    uint gamePointValue = (uint)PossibleGamePointsTypes[pointType];

                    // if the player loses, do not allow points to fall into negative range
                    if (gamePointValue < 0)
                        if (TotalGamePoints - gamePointValue < 0)
                            TotalGamePoints = 0;
                        else
                            TotalGamePoints -= gamePointValue;
                    else
                        TotalGamePoints += gamePointValue; // for all other scenarios, just add the points
                }
                else
                    throw new ArgumentException("Invalid point type");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void triggerEvent()
        {
            OnPlayerWin(this, new PlayerEventArgs(Name));
            OnPlayerLose(this, new PlayerEventArgs(Name));
            OnPlayerHit(this, new PlayerEventArgs(Name));
            OnPlayerStay(this, new PlayerEventArgs(Name));
            OnPlayerRevealHandPoints(this, new PlayerEventArgs(Name));
        }
    }
}
