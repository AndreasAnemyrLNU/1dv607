using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.strategy
{
    class Person
    {
        protected ISpeaky speakyVariant;
    
        public void setToSpeaky1()
        {
                this.speakyVariant = new Speaky1();
        }

        public void setToSpeaky2()
        {
            this.speakyVariant = new Speaky2();
        }

        public void setToSpeaky3()
        {
            this.speakyVariant = new Speaky3();
        }

    
       public void SpeakUp()
       {
            speakyVariant.WhatsYourName();
       }
    
    }
}
