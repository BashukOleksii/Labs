using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class Appliaces
    {
        static int id = 1;
        public string Id { get; private set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public double Price { get; set; }
        public short Year { get; set; }

        public string EnergyClass { get; set; }
        public short Power { get; set; }
        public double EnergyCost { get; private set; }

        public Appliaces(): this(id.ToString(),"Ім'я " + id, "Бренд " + id, 0, 0, "No",0) { }

        public Appliaces(string Id, string Name, string Brand, double Price, short Year, string EnergyClass, short Power)
        {
            this.Id = Id;
            this.Name = Name;
            this.Brand = Brand;
            this.Price = Price;
            this.Year = Year;
            this.EnergyClass = EnergyClass;
            this.Power = Power;

            id++;
            CalculateCost();
        }

        // Вартість за годину роботи
        private void CalculateCost()
        {
            double priceKW = 3.25;
            EnergyCost = (double)Power * priceKW /1000;
        }

        bool disc = false;
        public void Discount()
        {
            double discount = 0;

            switch (EnergyClass)
            {
                case "A+++": discount = 0.2;break;
                case "A++": discount = 0.1;break;
                case "A+": discount = 0.1;break;
            }

            if(disc == false)
            {
                disc = true;
                Price -= Price * discount;
            }
        }
    
    }
}
