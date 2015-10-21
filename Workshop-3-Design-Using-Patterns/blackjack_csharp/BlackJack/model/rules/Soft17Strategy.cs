using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17Strategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            
            var cards = a_dealer.GetHand();

            // Check if limit has reached....
            if (a_dealer.CalcScore() == g_hitLimit) 
            {
                foreach (var card in cards)
                {
                    // Must hit if ace in hand. Because score IS 17! 
                    //Ace turns into 1 score instead
                    if (card.GetValue() == Card.Value.Ace)
                    {
                        return true;
                    }
                }
            }

            // No special circumstances....
            if (a_dealer.CalcScore() < g_hitLimit)
                return true;
                    
            return false;            
        }
    }
}
