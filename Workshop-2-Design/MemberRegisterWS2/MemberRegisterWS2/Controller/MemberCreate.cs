using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class MemberCreate : baseController
    {
        private View.MemberCreate view;

        private Model.Member member;
        
        public MemberCreate() 
        {
            //Create instance for view for interaction with client
            view = new View.MemberCreate();
            member = new Model.Member();
        }

        public Model.Member DoMemberCreate() 
        {
            bool firstNameIsValid = false;
            bool lastNameIsValid = false; 
            bool persNrIsValid = false;


            while(firstNameIsValid != true && lastNameIsValid != true && persNrIsValid != true)
            {
                try 
                {
                    ValidateProperty(out firstNameIsValid, "FirstName");
                    ValidateProperty(out lastNameIsValid, "LastName");
                    ValidateProperty(out persNrIsValid, "PersNr");
            }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                }                
            }

            return member;
        }

        private bool ValidateProperty(out bool inputIsValid, string property)
        {
            do
            {
                try
                {
                    switch(property)
                    {
                        case "FirstName" :
                             member.FirstName = view.AskClientAboutFirstName();     
                             inputIsValid = true;
                             return true;
                        case "LastName":
                            member.LastName = view.AskClientAboutLastName();
                            inputIsValid = true;
                            return true;
                        case "PersNr":
                            member.PersNr = view.AskClientAboutPersonalNumber();
                            inputIsValid = true;
                            return true;
                        default :
                        throw new Exception("Member could not be created for now! Application Error");                   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (true);
        }
    }
}
