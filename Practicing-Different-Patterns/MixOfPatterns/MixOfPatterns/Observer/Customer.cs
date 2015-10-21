using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Observer
{
    class Customer : Observer
    {

        public string customerName { get; set; }
        public Subject subject { get; set; }


        public void Update(string productName)
        {
            Console.WriteLine("Hello " + customerName + ", " + productName + " is now available");
        }



    }
}
