using System;
using System.Collections.Generic;
using System.Text;

namespace testCsharp.Model.EventsInterface
{
    public class PlayerEventArgs : EventArgs
    {
        public string PlayerName { get; set; }
        public uint? HandPoints { get; set; }

        public PlayerEventArgs(string playerName, uint handPoints)
        {
            PlayerName = playerName;
            HandPoints = handPoints;
        }
        public PlayerEventArgs(string playerName)
        {
            PlayerName = playerName;
            HandPoints = null;
        }
    }

    public interface IEventsPlayer
    {
        event EventHandler<PlayerEventArgs> OnPlayerWin;
        event EventHandler<PlayerEventArgs> OnPlayerLose;
        event EventHandler<PlayerEventArgs> OnPlayerHit;
        event EventHandler<PlayerEventArgs> OnPlayerStay;

        event EventHandler<PlayerEventArgs> OnPlayerRevealHandPoints;
    }
}
