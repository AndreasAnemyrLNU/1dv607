using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{

    public class Boat : Index
    {
        public Boat (Controller.Index index)
            : base(index) { /*empty*/ }
               
        private  Model.Boat boat;
        private bool runWhile { get; set; }

        public Model.Boat Create()
        {
            while(true)
            {
                try
                {
                    boat = new Model.Boat();

                    if (boat.Type == Model.Boat.TypeBoat.StateLess) 
                    {
                        Cout.Print(View.ConsoleIn.FAQBoatType);
                        boat.Type = (Model.Boat.TypeBoat)Cin.readKeyToInt() - 1;
                    }
                        
                    if (boat.Length == 0) 
                    {
                        Cout.Print(View.ConsoleIn.FAQBoatLength);
                        boat.Length = int.Parse(Cin.readString());
                    }
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    if (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY"))
                    {
                        ViewMenuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        ViewMenuBoat.ModelMenu.IsActive = true;
                        ViewMenuBoat.State = View.MenuBoat.Menu.Create;
                    }
                    else 
                    {
                        ViewMenuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        ViewMenuBoat.ModelMenu.IsActive = true;
                        ViewMenuBoat.State = View.MenuBoat.Menu.StateLess;
                    }
                }
                break;
            }
            return boat;
        }


        public void Update(Model.BoatCatalog boatCatalog)
        {
            while (true)
            {
                try
                {
                    boat = new Model.Boat();

                    if (boatCatalog.NrOfBoatsInBoatCatalog() != null || boatCatalog.NrOfBoatsInBoatCatalog() != 0)
                    {
                        int counter = 1;
                        foreach (Model.Boat b in boatCatalog)
                        {
                            Cout.Print(string.Format(View.ConsoleIn.FAQBoatBoatsNrToEdit, counter));
                            Cout.Print(string.Format(View.ConsoleIn.FAQBoatTypeOfBoat, b.Type));
                            Cout.Print(string.Format(View.ConsoleIn.FAQBoatLengthOfBoat, b.Length));
                            counter++;
                        }
                        
                    }
                    // Edit boats
                    if(Cin.boolResponseOfQuestion("(y) Update boats?", "yY"))
                        UpdateMode(boatCatalog);

                    // Delete boats
                    if(Cin.boolResponseOfQuestion("(y) Delete boat(s)?", "yY"))
                        DeleteMode(boatCatalog);
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    break;
                }
                break;
            }
            return;
        }

        private void UpdateMode(Model.BoatCatalog boatCatalog)
        {
            if (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQProceedUnlock, "yY"))
            {
                while (true)
                {
                    try
                    {
                        Cout.Print(View.ConsoleIn.FAQBoatWhichtoEdit);
                        int clientsChoice = -1 + Cin.readKeyToInt();

                        boat = boatCatalog.Read(clientsChoice);

                        if (Cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, boat.Type), "yY"))
                        {
                            Cout.Print(View.ConsoleIn.FAQBoatType);
                            boat.Type = (Model.Boat.TypeBoat)Cin.readKeyToInt();
                        }

                        if (Cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, boat.Length), "yY"))
                        {
                            boat.Length = int.Parse(Cin.ResponseToAskedQustion(View.ConsoleIn.FAQBoatLength));
                        }

                    }
                    catch (Exception e)
                    {
                        new View.Error(e);
                        Cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                        break;
                    }
                    break;
                }
            }
        }

        private void DeleteMode(Model.BoatCatalog boatCatalog)
        {
            if (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQProceedUnlock, "yY"))
            {
                while (true)
                {
                    try
                    {
                        Cout.Print(View.ConsoleIn.FAQBoatWhichtoDelete);
                        int clientsChoice = -1 + Cin.readKeyToInt();

                        boat = boatCatalog.Read(clientsChoice);

                        boatCatalog.delete(boat);

                    }
                    catch (Exception e)
                    {
                        new View.Error(e);
                        Cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                        break;
                    }
                    break;
                }
            }
        }

    }
}

 