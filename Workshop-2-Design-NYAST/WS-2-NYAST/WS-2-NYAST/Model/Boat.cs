using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    public class Boat
    {

        public enum TypeBoat { StateLess, Sailboat, Motorsailer, Kayak_Canoe, Other}


        public TypeBoat Type { get; set; }
        
        public int Length { get; set; }

        //public string GroupId { get; set; }

        public Boat() 
        {
            //Empty
        }

        public Boat(int length, TypeBoat type, string groupId) 
        {
            Length = length;
            Type = type;
            //GroupId = groupId;
        }
    }
}
