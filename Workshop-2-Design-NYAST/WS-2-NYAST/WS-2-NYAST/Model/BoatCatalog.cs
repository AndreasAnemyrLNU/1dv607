using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    public class BoatCatalog : IEnumerable
    {

        public List<Boat> boats;
        
        public int position;

        public BoatCatalog(List<Boat> Boats) 
        {
            boats = Boats;
        }
    

        public BoatCatalog() 
        {
            boats = new List<Boat>();
        }

        public void Create()
        {
            boats = new List<Boat>();

            if (boats == null)
            {
                throw new Exception("Fail: The Catalog of members could not be created!");
            }
        }

        public List<Boat> Read()
        {
            return boats;
        }

        public Model.BoatCatalog Read(string groupId)
        {
            Model.BoatCatalog boatCatalogByGroupId = new Model.BoatCatalog();

            foreach(Model.Boat boat in boats)
            {
                if (boat.GroupId == groupId)
                {
                    boatCatalogByGroupId.Add(boat);
                }
            }
            return boatCatalogByGroupId;
        }

        public Model.Boat Read(int indexInBoats) 
        {
            return boats[indexInBoats];
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Model.Boat Add(Boat boat)
        {
            boats.Add(boat);
            return boat;
        }

        public int? NrOfBoatsInBoatCatalog() 
        {
            return boats.Count;
        }

        public IEnumerator<Boat> GetEnumerator()
        {
            return boats.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator() 
        {
            return boats.GetEnumerator();
        }

 
    }
}
