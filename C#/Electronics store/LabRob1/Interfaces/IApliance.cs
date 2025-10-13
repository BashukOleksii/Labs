using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabRob1
{
    public interface IAppliance
    {
         void   Discount();

         Appliances Clone();
    }
}
