using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks;

namespace testCsharp.Model.EventsInterface
{
    public class PlayerEventArgs : EventArgs
    {
        public Guid Uuid { get; set; }
        public List<Card> Cards { get; private set; }

        public PlayerEventArgs(Guid uuid, List<Card> cards)
        {
            Uuid = uuid;
            Cards = new List<Card>(cards);
        }
        public PlayerEventArgs(Guid uuid)
        {
            Uuid = uuid;
            Cards = null;
        }
    }

    public interface IEventsPlayer
    {
        event EventHandler<PlayerEventArgs> OnPlayerLose;
        event EventHandler<PlayerEventArgs> OnPlayerNextTurn;
        event EventHandler<PlayerEventArgs> OnPlayerStay;
        event EventHandler<PlayerEventArgs> OnPlayerDiscardHand;
    }
}
