using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Factory
{
    public class EnemyShipFactory
    {

        public EnemyShip MakeEnemyShip(string newShipType)
        {
            //EnemyShip newShip = null;

            if(newShipType.Equals("UFO"))
            {
                return new UFOEnemyShip();
            }
            else
            {
                return new RocketEnemyShip();
            }
        }

    }
}
