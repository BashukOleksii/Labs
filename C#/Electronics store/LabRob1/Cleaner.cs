using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class Cleaner: Appliances
    {
        public string Type { get; set; }
        public string HasBrush {  get; set; }

        public Cleaner() : base() { Type = "None"; HasBrush = "Ні"; }
        public Cleaner(string Id, string Name, string Brand, double Price, short Year, string EnergyClass, short Power, string Type, string HasBrush) : base(Id, Name, Brand, Price, Year, EnergyClass, Power)
        {
            this.Type = Type;
            this.HasBrush = HasBrush;
        }

        public Cleaner(Cleaner other): base(other)
        {
            this.Type = other.Type;
            this.HasBrush = other.HasBrush;
        }

        public override Appliances Clone()
        {
            return new Cleaner(this);
        }

        public override void Discount()
        {
            double discount = 0;

            if (Type == "Класчний")
                discount = Price * 0.05;
            else if (Type == "Верикальний")
                discount = Price * 0.03;
            else if (Type == "Робот")
                discount = Price * 0.01;

            if (disc)
            {
                Price -= discount;
                disc = false; 
            }
        }

    }
}
