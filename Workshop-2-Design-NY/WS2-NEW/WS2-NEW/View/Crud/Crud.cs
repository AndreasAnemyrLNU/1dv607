using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    abstract class Crud : WS2_NEW.View.View, Interface.ICRUD
    {
        override public abstract void setRequest();

        public override string getResponse(string question = null, bool completelylOwnFormattedQuestion = false)
        {
            if (!completelylOwnFormattedQuestion)
            {
                Console.Write("\n ");
                Console.WriteLine("Plz - enter {0} and press enter...", question);
            }
            else 
            {
                Console.Write("\n ");
                Console.WriteLine("{0}", question);
            }

            while (true)
            {
                try
                {
                    Console.Write("\n\n : ");
                    return Console.ReadLine();
                }           
                catch (Exception e)
                {
                    errorCrud(e.Message);
                }
            }  
        }
        public void Create()
        {
            Console.Clear();
            Console.WriteLine("Ok - You want to create a {0}?\n", this.GetType().Name);
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine("Ok - You want to view a {0}?\n", this.GetType().Name);
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Ok - You want to edit a {0}?\n", this.GetType().Name);
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("Ok - You want to erase a {0}?\n", this.GetType().Name);
        }


        public Model.Member Read(Model.Member toBeRead)
        {
            throw new NotImplementedException();
        }

        public Model.Member Update(Model.Member toBeUpdated)
        {
            throw new NotImplementedException();
        }

        public Model.Member Delete(Model.Member toBeDeleted)
        {
            throw new NotImplementedException();
        }

        public Model.Member AddMember(Model.Member member)
        {
            throw new NotImplementedException();
        }
    }
}
