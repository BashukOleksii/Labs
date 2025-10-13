using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class PowerUnit
    {
        public string Id { get; set; }
        public string EnergyClass { get; set; }
        public short Power { get; set; }

        public PowerUnit() { Id = "PU - " + Guid.NewGuid().ToString().Substring(0, 5).ToUpper(); Power = 0; EnergyClass = "None"; }

        public PowerUnit(string id, short power)
        {
            Id = $"PU-{id}-{Guid.NewGuid().ToString().Substring(0, 5).ToUpper()}";
            Power = power;
            SetEnergyClass();
        }

        private void SetEnergyClass()
        {
            if (Power < 600)
                EnergyClass = "A+++";
            else if (Power < 700)
                EnergyClass = "A++";
            else if (Power < 800)
                EnergyClass = "A+";
            else if (Power < 1000)
                EnergyClass = "A";
            else if (Power < 1200)
                EnergyClass = "B";
            else if (Power < 1500)
                EnergyClass = "C";
            else
                EnergyClass= "D";
        }
    }
}



