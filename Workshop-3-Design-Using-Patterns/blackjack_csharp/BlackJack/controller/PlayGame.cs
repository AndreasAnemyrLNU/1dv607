using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch (a_view.GetInput()) 
            {
                case (int)view.commands.Play :
                    a_game.NewGame();
                    break;
                case (int)view.commands.Hit :
                    a_game.Hit();
                    break;          
                case (int)view.commands.Stand :
                    a_game.Stand();
                    break;         
                case (int)view.commands.Quit :
                    return false;        
                default:
                    break;                
            }
            return true;
        }
    }
}
