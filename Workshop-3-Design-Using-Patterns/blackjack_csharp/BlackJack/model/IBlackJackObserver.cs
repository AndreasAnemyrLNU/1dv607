using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IBlackJackObserver
    {
        void GetCardSlower(IEnumerable<model.Card> a_hand, int a_score);
    }
}
