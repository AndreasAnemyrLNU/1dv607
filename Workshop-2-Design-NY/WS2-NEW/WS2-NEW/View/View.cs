using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    abstract class View : Interface.IClientCommunicate, Interface.IView
    {        
        abstract public void setRequest();

        abstract public string getResponse(); 

        protected void TitleOut(string title)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            // Region Start Title out
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            }

            Console.WriteLine("\n{0}\n",title);
            Console.ResetColor();
            
            Console.WriteLine("========================================");

            Console.Write("\n\n  Oki! what do you wanna do?\n\n\n");

        }
    }
}
