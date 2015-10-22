using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {

            a_dealer.GetNewCard(true, a_deck);
            a_dealer.GetNewCard(true, a_deck);
            a_dealer.GetNewCard(true, a_deck);

            return true;

            //Removed
            //Card c;
            /*
            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_dealer.DealCard(c);

            c = a_deck.GetCard();
            c.Show(true);
            a_player.DealCard(c);
            return true;
             */
        }
    }
}
