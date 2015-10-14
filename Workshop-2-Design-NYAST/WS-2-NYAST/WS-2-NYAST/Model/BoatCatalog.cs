using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    class BoatCatalog
    {

        private List<Boat> boats;

        public BoatCatalog() 
        {
            boats = new List<Boat>();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public Model.BoatCatalog Read(string groupId)
        {
            Model.BoatCatalog boatCatalogByGroupId = new Model.BoatCatalog();

            foreach(Model.Boat boat in boats)
            {
                if (boat.GroupId == groupId)
                {
                    boatCatalogByGroupId.AddBoat(boat);
                }
            }
            return boatCatalogByGroupId;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Model.Boat AddBoat(Boat boat)
        {
            boats.Add(boat);
            return boat;
        }
    }
}
