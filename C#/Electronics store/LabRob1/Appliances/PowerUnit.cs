using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class PowerUnit
    {
        public string Id { get;  set; }
        public string EnergyClass { get;  set; }
        public short Power { get; set; }

        public PowerUnit() { Id = $"PU - {Guid.NewGuid().ToString().Substring(0,5).ToUpper()}"; }

        public PowerUnit(string Id, short Power)
        {
            this.Id = $"PU - {Id} - {Guid.NewGuid().ToString().Substring(0,5).ToUpper()}";
            this.Power = Power;
            EnergyClass = SetEnergyClass();
        }

        private string SetEnergyClass()
        {
            if (Power <= 600)
                return "A+++";
            else if (Power <= 800)
                return "A++";
            else if (Power <= 1000)
                return "A+";
            else if (Power <= 1500)
                return "A";
            else if (Power <= 2000)
                return "B";
            else
                return "C";
        }


    }
}
