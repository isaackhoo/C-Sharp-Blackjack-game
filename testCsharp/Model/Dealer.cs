using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks;
using testCsharp.Model.EventsInterface;

namespace testCsharp.Model
{
    public class Dealer : IEventsPlayer
    {
        // Dealer Variables
        // ----------
        public string Name = "Dealer";
        private PlayerHand Hand { get; set; }

        // Publisher
        // ----------
        public event EventHandler<PlayerEventArgs> OnPlayerWin = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerLose = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerHit = delegate { };
        public event EventHandler<PlayerEventArgs> OnPlayerStay = delegate { };

        public event EventHandler<PlayerEventArgs> OnPlayerRevealHandPoints = delegate { };


        // Constructor
        // ----------
        public Dealer()
        {

        }

        public void triggerEvents ()
        {
            OnPlayerWin(this, new PlayerEventArgs(Name));
            OnPlayerLose(this, new PlayerEventArgs(Name));
            OnPlayerHit(this, new PlayerEventArgs(Name));
            OnPlayerStay(this, new PlayerEventArgs(Name));
            OnPlayerRevealHandPoints(this, new PlayerEventArgs(Name));
        }
    }
}
