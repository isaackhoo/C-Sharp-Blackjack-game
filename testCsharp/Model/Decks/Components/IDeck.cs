using System;
using System.Collections.Generic;
using System.Text;

namespace testCsharp.Model.Decks.Components
{
    public interface IDeck
    {
        // returns the current number of cards in the deck
        int getCount();
    }
}
