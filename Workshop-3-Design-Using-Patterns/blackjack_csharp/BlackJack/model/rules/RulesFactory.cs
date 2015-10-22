using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public IHitStrategy Get17Rule() 
        {
            return new Soft17Strategy();
        }

        public IWinnerStrategy GetWinnerStrategy() 
        {
            if (true) 
            {
                return new EasierToWinForDealer();
            }
            else 
            {
                return new HarderToWinForDealer();
            }
        }

    }
}
