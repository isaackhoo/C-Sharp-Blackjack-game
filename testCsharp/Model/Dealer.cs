using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model.Decks;
using testCsharp.Model.EventsInterface;

namespace testCsharp.Model
{
    public class Dealer : Player
    {
        // Constructor
        // ----------
        public Dealer() : base("Dealer")
        {

        }

        public override void determineNextAction()
        {
            if (Hand.Cards.Count <= Settings.initialCardDrawCount)
                return;

            if (Hand.TotalPoints > Settings.BlackJackTarget)
                // dealer hand score exceeds blackjack value, dealer loses
                emitOnPlayerLose();
            else if (Hand.TotalPoints <= Settings.DealerStopDraw)
                // dealer hand score less than dealer stop draw value. keep drawing
                emitOnPlayerNextTurn();
            else if (Hand.TotalPoints > Settings.DealerStopDraw && Hand.TotalPoints <= Settings.BlackJackTarget)
                // dealer hand score more than dealer stop draw value, but less than blackjack value
                emitOnPlayerStay();
        }

        protected override void OnGameEndedHandler(GameEndEventArgs e)
        {
            // do nothing
        }

        public bool shouldDrawCard ()
        {
            if (Hand.TotalPoints > Settings.DealerStopDraw)
                return false;
            return true;
        }
    }
}
