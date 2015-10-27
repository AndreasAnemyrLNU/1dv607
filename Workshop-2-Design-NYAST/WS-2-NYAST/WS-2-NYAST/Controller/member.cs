using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    public class Member : Index
    {
        public Member(Controller.Index index)
            : base(index) { /* Empty */}

        private Model.Member ModelMember;
        private bool runWhile;

        public Model.Member Create()
        {
            Prepare();

            while (runWhile)
            {
                try
                {
                    if (ModelMember.FirstName == null)
                        ModelMember.FirstName = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsFirstName);
                    if (ModelMember.LastName == null)
                        ModelMember.LastName = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsLastName);
                    if (ModelMember.PersonalNumber == null)
                        ModelMember.PersonalNumber = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsSSN);
                    if (ModelMember.BoatCatalog == null)
                        ModelMember.BoatCatalog = new Model.BoatCatalog();

                    Controller.Boat controllerBoat = new Controller.Boat(this);

                    do
                    {
                        ModelMember.BoatCatalog.Add(controllerBoat.Create());
                    } while (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQBoatAddMoreBoats, "yY"));

                    Cout.Print(View.ConsoleIn.FAQMemberWasCreated);
                    ShowCurrentMember();
                }
                catch (Exception e)
                {
                    ShowError(e.Message);
                }
                ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQMemberContinueCreating);
            }
            return ModelMember;
        }

        public Model.Member Read()
        {
            Prepare();

            while (runWhile)
            {
                try
                {
                    string SSN = Cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    ModelMember = MemberCatalog.Read(SSN);

                    if (Cin.boolResponseOfQuestion("(y) Look a specific member's information", "yY")) 
                    {
                        new View.Listing().ShowMember(ModelMember, Cout, Cin);
                    }
                                                      
                    ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQMemberContinueReading);
                
                }
                catch
                {
                    new View.Error(View.Error.ErroMessageNonExistingMember);
                    ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQMemberContinueReading);
                }
            }
            return ModelMember;
        }

        public Model.Member Update()
        {
            Prepare();

            while (runWhile)
            {
                try
                {
                    string SSN = Cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    ModelMember = MemberCatalog.Read(SSN);

                    if (ModelMember != null) 
                    {
                        if (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQMemberReallyUpdate, "yY"))
                        {
                            while (runWhile)
                            {
                                try
                                {
                                    if (Cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelMember.FirstName), "yY"))
                                        ModelMember.FirstName = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsFirstName);
                                    if (Cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelMember.LastName), "yY"))
                                        ModelMember.LastName = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsLastName);
                                    if (Cin.boolResponseOfQuestion(string.Format(View.ConsoleIn.FAQPreviousValue, ModelMember.PersonalNumber), "yY"))
                                        ModelMember.LastName = Cin.ResponseToAskedQustion(View.MenuMember.FAQwhatsSSN);

                                    MemberCatalog.Update(ModelMember);
                                    Cout.Print(View.ConsoleIn.FAQMemberWasUpdated);
                                    ShowCurrentMember();

                                    Controller.Boat controllerBoat = new Controller.Boat(this);
                                    controllerBoat.Update(ModelMember.BoatCatalog);

                                   

                                    break;
                                }
                                catch (Exception e)
                                {
                                    ShowError(e.Message);
                                    ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQContinueWithY);
                                }
                            }
                        }
                    }
                    else
                    {
                        Cout.Print(View.ConsoleIn.FAQMemberWasNotFoundBySSN);
                    }
                }
                catch (Exception e)
                {
                    ShowError(e.Message);
                }
                ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQMemberContinueUpdating);
            }
            return ModelMember;
        }

        public void Delete()
        {
            Prepare();

            while (runWhile)
            {
                try
                {
                    string SSN = Cin.ResponseToAskedQustion(View.ConsoleIn.FAQwhatsSSN);
                    ModelMember = MemberCatalog.Read(SSN);

                    ShowCurrentMember();
                  
                    if (Cin.boolResponseOfQuestion(View.ConsoleIn.FAQMemberReallyDelete, "yY")) 
                    {
                        MemberCatalog.Delete(ModelMember);
                        Cout.Print(View.ConsoleIn.FAQMemberWasDeleted);
                        ShowCurrentMember();                        
                    }
                }
                catch
                {
                    new View.Error(View.Error.ErroMessageNonExistingMember);
                }
                ClientCanCancelProcessAndGoBackToMenuMember(View.ConsoleIn.FAQMemberContinueDeleting);
            }
        }

        private void Prepare()
        {
            ModelMember = new Model.Member();
            runWhile = true;
        }

        public void Save()
        {
            if (new WS_2_NYAST.MODEL.ToFileDAL().save(MemberCatalog))
            {
                Cout.Print("\n\nKatalogerna sparades till fill...\n\n");
                System.Threading.Thread.Sleep(3000);

                ViewMenuMember.ModelMenu.State = Model.Menu.MainMenu.MenuMember;
                ViewMenuMember.ModelMenu.IsActive = false;
                ViewMenuMember.State = View.MenuMember.Menu.StateLess;
            }
        }

        public void Quit()
        {
            ViewMenuMember.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
            ViewMenuMember.ModelMenu.IsActive = false;
            ViewMenuMember.State = View.MenuMember.Menu.StateLess;
        }

        private void ShowError(string errorMessage)
        {
            new View.Error(errorMessage);
        }

        /// <summary>
        /// If Client not answer y or Y code Returns to MenuMember and runWhile is set to false...
        /// </summary>
        /// <param name="message"></param>
        private void ClientCanCancelProcessAndGoBackToMenuMember(string message)
        {
            if (Cin.boolResponseOfQuestion(message, "yY"))
            {
                runWhile = true;
            }
            else
            {
                ViewMenuMember.ModelMenu.State = Model.Menu.MainMenu.MenuMember;
                ViewMenuMember.State = View.MenuMember.Menu.StateLess;
                runWhile = false;
            }
        }

        private void ShowCurrentMember()
        {
            Cout.Print(ModelMember.PersonalNumber);
            Cout.Print(ModelMember.FirstName);
            Cout.Print(ModelMember.LastName);
        }
    }
}
