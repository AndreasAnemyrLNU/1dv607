using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    abstract class View : Interface.IClientCommunicate, Interface.IView
    {        
        abstract public void setRequest();

        abstract public string getResponse(string question = null, bool completelylOwnFormattedQuestion = false); 

        protected void TitleOut(string title)
        {

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            // Region Start Title out
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            }

            Console.WriteLine("\n{0}\n",title);
            Console.ResetColor();
            
            Console.WriteLine("========================================");

            Console.Write("\n\n  Oki! what do you wanna do?\n\n\n");

        }

        // These NotImpl don't need to be here. Fix! From an interface...... 
        public void setCrudMessageToClient(Model.Cache.crudMode crudMode, Interface.IView view)
        {
            throw new NotImplementedException();
        }

        public void errorCrud(string errormessage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n");
            Console.WriteLine(errormessage);
            Console.ResetColor();
            Console.WriteLine("\n");

        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        public bool clientAnsweredYes(string cmd)
        {
            try
            {
                switch (cmd)
                {
                    case "y": return true;
                    case "Y": return true;
                    case "n": return false;
                    case "N": return false;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine(menu.clientAnsweredYes);
            }
            return false;
        }

        public bool clientSaidReturn(string cmd)
        {
            switch(cmd)
            {
                case "" : return true;
                
                default:
                    return false;
            }
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
