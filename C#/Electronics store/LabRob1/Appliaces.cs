using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public abstract class Appliances
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

        public Appliances(): this(id.ToString(),"Ім'я " + id, "Бренд " + id, 0, 0, "No",0) { }

        public Appliances(string Id, string Name, string Brand, double Price, short Year, string EnergyClass, short Power)
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

        public Appliances(Appliances other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.Brand = other.Brand;
            this.Price = other.Price;
            this.Year = other.Year;
            this.EnergyClass = other.EnergyClass;
            this.Power = other.Power;
            this.EnergyCost = other.EnergyCost;
        }

        // Вартість за годину роботи
        private void CalculateCost()
        {
            double priceKW = 3.25;
            EnergyCost = (double)Power * priceKW /1000;
        }

        protected bool disc = false;
        public abstract void Discount();

public abstract Appliances Clone();
    

     // Оператори:
       
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
            return a.Name + " " + a.Brand;
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


        public virtual void WriteToFile(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Name);
            writer.Write(Brand);
            writer.Write(Price);
            writer.Write(Year);
            writer.Write(EnergyClass);
            writer.Write(Power);
            writer.Write(EnergyCost);
        }

        public virtual void ReadFromFile(BinaryReader reader)
        {
            Id = reader.ReadString();
            Name = reader.ReadString();
            Brand = reader.ReadString();
            Price = reader.ReadDouble();
            Year = reader.ReadInt16();
            EnergyClass = reader.ReadString();
            Power = reader.ReadInt16();
            EnergyCost = reader.ReadDouble();

        }

        public virtual void FillDataRow(DataRow row)
        {
            row["ID"] = Id;
            row["Ім'я"] = Name;
            row["Бренд"] = Brand;
            row["Ціна"] = Price;
            row["Рік випуску"] = Year;
            row["Тип спожвання"] = EnergyClass;
            row["Потужність"] = Power;
            row["Витратність (на год.)"] = EnergyCost;
        }
       
    }
}
