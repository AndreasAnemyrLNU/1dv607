using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Factory
{
    class UFOEnemyShip : EnemyShip
    {
        public UFOEnemyShip() 
        {
            setName("UFO Enemy Ship");

            setDamage(20.0);

        }
    }
}
