using System;
using System.Collections;

namespace LocationLibrary
{
    public class Location : IInit, IComparable, ICloneable
    {
        protected const int MinLongitude = -180, MaxLongitude = 180, MinLatitude = -90, MaxLatitude = 90;
        // Поля - отражают координаты места
        protected double longitude; // Долгота
        protected double latitude;  // Широта
        protected static Random random = new Random();
        // Свойства
        public double Longitude
        {
            get { return longitude; }
            set 
            { 
                if (value <= MaxLongitude && value >= MinLongitude)
                    longitude = value; 
            }
        }
        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value <= MaxLatitude && value >= MinLatitude)
                    latitude = value;
            }
        }
        // Конструкторы
        public Location()
        {
            Longitude = 0;
            Latitude = 0;
        }
        public Location(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        // Методы
        virtual public void Show()
        {
            Console.WriteLine("Долгота: " + "{0:0.####}", Longitude);
            Console.WriteLine("Широта: " + "{0:0.####}", Latitude);
        }
        virtual public void Init()
        {
            double lg = CustomFunctions.InputDouble("Введите долготу (значение от -180.0000 до 180.0000)");
            CustomFunctions.CheckNumber(MinLongitude, MaxLongitude, ref lg);
            Longitude = lg;
            double lt = CustomFunctions.InputDouble("Введите широту (значение от -90.0000 до 90.0000)");
            CustomFunctions.CheckNumber(MinLatitude, MaxLatitude, ref lt);
            Latitude = lt;
        }
        virtual public void RandomInit()
        {
            Longitude = (double) random.Next(-1800000, 1800000) / 10000;
            Latitude = (double) random.Next(-900000, 900000) / 10000;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Location loc = (Location)obj;
                return (Longitude == loc.Longitude) && (Latitude == loc.Latitude);
            }
        }

        public int CompareTo(object obj)
        {
            Location temp = (Location)obj;
            if (this.Longitude > temp.Longitude)
                return 1;
            if (this.Longitude < temp.Longitude)
                return -1;
            return 0;
        }

        public Location ShallowCopy() //поверхностное копирование
        {
            return (Location)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Location(Longitude, Latitude);
        }

        public override string ToString()
        {
            return $"{Longitude}:{Latitude}";
        }
    }
    public class SortByLatitude : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            Location l1 = (Location)ob1;
            Location l2 = (Location)ob2;
            if (l1.Latitude > l2.Latitude)
                return 1;
            if (l1.Latitude < l2.Latitude)
                return -1;
            return 0;
        }
    }
}
