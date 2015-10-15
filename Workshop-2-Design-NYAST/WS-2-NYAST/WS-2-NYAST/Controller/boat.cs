using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    public class Boat
    {

        // Region Start :: Dependenies
        public View.ConsoleIn cin;
        public View.ConsoleOut cout;
        public View.MenuBoat menuBoat;
        public Model.Boat ModelBoat;
        public Model.Member ModelMember;
        public Model.MemberCatalog MemberCatalog   { get; set; }
        public Model.BoatCatalog BoatCatalog       {get; set;}
        // Regions End  :: Dependencies

        /// <summary>
        /// We stop all creating stuff
        /// </summary>
        public bool runWhile { get; set; }

        public int Counter { get; set; }

        public Boat(View.ConsoleIn cin, View.ConsoleOut cout, View.MenuBoat menuBoat, Model.MemberCatalog memberCatalog, Model.BoatCatalog boatCatalog)
        {
            this.cin = cin;
            this.cout = cout;
            this.menuBoat = menuBoat;
            this.MemberCatalog = memberCatalog;
            this.BoatCatalog = boatCatalog;
        }

        public Model.Boat Create(Model.BoatCatalog boatCatalog)
        {
            Preparing();

            // Start Region :: Prepare
            ModelBoat = new Model.Boat();
            runWhile = true;
            // End   Region :: Prepare
            
            while (runWhile)
            {
                try
                {
                    if (ModelBoat.GroupId == null) 
                    {
                        cout.Print(View.ConsoleIn.FAQBoatAddSSN);
                        ModelBoat.GroupId = cin.readString();
                        if (MemberCatalog.Read(ModelBoat.GroupId) == null)
                        {
                            ModelBoat.GroupId = null;
                            throw new Exception(View.Error.ErroMessageNonExistingMember);
                        }
                    }
         
                    if (ModelBoat.Type == Model.Boat.TypeBoat.StateLess) 
                    {
                        cout.Print(View.ConsoleIn.FAQBoatType);
                        ModelBoat.Type = (Model.Boat.TypeBoat)cin.readKeyToInt() - 1;
                    }
                        
                    if (ModelBoat.Length == 0) 
                    {
                        cout.Print(View.ConsoleIn.FAQBoatLength);
                        ModelBoat.Length = int.Parse(cin.readString());
                    }
                        
                    // We now ha a local ModelBoat but...
                    // Add Boat to BoatCatalog
                    BoatCatalog.Add(ModelBoat);
                    // Now it's reachable also easily from index...

                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY")) 
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.StateLess;
                        runWhile = false;
                    }
                    else 
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.Create;
                        runWhile = true;
                    }
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY"))
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.Create;
                        runWhile = true;
                    }
                    else 
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.StateLess;
                        runWhile = false;
                    }
                }
            }
            //Client canceled. Change State for menu.
            if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY")) 
            {
                menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                menuBoat.ModelMenu.IsActive = true;
                menuBoat.State = View.MenuBoat.Menu.StateLess;
                runWhile = false;
            }
                                   
            return null;
        }

        /// <summary>
        /// Different scenarios neede to set new status. This method makes this easy! 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="hasState"></param>
        /// <param name="isActive"></param>
        public void menuConfig(View.MenuBoat.Menu state, bool hasState, bool isActive)
        {
            menuBoat.State                = state   ;
            menuBoat.ModelMenu.HasState   = hasState  ;
            menuBoat.ModelMenu.IsActive   = isActive  ;
        }  
                                     
        public void Stateless()
        {
 	        throw new NotImplementedException();
        }

        /// <summary>
        /// In the primary boatcatalog there's no id for a boat.
        /// Instead it's a groupid. So it's possible to save
        /// a group with SSN for example a person. But it could be whatever elses
        /// Decoupled classes!
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public void Update()
        {
            // Start Region :: Prepare
            ModelBoat = new Model.Boat();
            runWhile = true;
            // End   Region :: Prepare

            while (runWhile)
            {
                try
                {

                    // Client want to update a boat or more in a boatcatalopg 
                    // In our case we use pers. nr. to ask about one or more bots.
                    string SSN = cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    // And here´s Member if exists....
                    ModelMember = MemberCatalog.Read(SSN);
                    // ...Here's what we found :)

                    // And here´s a BoatCatalog....
                    BoatCatalog = BoatCatalog.Read(ModelMember.PersonalNumber);
                    // ...Here's what we found :)

                    if (BoatCatalog.NrOfBoatsInBoatCatalog() != null || BoatCatalog.NrOfBoatsInBoatCatalog() != 0)
                    {
                        Counter = 1;
                        foreach (Model.Boat boat in BoatCatalog)
                        {
                            cout.Print(string.Format(View.ConsoleIn.FAQBoatBoatsNrToEdit, Counter));
                            cout.Print(string.Format(View.ConsoleIn.FAQBoatBoatsfounByGroup, ModelMember.PersonalNumber));
                            cout.Print(string.Format(View.ConsoleIn.FAQBoatTypeOfBoat, boat.Type));
                            cout.Print(string.Format(View.ConsoleIn.FAQBoatLengthOfBoat, boat.Length));
                        }
                        Counter = 1;
                    }

                    // We need to ask which of the to edit
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQProceedUnlock, "yY"))
                    // Client really want to edit en existing Boat....
                    {                        
                        while (runWhile)
                        {
                            try
                            {
                                cout.Print(View.ConsoleIn.FAQBoatWhichtoEdit);
                                int clientsChoice = cin.readKeyToInt();
                                // Now we can pick up boat from our MemberCatalog inside of this´class
                                ModelBoat = BoatCatalog.Read(clientsChoice);


                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelBoat.GroupId), "yY")) 
                                {
                                    ModelBoat.GroupId = cin.ResponseToAskedQustion(View.ConsoleIn.FAQBoatNewSSN);
                                }
                                
                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelBoat.Type), "yY"))
                                {
                                    cout.Print(View.ConsoleIn.FAQBoatType);
                                    ModelBoat.Type  = (Model.Boat.TypeBoat)cin.readKeyToInt();
                                }

                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelBoat.Length), "yY")) 
                                {
                                    ModelBoat.Length = int.Parse(cin.ResponseToAskedQustion(View.ConsoleIn.FAQBoatLength));
                                }
                                    
                                // Really hope this works. Thatv boat are updated in common Membercatalog
                                // Created in index in init of application...

                                if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                                    menuConfig(View.MenuBoat.Menu.StateLess, false, true);

                                // Exit While. Because we've succeded in updating a existing boat.
                                runWhile = false;

                                return;
                            }
                            catch (Exception e)
                            {
                                new View.Error(e);
                                // Ask for continuing if an exception has been throwned in your face ;)
                                runWhile = cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                            }
                        }
                    }
                    // Client canceled. Change State for menu.
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.StateLess;
                        runWhile = true;
                    }

                    return;
                
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY")) 
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.Update;
                        runWhile = true;
                    }
                    else 
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.StateLess;
                        runWhile = false;
                    }
                }
            }
            return;
        }
        
        public Model.Member Read(bool coutPrint)
        {

            // Start Region :: Prepare
            ModelMember = null;
            runWhile = true;
            // End   Region :: Prepare

            while (runWhile)
            {
                try
                {
                    // Client want to see a member with SSN
                    string SSN = cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    // And here´s Member if exists....
                    ModelMember = MemberCatalog.Read(SSN);
                    // ...Here's what we found :)

                    if (coutPrint) 
                    {
                        cout.Print(ModelMember.PersonalNumber);
                        cout.Print(ModelMember.FirstName);
                        cout.Print(ModelMember.LastName);
                    }
                    
                    // Exit While. Because we've succeded in reading a member.
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                        menuConfig(View.MenuBoat.Menu.StateLess, false, true);

                    runWhile = false;
                    return ModelMember;

                }
                catch
                {
                    new View.Error(View.Error.ErroMessageNonExistingMember);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY"))
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.Read;
                        runWhile = true;
                    }
                    else
                    {
                        menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
                        menuBoat.ModelMenu.IsActive = true;
                        menuBoat.State = View.MenuBoat.Menu.StateLess;
                        runWhile = false;
                    }
                }
            }

            return ModelMember;
        }


        public void Delete()
        {
            Preparing();

            while (runWhile)
            {
                try
                {
                    DeleteMemeberBySSN();

                    // Print Member before delete!
                    ShowBeforeDeleting();   
                
                    // Exit While. Because we've succeded in reading a member.
                        if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQMemberReallyDelete, "yY")) 
                        {
                            MemberCatalog.Delete(ModelMember);
                        }

                        Console.Write("uppdatera båt?");

                    // Print deleted Member as confirm for user

                    cout.Print(View.ConsoleIn.FAQMemberWasDeleted);
                    cout.Print(ModelMember.PersonalNumber);
                    
                    // Exit While. We're done here!
                    runWhile = false;
                    
                }
                catch
                {
                    new View.Error(View.Error.ErroMessageNonExistingMember);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY")) 
                    {
                        DoContinue();            
                    }
                    else 
                    {
                        DoNotContinue(); 
                    }
                }
            }
        }

        public void Preparing()
        {
            // Start Region :: Prepare
            ModelMember = null;
            runWhile = true;
            // End   Region :: Prepare
        }

        public void DeleteMemeberBySSN()
        {
            // Client want to delete a member with SSN
            string SSN = cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
            // And here´s Member if exists....
            ModelMember = MemberCatalog.Read(SSN);
            // ...Here's what we found :)
        }

        public void ShowBeforeDeleting()
        {
            cout.Print(ModelMember.PersonalNumber);
            cout.Print(ModelMember.FirstName);
            cout.Print(ModelMember.LastName);
        }

        public void DoContinue()
        {
            menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
            menuBoat.ModelMenu.IsActive = true;
            menuBoat.State = View.MenuBoat.Menu.Delete;
            runWhile = true;
        }

        public void DoNotContinue()
        {
            menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuBoat;
            menuBoat.ModelMenu.IsActive = true;
            menuBoat.State = View.MenuBoat.Menu.StateLess;
            runWhile = false;
        }

        public void Save()
        {
            if (new WS_2_NYAST.MODEL.ToFileDAL().save(BoatCatalog, MemberCatalog))
            {
                cout.Print("\n\nKatalogerna sparades till fill...\n\n");
                System.Threading.Thread.Sleep(3000);

                menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuMember;
                menuBoat.ModelMenu.IsActive = false;
                menuBoat.State = View.MenuBoat.Menu.StateLess;
            }
        }
     
        public void Quit()
        {
            menuBoat.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
            menuBoat.ModelMenu.IsActive = false;
            menuBoat.State = View.MenuBoat.Menu.StateLess;
        }      
    }
}

 