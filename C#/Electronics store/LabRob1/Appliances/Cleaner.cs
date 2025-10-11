using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class Cleaner: Appliances
    {

        #region Властивості

        public string Type { get; set; }
        public string HasBrush {  get; set; }

        #endregion

        #region Конструктори

        public Cleaner() : base() { Type = "None"; HasBrush = "Ні"; }
        public Cleaner
            (string Id, string Name, double Price, short Year, short Power, string Type, string HasBrush, ManufactureApp manufacture) 
            : base(Id, Name, Price, Year, Power,manufacture)
        {
            this.Type = Type;
            this.HasBrush = HasBrush;
        }

        public Cleaner(Cleaner other): base(other)
        {
            this.Type = other.Type;
            this.HasBrush = other.HasBrush;
        }

        #endregion

        #region Перевизначення
        public override Appliances Clone()
        {
            return new Cleaner(this);
        }

        public override void Discount()
        {
            double discount = 0;

            if (Type == "Класичний")
                discount = Price * 0.05;
            else if (Type == "Вертикальний")
                discount = Price * 0.03;
            else if (Type == "Робот")
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
            writer.Write(Type);
            writer.Write(HasBrush);
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
            Type = reader.ReadString();
            HasBrush = reader.ReadString();
        }

        public override void FillDataRow(DataRow row)
        {
            base.FillDataRow(row);
            row["Тип пилососу"] = Type;
            row["Наявність щітки"] = HasBrush;
        }

        public override void ImagesWhenDelete(Form1 form)
        {
            base.ImagesWhenDelete(form);
            form.pCleaner.Visible = true;
            form.textBox39.Text = Type;
            form.comboBox18.Text = HasBrush.ToString();
        }

        #endregion

    }
}
