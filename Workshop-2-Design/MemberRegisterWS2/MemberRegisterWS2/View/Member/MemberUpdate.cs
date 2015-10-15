using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{
    enum MenuUpdateMember
    {
        Quit = 0,
        Continue = 1,
        StatelessForNow
    }

    class MemberUpdate : baseMember
    {
        public string AskClientAboutFirstName()
        {
            return base.AskForInput("Please: Input Member's first name: ");
        }

        public string AskClientAboutLastName()
        {
            return base.AskForInput("Please: Input Member's last name: ");
        }

        public string AskClientAboutPersonalNumber()
        {
            return base.AskForInput("Please: Input Member's Personal Number: ");
        }

        public void NotExistingMember()
        {
            Console.WriteLine("Member does not exist!");
        }

        public bool ShowExistingValueAndAskClientForUpdate(string field, string existingValueInField)
        {
            while (true)
            {
                Console.Write("\nDo you wanna update <<{0}>>\nfrom <<{1}>> to something else?\n\n y/n ", field, existingValueInField);

                try
                {
                    string key = Console.ReadLine();

                    if (key == "y" || key == "Y")
                    {
                        Console.WriteLine();
                        return true;
                    }

                    if (key != "y" || key != "Y" || key != "n" || key != "N")
                    {
                        throw new Exception("Please: Enter y or Y or n or N. \nThank you!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
