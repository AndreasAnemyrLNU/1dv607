using MixOfPatterns.strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            //RunStrategy();

            //RunFactory();

            //RunAbstractFactory();

            //RunObserverPattern();

            //RunTeamStrategy();

            RunVisitor();

            Console.ReadKey();

        }

        private static void RunVisitor()
        {
            Visitor.Tobacco tobacco = new Visitor.Tobacco();
            Visitor.Necessity neccesity = new Visitor.Necessity();
            Visitor.Liquor liquor = new Visitor.Liquor();

            Visitor.SpeccyVisitor speccy = new Visitor.SpeccyVisitor();
            Visitor.SpeccySpeccy speccySpeccy = new Visitor.SpeccySpeccy();

            speccy.visit(tobacco);
            speccySpeccy.visit(neccesity);
            speccy.visit(liquor);

        }


        private static void RunTeamStrategy()
        {
            TeamStrategy.Team argentina = new TeamStrategy.TeamArgentina();
            argentina.teamName = "Arga Tina!";

            TeamStrategy.Team germany = new TeamStrategy.TeamGermany();
            germany.teamName = "Ger Money";

            //Strategies

            TeamStrategy.TeamStrategy attack = new TeamStrategy.AttackStrategy();
            TeamStrategy.TeamStrategy defense = new TeamStrategy.DefenseStrategy();

            germany.teamStrategy = defense;
            germany.PlayGame();

            argentina.teamStrategy = attack;
            argentina.PlayGame();

            germany.teamStrategy = attack;
            germany.PlayGame();






        }

        private static void RunObserverPattern()
        {
            Observer.Customer customer1 = new Observer.Customer();
            customer1.customerName = "Andreas";



            Observer.Customer customer2 = new Observer.Customer();
            customer2.customerName = "Benny";

            Observer.Product mig16 = new Observer.Product();
            mig16.productName = "Flygplan";
            mig16.Available = false;

            mig16.RegisterObserver(customer1);
            mig16.RegisterObserver(customer2);

            mig16.Available = true;

            mig16.RemoverObserver(customer2);

            mig16.Available = false;


        }

        private static void RunAbstractFactory()
        {
            /*
             * Everything is encapsulated
             * The method that orders the object
             * The factories that build the object
             * The final objects
             * The final objects contain objects that use the Strategy Pattern
             *      Composition :: Object class fields are objects
             */
        }

        private static void RunFactory()
        {


            /*
             * Notest Andreas 2015-10-20 22:53
             * Abstract EnemyShip is a abstract class
             * that implements all needed for the other specialized classes (Inhertitance)
             * 
             * The Factory returns the generic abstract type.
             *
             * And we do not need lots of if else if else in our controller....
             * 
             */

            Factory.EnemyShipFactory factory = new Factory.EnemyShipFactory();


            factory.MakeEnemyShip("UFOsdt").displayEnemyShip();



            while (true)
            {
                
                /*
                 * Bad if else stuff!! Test factory pattern instead!
                 * 
                 * 
                AbsstractFactory.EnemyShip enemy;

                Console.WriteLine("UFO or Rocket");
                string input = Console.ReadLine();

                if (input == "UFO")
                {
                    enemy = new AbsstractFactory.UFOEnemyShip();
                }
                else
                {
                    enemy = new AbsstractFactory.RocketEnemyShip();
                }


                AbsstractFactory.Client client = new AbsstractFactory.Client();

                enemy.displayEnemyShip();
                */ 
            }

            
        }

        private static void RunStrategy()
        {
            Person nisse = new Person();
            nisse.setToSpeaky3();
            nisse.SpeakUp();
            //nisse.setToSpeaky3();
            //nisse.SpeakUp();

            //Person kalle = new Person();

            //kalle.setToSpeaky2();
            //kalle.SpeakUp();
        }
    }
}
