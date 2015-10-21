using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Factory
{
    public abstract class EnemyShip
    {
        private String name;

        private double amtDamage;

        public string getName() 
        {
            return name;
        }
        public void setName(String newName)
        {
            name = newName;
        }



        public double getDamage()
        {
            return amtDamage;
        }

        public void setDamage(double newDamage)
        {
            amtDamage = newDamage;
        }

        public void followHeroShip() 
        {
            Console.WriteLine(getName() + "is following ther hero");
        }

        public void displayEnemyShip()
        {
            Console.WriteLine(getName() + "is on the screen");
        }

        public void enemyShipShoots()
        {
            Console.WriteLine(getName() + " attacks and does " + getDamage());
        }

    }
}
