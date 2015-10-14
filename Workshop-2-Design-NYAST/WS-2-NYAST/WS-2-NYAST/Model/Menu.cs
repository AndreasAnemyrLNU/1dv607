using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    class Menu
    {
        public enum MainMenu { StateLess, MenuMain, MenuMember, MenuBoat, MenuSave, MenuQuit }

        private static MainMenu state { get; set; }

        public MainMenu State 
        {
            get { return state; }

            set { state = value; } 
        }

        public Menu(bool isActive = false) 
        {
            IsActive = isActive;
        }

        //public static int storedInput { get; set; }

        public bool IsActive { get; set; }

        public bool HasState { get; set; }
    }
}
