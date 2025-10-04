using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class Microwave: Appliances
    {
        public double TableDiametr {  get; set; }
        public string HasGril { get; set; }

        public Microwave() :base(){ TableDiametr = 0; HasGril = "Ні"; }

        public Microwave(string Id, string Name, string Brand, double Price, short Year, string EnergyClass, short Power, double TableDiametr,string HasGrill) : base(Id, Name, Brand, Price, Year, EnergyClass, Power)
        {
            this.TableDiametr = TableDiametr;
            this.HasGril = HasGrill;
        }

        public Microwave(Microwave other) : base(other) { 
            this.TableDiametr = other.TableDiametr;  
            this.HasGril = other.HasGril;
        }

        public override Appliances Clone()
        {
            return new Microwave(this);
        }

        public override void Discount()
        {
            double discount;

            if (TableDiametr < 5)
                discount = Price * 0.1;
            else if (TableDiametr < 10)
                discount = Price * 0.2;
            else
                discount = Price * 0.3;

            if (disc)
            {
                Price -= discount;
                disc = false;
            }

        }

        public override void WriteToFile(BinaryWriter writer)
        {
            base.WriteToFile(writer);
            writer.Write(TableDiametr);
            writer.Write(HasGril);
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            TableDiametr = reader.ReadDouble();
            HasGril = reader.ReadString(); 
        }

    }
}
