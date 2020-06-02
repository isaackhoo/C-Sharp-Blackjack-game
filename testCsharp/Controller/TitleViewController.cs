using System;
using System.Collections.Generic;
using System.Text;
using testCsharp.Model;

namespace testCsharp.Controller
{
    class TitleViewController
    {

        public TitleViewController() { }

        public void startSinglePlayerGame()
        {
            // create a single player game state
            // this also clears out informaion of any previous game
            GameState.createGameState();

            // create a player object
            Player player = new Player("player 1");

            // add player to game state
            GameState.addPlayer(player);
        }
    }
}
