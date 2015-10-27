using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    public class Menu
    {


        public enum MainMenu { StateLess, MenuMain, MenuMember, MenuQuit, MenuBoat}

        private static MainMenu state { get; set; }

        public bool IsActive { get; set; }

        public MainMenu State 
        {
            get { return state; }

            set { state = value; } 
        }

        public Menu(bool isActive = false) 
        {
            IsActive = isActive;
        }
    }
}
