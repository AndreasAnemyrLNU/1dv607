using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Observer
{
    class Product : Subject
    {

        public String productName { get; set; }

        private List<Observer> listOfObservers = new List<Observer>();

        private bool available;

        public bool Available 
        {
            get 
            {
                return available;
            } 
            
            set 
            {
                if (value) 
                {
                    NotifyObservers();
                }

                available = value;    
            } 
        }


        public void RegisterObserver(Observer observer)
        {
            listOfObservers.Add(observer);
        }

        public void RemoverObserver(Observer observer)
        {
            listOfObservers.Remove(observer);
        }

        public void NotifyObservers()
        {

            Console.WriteLine("Notifying all registred customers...");

            foreach(Observer observer in listOfObservers)
            {
                observer.Update(productName);
            }
        }
    }
}
