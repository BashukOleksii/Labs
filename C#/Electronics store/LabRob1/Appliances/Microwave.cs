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

        #region Властивості
        public double TableDiametr {  get; set; }
        public string HasGril { get; set; }

        #endregion

        #region Конструктори
        public Microwave() :base(){ TableDiametr = 0; HasGril = "Ні"; }

        public Microwave
            (string Id, string Name,double Price, short Year, short Power, double TableDiametr,string HasGrill,ManufactureApp manufacture) 
            : base(Id, Name, Price, Year, Power,manufacture)
        {
            this.TableDiametr = TableDiametr;
            this.HasGril = HasGrill;
        }

        public Microwave(Microwave other) : base(other) { 
            this.TableDiametr = other.TableDiametr;  
            this.HasGril = other.HasGril;
        }

        #endregion

        #region Перевизначення

        public override Appliances Clone()
        {
            return new Microwave(this);
        }

        public override void Discount()
        {
            double discount;

            if (TableDiametr < 10)
                discount = Price * 0.03;
            else if (TableDiametr < 15)
                discount = Price * 0.05;
            else
                discount = Price * 0.01;

            if (!disc)
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

        public override void FillDataRow(DataRow row)
        {
            base.FillDataRow(row);
            row["Діаметр тарілки"] = TableDiametr;
            row["Наявність грилю"] = HasGril;
        }

        public override void ImagesWhenDelete(Form1 form)
        {
            base.ImagesWhenDelete(form);
            form.pMicrowave.Visible = true;
            form.textBox40.Text = TableDiametr.ToString();
            form.comboBox19.Text = HasGril.ToString();
        }

        #endregion

    }
}   
