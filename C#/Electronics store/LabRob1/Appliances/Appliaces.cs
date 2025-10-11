using System;
using System.Data;
using System.IO;


namespace LabRob1
{
    public abstract class Appliances : IAppliance, IData, IFormWork
    {
        #region Властивості
        
        static int id = 1;
        const double priceKW = 3.25;


        public string Id { get; private set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public short Year { get; set; }
        public double EnergyCost { get; private set; }
        public ManufactureApp Manufacture { get; set; }
        public PowerUnit PUnit { get; private set; }
        private void CalculateCost()
        {
            EnergyCost = (double)PUnit.Power * priceKW/1000;
        }   

        #endregion

        #region Конструктори

        public Appliances(): this(id.ToString(),"Ім'я " + id,0,0,0, new ManufactureApp()) { }

        public Appliances(string Id, string Name, double Price, short Year,short Power, ManufactureApp Manufacture)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Year = Year;
            
            PUnit = new PowerUnit(this.Id,Power);

            this.Manufacture = Manufacture;

            id++;
            CalculateCost();
        }

        public Appliances(Appliances other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.Price = other.Price;
            this.Year = other.Year;
            this.PUnit = other.PUnit;
            this.EnergyCost = other.EnergyCost;
            this.Manufacture = other.Manufacture;
        }

        #endregion

        #region Абстрактні методи

        protected bool disc = false;
        public abstract void Discount();

        public abstract Appliances Clone();

        #endregion

        #region Оператори

        public static Appliances operator+(Appliances a, double num)
        {
            Appliances app = a.Clone();
            app.Price += num;
            return app;
        }

        public static Appliances operator-(Appliances a, double num)
        {
            Appliances app = a.Clone();
            app.Price -= num;
            return app;
        }

        public static Appliances operator *(Appliances a, double num)
        {
            Appliances app = a.Clone();
            app.Price *= num;
            return app;
        }
        
        public static Appliances operator /(Appliances a, double num)
        {
            Appliances app = a.Clone();
            app.Price /= num;
            return app;
        }


        // Логічні оператор для первірки того чи новий об'єкт.
        public static bool operator true(Appliances a)
        {
            int now = DateTime.Now.Year;
            return a.Year == now;
        }
        public static bool operator false(Appliances a)
        {
            int now = DateTime.Now.Year;
            return a.Year != now;
        }
        //
        public static Appliances operator &(Appliances a1, Appliances a2)
        {
            int now = DateTime.Now.Year;
            if((a1.Year == now) && (a2.Year == now))
                return a1;
            return null;
        }

        public static Appliances operator |(Appliances a1, Appliances a2)
        {
            int now = DateTime.Now.Year;
            if (a1.Year == now)
                return a1;
            if (now == a2.Year)
                return a2;
            return null;
        }
        public static bool operator!(Appliances a)
        {
            return a.Year != DateTime.Now.Year;
        }


        // Переведенн типів, для того, щоб отримувати ціну Товару
        public static implicit operator double(Appliances a)
        {
            return a.Price;
        }
        public static  implicit operator string(Appliances a)
        {
            return a.Name + " " + a.Manufacture.ToString();
        }

        // Перевантаження операторів порівняння:
        //      Щоб знаходти об'єкти із максимальною ціною (>,<) - Додати кнопку та опис кнопки
        //      Щоб знаходити всі товари із ціною вираного товару (==, !=)
        public static bool operator >(Appliances a1, Appliances a2)
        {
            return a1.Price > a2.Price;
        }
        public static bool operator <(Appliances a1, Appliances a2)
        {
            return a2 > a1;
        }
        public static bool operator ==(Appliances a1, Appliances a2)
        {
            return a1.Price == a2.Price;
        }
        public static bool operator !=(Appliances a1,Appliances a2)
        {
            return !(a1 == a2);
        }

        // Унарні оператори
        public static Appliances operator ++(Appliances a)
        {
            a.Price += 1000;
            return a;
        }
        public static Appliances operator --(Appliances a)
        {
            a.Price -= 1000;
            return a;
        }

        #endregion

        #region Віртуальні методи 
        public virtual void WriteToFile(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Name);
            writer.Write(Price);
            writer.Write(Year);

            writer.Write(PUnit.Id);
            writer.Write(PUnit.EnergyClass);
            writer.Write(PUnit.Power);

            writer.Write(EnergyCost);

            writer.Write(Manufacture.Name);
            writer.Write(Manufacture.Country);
        }

        public virtual void ReadFromFile(BinaryReader reader)
        {
            Id = reader.ReadString();
            Name = reader.ReadString();
            Price = reader.ReadDouble();
            Year = reader.ReadInt16();

            PUnit.Id = reader.ReadString();
            PUnit.EnergyClass = reader.ReadString();
            PUnit.Power = reader.ReadInt16();

            EnergyCost = reader.ReadDouble();

            Manufacture.Name = reader.ReadString();
            Manufacture.Country = reader.ReadString();
        }

        public virtual void FillDataRow(DataRow row)
        {
            row["ID"] = Id;
            row["Ім'я"] = Name;
            row["Ціна"] = Price;
            row["Рік випуску"] = Year;
            row["Id - блоку живлення"] = PUnit.Id;
            row["Тип спожвання"] = PUnit.EnergyClass;
            row["Потужність"] = PUnit.Power;
            row["Витратність (на год.)"] = EnergyCost;
            row["Виробник"] = Manufacture.Name;
            row["Країна-виробник"] = Manufacture.Country;
        }
       
        public virtual void ImagesWhenDelete(Form1 form)
        {
            form.textBox13.Text = Id;
            form.textBox18.Text = Name;
            form.textBox17.Text = Manufacture.Name;
            form.textBox9.Text = Manufacture.Country;
            form.textBox16.Text = Price.ToString();
            form.textBox15.Text = Year.ToString();
            form.comboBox12.Text = PUnit.EnergyClass;
            form. textBox14.Text = PUnit.Power.ToString();
            form.pCleaner.Visible = false;
            form.pWashingMashine.Visible = false;
            form.pMicrowave.Visible = false;
        }

        #endregion

    }
}
