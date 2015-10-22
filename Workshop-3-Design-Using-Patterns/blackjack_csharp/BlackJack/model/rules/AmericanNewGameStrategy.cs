using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            Card c;

            a_player.GetNewCard(true, a_deck);
            a_player.GetNewCard(true, a_deck);
            a_player.GetNewCard(true, a_deck);
            a_player.GetNewCard(false, a_deck);



            /* This is DRY and duolicated code. 
             * GetNewCard Method added in class Player instead! 
             * 
            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_dealer.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);

            c = a_deck.GetCard();
            c.Show(false);
            a_dealer.DealCard(c);

             */
             
            return true;
        }
    }
}
