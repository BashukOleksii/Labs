using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class WashingMashine: Appliances
    {
        public short SpinSpeed { get; set; }
        public double MaxKgLoad { get; set; }

        public WashingMashine(string Id, string Name, string Brand, double Price, short Year, string EnergyClass, short Power, short SpinSpeed, double MaxKgLoad) : base(Id, Name, Brand, Price, Year, EnergyClass, Power)
        {
            this.SpinSpeed = SpinSpeed;
            this.MaxKgLoad = MaxKgLoad;
        }

        public WashingMashine() : base() { SpinSpeed = 0; MaxKgLoad = 0; }
        public WashingMashine(WashingMashine other):base(other) {
            this.SpinSpeed = other.SpinSpeed;
            this.MaxKgLoad = other.MaxKgLoad;
        }

        public override Appliances Clone()
        {
            return new WashingMashine(this);
        }

        public override void Discount()
        {
            double discount;

            if (MaxKgLoad < 3)
                discount = Price * 0.05;
            else if (MaxKgLoad < 5)
                discount = Price * 0.1;
            else
                discount = Price * 0.15;

            if (disc)
            {
                Price -= discount;
                disc = false;
            }
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            base.WriteToFile(writer);
            writer.Write(SpinSpeed);
            writer.Write(MaxKgLoad);
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            SpinSpeed = reader.ReadInt16();
            MaxKgLoad = reader.ReadDouble();
        }

        public override void FillDataRow(DataRow row)
        {
            base.FillDataRow(row);
            row["Обертів на хвилину"] = SpinSpeed;
            row["Максимальна вага"] = MaxKgLoad;
        }
    }
}
