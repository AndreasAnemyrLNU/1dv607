using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Factory
{
    class BigUFOEnemyShip : UFOEnemyShip
    {
        public BigUFOEnemyShip() 
        {
            setName("BigUFO Enemy Ship");

            setDamage(40.0);

        }
    }
}
