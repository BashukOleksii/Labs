using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabRob1
{
    public interface IApliance
    {
         void Discount();

         Appliances Clone();
    }
}
