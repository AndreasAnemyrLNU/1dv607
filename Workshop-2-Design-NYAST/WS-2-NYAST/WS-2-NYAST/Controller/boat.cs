using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    class Boat
    {

        // Region Start :: Dependenies
        private View.ConsoleIn cin;
        private View.ConsoleOut cout;
        private View.MenuBoat menuBoat;
        private Model.Boat ModelBoat;
        private Model.MemberCatalog MemberCatalog   { get; set; }
        private Model.BoatCatalog BoatCatalog       {get; set;}
        // Regions End  :: Dependencies

        /// <summary>
        /// We stop all creating stuff
        /// </summary>
        private bool runWhile { get; set; }

        public Boat(View.ConsoleIn cin, View.ConsoleOut cout, View.MenuBoat menuBoat, Model.MemberCatalog memberCatalog, Model.BoatCatalog boatCatalog)
        {
            this.cin = cin;
            this.cout = cout;
            this.menuBoat = menuBoat;
            this.MemberCatalog = memberCatalog;
            this.BoatCatalog = boatCatalog;
        }

        public Model.Member Create(Model.BoatCatalog boatCatalog)
        {
            // Start Region :: Prepare
            ModelBoat = new Model.Boat();
            runWhile = true;
            // End   Region :: Prepare
            
            while (runWhile)
            {
                try
                {
                    // Printa list på val

                    if (ModelBoat.Type == null)
                        cout.Print(View.ConsoleIn.FAQBoatType));
                        ModelBoat.Type  = (Model.Boat.TypeBoat)cin.readKeyToInt();
                    if (ModelBoat.Length == null)
                        ModelBoat.Length = cin.readString(View.ConsoleIn.FAQBoatLength);

                    // We now ha a local ModelBoat but...
                    // Add Boat to BoatCatalog
                    BoatCatalog.AddBoat(ModelBoat);
                    // Now it's reachable also easily from index...

                    if(cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                        menuConfig(View.MenuBoat.Menu.StateLess, false, true);
                    
                    // Exit While. Because we've succeded in creating a new boat.
                    runWhile = false;

                    return ModelBoat;
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    runWhile = cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                }
            }
            // Client canceled. Change State for menu.
            if(cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                menuConfig(View.MenuBoat.Menu.StateLess, false, true);
                        
            return null;
        }

        /// <summary>
        /// Different scenarios neede to set new status. This method makes this easy! 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="hasState"></param>
        /// <param name="isActive"></param>
        private void menuConfig(View.MenuBoat.Menu state, bool hasState, bool isActive)
        {
            menuBoat.State                = state   ;
            // HasState Deprecated!!!
            menuBoat.ModelMenu.HasState   = hasState  ;
            menuBoat.ModelMenu.IsActive   = isActive  ;
        }  
  
        /// <summary>
        /// Set declared Model.Member class property to null
        /// </summary>
        private void DeleteCurrentBoat()
        {
            ModelBoat = null;
        }
                                   
        internal void Stateless()
        {
 	        throw new NotImplementedException();
        }
        
        public List<Model.Boat> Boat Update(Model.Member member)
        {
            // Start Region :: Prepare
            ModelBoat = new Model.Boat();
            runWhile = true;
            // End   Region :: Prepare

            while (runWhile)
            {
                try
                {
                    
                    // And here´s Member if exists....
                    BoatCatalog = BoatCatalog.Read(Model.Member member);
                    // ...Here's what we found :)

                    cout.Print(View.ConsoleIn.FAQMemberWasFoundBySSN);
                    cout.Print(ModelMember.PersonalNumber);
                    cout.Print(ModelMember.FirstName);
                    cout.Print(ModelMember.LastName);

                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQMemberReallyUpdate, "yY"))
                    {
                        while (runWhile)
                        {
                            try
                            {
                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQMemberPreviousValue, ModelMember.FirstName), "yY"))
                                    ModelMember.FirstName = cin.ResponseToAskedQustion(View.MenuBoat.FAQwhatsFirstName);
                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQMemberPreviousValue, ModelMember.LastName), "yY"))
                                    ModelMember.LastName = cin.ResponseToAskedQustion(View.MenuBoat.FAQwhatsLastName);
                                
                                //SSN SECURED! No Dialogue!    
                                ModelMember.PersonalNumber = ModelMember.PersonalNumber;
;

                                // We now ha a local ModelMember updated but....
                                // Also time to update Member in MemberCatalog
                                MemberCatalog.Update(ModelMember);
                                // Now Member has fantastico updated values. Hey!

                                cout.Print(View.ConsoleIn.FAQMemberWasUpdated);
                                cout.Print(ModelMember.PersonalNumber);
                                cout.Print(ModelMember.FirstName);
                                cout.Print(ModelMember.LastName);

                                if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuBoat, "yY"))
                                    menuConfig(View.MenuBoat.Menu.StateLess, false, true);

                                // Exit While. Because we've succeded in creating a new member.
                                runWhile = false;

                                return ModelMember;
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
                        menuConfig(View.MenuBoat.Menu.StateLess, false, true);

                    return null;
                
                }
                catch (Exception e)
                {
                    new View.Error(e);
                    // Ask for continuing if an exception has been throwned in your face ;)
                    runWhile = cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                }
            }
            return ModelMember;
        }
        
        /// <summary>
        /// Fetch Member by SSN. Also let it print from cout in view if you wnat....
        /// </summary>
        /// <param name="coutPrint">Uses cout and print....</param>
        /// <returns></returns>
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
                    runWhile = cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                }
            }

            return ModelMember;

        }


        public void Delete()
        {
            // Start Region :: Prepare
            ModelMember = null;
            runWhile = true;
            // End   Region :: Prepare

            while (runWhile)
            {
                try
                {
                    // Client want to delete a member with SSN
                    string SSN = cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    // And here´s Member if exists....
                    ModelMember = MemberCatalog.Read(SSN);
                    // ...Here's what we found :)

                    // Print Member before delete!
                        cout.Print(ModelMember.PersonalNumber);
                        cout.Print(ModelMember.FirstName);
                        cout.Print(ModelMember.LastName);   
                
                    // Exit While. Because we've succeded in reading a member.
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQMemberReallyDelete, "yY"))
                        MemberCatalog.Delete(ModelMember);
                
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
                    runWhile = cin.boolResponseOfQuestion(View.ConsoleIn.FAQContinueWithY, "yY");
                }
            }
        }

        internal void Save()
        {
 	        throw new NotImplementedException();
        }
        internal void Quit()
        {
            menuBoat.ModelMenu.IsActive = false;
            menuBoat.ModelMenu.HasState = false;
        }      
    }
}

 