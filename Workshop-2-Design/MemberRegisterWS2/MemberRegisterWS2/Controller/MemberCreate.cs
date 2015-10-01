using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class MemberCreate
    {
        private View.MemberCreate view;

        private Model.Member member;
        
        public MemberCreate() 
        {
            //Create instance for view for interaction with client
            view = new View.MemberCreate();
            member = new Model.Member();
        }

        public void doMemberCreate() 
        {
            bool firstNameApproved = false;
            bool lastNameApproved = false; 
            bool persNrApproved = false;

            do
            {
                try
                {
                    member.Name = view.askClientAboutFirstName();
                    firstNameApproved = true;                
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (firstNameApproved != true && lastNameApproved != true && persNrApproved != true);

            
            
            //string lastName = view.askClientAboutLastName();

            //string persNr = view.askClientAboutPersonalNumber();


            //return true;
        }
    }
}
