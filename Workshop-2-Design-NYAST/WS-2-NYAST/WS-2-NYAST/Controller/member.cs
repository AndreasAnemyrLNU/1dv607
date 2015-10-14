using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{

    class member
    {
        // Region Start :: Dependenies
        private View.ConsoleIn cin;
        private View.ConsoleOut cout;
        private View.MenuMember menuMember;
        private Model.Member ModelMember;
        private Model.MemberCatalog MemberCatalog { get; set; }
        // Regions End  :: Dependencies

        /// <summary>
        /// We stop all creating stuff
        /// </summary>
        private bool runWhile { get; set; }

        public member(View.ConsoleIn cin, View.ConsoleOut cout, View.MenuMember menuMember, Model.MemberCatalog memberCatalog)
        {
            this.cin = cin;
            this.cout = cout;
            this.menuMember = menuMember;
            this.MemberCatalog = memberCatalog;
        }

        public Model.Member Create(Model.MemberCatalog memberCatalog)
        {
            // Start Region :: Prepare
            ModelMember = new Model.Member();
            runWhile = true;
            // End   Region :: Prepare
            
            while (runWhile)
            {
                try
                {
                    if (ModelMember.FirstName == null)
                        ModelMember.FirstName = cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsFirstName);
                    if (ModelMember.LastName == null)
                        ModelMember.LastName = cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsLastName);
                    if (ModelMember.PersonalNumber == null)
                        ModelMember.PersonalNumber = cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsSSN);

                    // We now ha a local ModelMember but...
                    // Add Member to MemberCatalog
                    MemberCatalog.AddMember(ModelMember);
                    // Now it's reachable also easily from index...

                    if(cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuMember, "yY"))
                        menuConfig(View.MenuMember.Menu.StateLess, false, true);
                    
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
            // Client canceled. Change State for menu.
            if(cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuMember, "yY"))
                menuConfig(View.MenuMember.Menu.StateLess, false, true);
                        
            //menuConfig(View.MenuMember.Menu.StateLess, false, true);
            //DeleteCurrentMember();
            return null;
        }

        /// <summary>
        /// Different scenarios neede to set new status. This method makes this easy! 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="hasState"></param>
        /// <param name="isActive"></param>
        private void menuConfig(View.MenuMember.Menu state, bool hasState, bool isActive)
        {
            menuMember.State                = state   ;
            // HasState Deprecated!!!
            menuMember.ModelMenu.HasState   = hasState  ;
            menuMember.ModelMenu.IsActive   = isActive  ;
        }  
  
        /// <summary>
        /// Set declared Model.Member class property to null
        /// </summary>
        private void DeleteCurrentMember()
        {
            ModelMember = null;
        }
                                   
        internal void Stateless()
        {
 	        throw new NotImplementedException();
        }
        public Model.Member Update()
        {
            // Start Region :: Prepare
            ModelMember = new Model.Member();
            runWhile = true;
            // End   Region :: Prepare

            while (runWhile)
            {
                try
                {
                    // Ok. Now we wan´t to catch a existing Member to prepare right Member....
                    // Client want to see a member with SSN
                    string SSN = cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    // And here´s Member if exists....
                    ModelMember = MemberCatalog.Read(SSN);
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
                                    ModelMember.FirstName = cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsFirstName);
                                if (cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQMemberPreviousValue, ModelMember.LastName), "yY"))
                                    ModelMember.LastName = cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsLastName);
                                
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

                                if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuMember, "yY"))
                                    menuConfig(View.MenuMember.Menu.StateLess, false, true);

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
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuMember, "yY"))
                        menuConfig(View.MenuMember.Menu.StateLess, false, true);

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
                    if (cin.boolResponseOfQuestion(View.ConsoleIn.FAQGTakeMeToMenuMember, "yY"))
                        menuConfig(View.MenuMember.Menu.StateLess, false, true);

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
            menuMember.ModelMenu.IsActive = false;
            menuMember.ModelMenu.HasState = false;
        }





        
    }
}
