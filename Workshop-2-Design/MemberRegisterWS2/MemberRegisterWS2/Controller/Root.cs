using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class Root
    {
        public View.Menu Menu { get; set; }

        //Constructor
        public Root(View.Menu menu)
        {
            Menu = menu;
        }
        // This is the root controller. doApplication() could be named doInitApp().
        public void doApplication()
        {
            // 1.0 Render Menu for Client
            Menu.Welcome();
        
            // 2.0 Wait for Selection by user
            do
            {
                // 3.0 Find out client´s selection
                switch (Menu.clientDidChoose()) 
                {
                    // This is Req 1
                    case View.Menu.MenuSelection.MemberCreate:            
                        Controller.MemberCreate controller = new Controller.MemberCreate();
                        controller.doMemberCreate();
                    break;
                    // This is Req 2 - Consists of further 2 reqs!
                    //case View.Menu.MenuSelection.MemberReadAll:

                    //break;
                      
                }
            }
            while (Menu.clientDidChoose() != View.Menu.MenuSelection.Quit);
        }
        
    }
}
