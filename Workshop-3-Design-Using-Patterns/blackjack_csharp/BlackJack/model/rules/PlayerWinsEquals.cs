using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsEquals  : IWinnerStrategy
    {
        public bool calcWinner(Player dealer, Player player, int maxScore)
        {
            if (player.CalcScore() > maxScore)
            {
                return true;
            }
            else if (dealer.CalcScore() > maxScore)
            {
                return false;
            }
            return !(dealer.CalcScore() >= player.CalcScore());
        }
    }
}
