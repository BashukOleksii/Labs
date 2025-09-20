using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public class Appliances
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
    

     // Оператори:
       
        public static Appliances operator+(Appliances a, double num)
        {
            return new Appliances(a) { Price = a.Price + num };
        }

        public static Appliances operator-(Appliances a, double num)
        {
            return new Appliances(a) { Price = a.Price - num }; 
        }

        public static Appliances operator *(Appliances a, double num)
        {
            return new Appliances(a) { Price = a.Price * num };
        }
        
        public static Appliances operator /(Appliances a, double num)
        {
            return new Appliances(a) { Price = a.Price / num };
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
        public static Appliances operator &(Appliances a1, Appliances a2)
        {
            int now = DateTime.Now.Year;
            if((a1.Year == now) && (a2.Year == now))
                return a1;
            return new Appliances();
        }

        public static Appliances operator |(Appliances a1, Appliances a2)
        {
            int now = DateTime.Now.Year;
            if (a1.Year == now)
                return a1;
            if (now == a2.Year)
                return a2;
            return new Appliances();
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
        public static implicit operator string(Appliances a)
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


    }
}
