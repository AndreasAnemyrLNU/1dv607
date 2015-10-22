using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game();
            view.IView v = new view.SimpleView(); // new view.SwedishView();
            controller.PlayGame ctrl = new controller.PlayGame(g, v);

            while (ctrl.Play());
        }
    }
}


/*TODO Notes...
 * clone project and analyzed diagrams.
 * It's time to implement the operation Game::Stand using Game_Stand.sequencediagram.... 10:03 2015-10-19
 */