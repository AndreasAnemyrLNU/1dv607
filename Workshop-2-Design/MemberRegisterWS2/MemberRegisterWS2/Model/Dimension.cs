using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.M
{

    public enum UnitOfMeasure { cm }

    class Dimension
    {
        int Length { get; set; }

        UnitOfMeasure UnitOfMeasure { get; set; }

        public Dimension(int length, M.UnitOfMeasure unitsOfMeasure)
        {
            UnitOfMeasure = unitsOfMeasure;
            Length = length;
        }

        public override string ToString()
        {
            return string.Format("This boat's length is {0}{1}",Length, UnitOfMeasure);
        } 

    }
}
