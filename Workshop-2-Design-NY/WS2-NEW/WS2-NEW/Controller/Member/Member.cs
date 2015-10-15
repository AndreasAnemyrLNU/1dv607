using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{
    class Member : Menu
    {
        public Member() 
        {
            // Interface cast to appropirate Member
            view = new View.Member();
        }

        // iview is casted directly in DoControl. 
        //Important in all controllers with own methods!
        private View.Member view { get; set; }

        // Useful when working with crudding....
        private Model.Member member { get; set; }

        // Menu for system to use for further interaction with client.
        private void ClientDidChooseAndNowSystemNeedsThisMethodForDecideWhatToPresentNext() 
        {

            ClientResponse = view.getResponse("\n Go to catalog of Members \n Press y (yes)?", true);


            if (view.clientAnsweredYes(ClientResponse))
            {
                SelectedInMenuMember = Model.Cache.menuMember.GoToMenuMemberCatalog;
            }
            else if (view.clientSaidReturn(ClientResponse))
            {
                // Client press enter
                SelectedInMenuMember = Model.Cache.menuMember.Return;
            }
            else
            {
                // returns to menuIndex (startpage)
                SelectedInMenuMember = Model.Cache.menuMember.GoToMenuIndex;
            }
        }

        private void getClientsResponseBeforeCachingThisNewThingUp()
        {
            ClientResponse = view.getResponse("Is this correct? \n\n Press y (yes) \n and than press Enter \n Than it will be cached...\n\n Press n (no) \n and than press Enter \n Than you returns...... ", true);
        }

        // Do not touch SSN if not creating Member for the first time.
        // Memmber's uniqueness is SSN!
        private void MemberCreator(bool firstName, bool lastName, bool SSN)
        {
            if (firstName)
            {
                while (true)
                {
                    try { member.FirstName = view.getResponse("Firstname"); break; }
                    catch (Exception e) { view.errorCrud(e.Message); }
                }
            }

            if (lastName)
            {
                while (true)
                {
                    try { member.LastName = view.getResponse("Lastname"); break; }
                    catch (Exception e) { view.errorCrud(e.Message); }
                }
            }

            if (SSN)
            {

                while (true)
                {
                    try { member.PersonalNumber = view.getResponse("Personal Number 11 chars\n(010203-0405)"); break; }
                    catch (Exception e) { view.errorCrud(e.Message); }
                }
            }
        }

        private Model.Member getMemberBySSN(bool print)
        {
            // Reads from catalog of Members      
            member = Cache.CachedMemberCatalog.Read(ClientResponse);

            // Show Member in console
            if (print) 
            {
                view.consoleWriteMember(member);
            }
            return member;
        }

        private Model.Member DeleteMemberBySSN(bool print)
        {

            view.ShouldLookLikeTheConsoleIsWarningForWhatHappened(View.Member.NormalMessageMemberWillbeDeleted);

            // Show Member in console
            if (print)
            {
                view.consoleWriteMember(member);
            }

            // Answer yes or no before delete executes.
            view.clientAnsweredYes(View.Member.NormalMessageMemberWillbeDeleted);

            // Check if member exists and delete if      
            member = Cache.CachedMemberCatalog.Delete(member);

            return member;
        }

        private void MemberHasSucessfullyBeenCreatedButNowWeNeedToAskClienAboutCachingUpdates()
        {
            // Object was valid...
            view.consoleWriteMember(member);

            getClientsResponseBeforeCachingThisNewThingUp();

            if (view.clientAnsweredYes(ClientResponse))
            {
                Cache.CachedMemberCatalog.Create();
                Cache.CachedMemberCatalog.AddMember(member);

                view.consoleWriteMember(member, true);
                sleep(5000);

                ClientDidChooseAndNowSystemNeedsThisMethodForDecideWhatToPresentNext();

            }
            else
            {
                // Set crudMode to stateless. Go back automatically and prevents some crudding stuff to happen again.
                view.YouDidQuitSomeCruddyThingToHappenAndSystemsShowItToClient(View.Member.WarningMessageCancelationHasHappened);
                Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);
                sleep(5000);
                //return prepareNewCacheFromMenuMember();
            }      
        }

        private void sleep(int ms) 
        {
            System.Threading.Thread.Sleep(ms);
        }

        public override Model.Cache DoControl(Interface.IView iview, Interface.IController controller)
        {
            // Important if controller not should depend to implement stuff through IView
            view = iview as View.Member;

            if (controller.Cache.getCrudModeInCache() != Model.Cache.crudMode.Stateless)
            {
                // Ok. It's time for crudding. We prepare...
                // Member to use in all cases. Do not create more than one
                // Easier to maintain.
                member = new Model.Member();

                switch (controller.Cache.getCrudModeInCache())
                {
                // start region >>>>>
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                    
                                                                                                                            //- - - - c r e a t e          
                    case Model.Cache.crudMode.Create:
                        menuSwitcher(view, controller);

                        // Creates and validates
                        MemberCreator(true, true, true);

                        MemberHasSucessfullyBeenCreatedButNowWeNeedToAskClienAboutCachingUpdates();
                        return prepareNewCacheFromMenuMember();
         
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                                                                                                                           //- - - - - - r e a d
                    case Model.Cache.crudMode.Read:
                        menuSwitcher(view, controller);

                        // An existing Member is cachded in Cache.CachedMemberCatalog
                        // Member has uniqueness regarding personal number. Qlient get's question for SSN...
                        ClientResponse = view.getResponse(View.Member.NormalMessageFAQNeedSSN, true);
                        getMemberBySSN(true);
               
                        // Menu
                        ClientDidChooseAndNowSystemNeedsThisMethodForDecideWhatToPresentNext();
                        return prepareNewCacheFromMenuMember();

                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : :
                                                                                                                           // - - - -u p d a t e
                        case Model.Cache.crudMode.Update:
                            menuSwitcher(view, controller);

                            ClientResponse = view.getResponse(View.Member.NormalMessageFAQNeedSSN, true);
                            getMemberBySSN(true);

                            // Update firsname and lastname. Leaves SSN untouched :)
                            MemberCreator   
                                            (
                                                view.clientAnsweredYes(view.getResponse(view.DoYouReallyWantToUpdate(View.Member.WarningMessageUpdateMemberField, Model.FieldInModelMember.firsName, member), true)),
                                                view.clientAnsweredYes(view.getResponse(view.DoYouReallyWantToUpdate(View.Member.WarningMessageUpdateMemberField, Model.FieldInModelMember.lastName, member), true)),
                                                false
                                            );

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);
                        return prepareNewCacheFromMenuMember();
                
                    // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 

                                                                                                                           //- - - - d e l e t e
                        case Model.Cache.crudMode.Delete:
                            menuSwitcher(view, controller);

                            ClientResponse = view.getResponse(View.Member.NormalMessageFAQNeedSSN, true);
                            getMemberBySSN(true);

                            DeleteMemberBySSN(true);

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);
                        return prepareNewCacheFromMenuMember();
                        // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                // <<<<< end region
                    default:
                        throw new ApplicationException("Something weird. What happened. C-R-U-D is all we need here...");
                }
            }
            else 
            {
                menuSwitcher(view, controller);
                ClientResponse = view.getResponse();
                SelectedInMenuMember = (Model.Cache.menuMember)int.Parse(ClientResponse);
                return prepareNewCacheFromMenuMember();
            }
        }
    }
}
