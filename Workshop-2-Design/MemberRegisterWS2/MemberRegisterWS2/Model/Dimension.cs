using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Model
{

    public enum UnitOfMeasure { cm }

    class Dimension
    {
        int Length { get; set; }

        UnitOfMeasure unitOfMeasure { get; set; }

        Dimension(int length, UnitOfMeasure UnitOfMeasure = UnitOfMeasure.cm)
        {
            UnitOfMeasure = UnitOfMeasure;
            Length = length;
        }
    }
}
