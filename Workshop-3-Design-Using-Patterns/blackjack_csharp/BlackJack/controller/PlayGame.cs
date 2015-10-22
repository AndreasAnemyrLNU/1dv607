using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        private model.Game a_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            this.a_game = a_game;
            this.m_view = a_view;

            a_game.AddSubscriber(this);
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();
            
            m_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            m_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                m_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            switch (m_view.GetInput()) 
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

        public void GetCardSlower(IEnumerable<model.Card> a_hand, int a_score)
        {
            m_view.DisplayYouGotANewCard(a_hand, a_score);
        }
    }
}
