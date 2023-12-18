using System;

namespace LocationLibrary
{

    public class Region : Location
    {
        protected string regionName;
        static string[] regions = { "Западная Европа", "Северная Европа", "Южная Европа", "Восточная Европа", "Западная Азия", "Центральная Азия", "Южная Азия", "Восточная Азия", "Юго-Восточная Азия", "Северная Африка", "Западная Африка", "Центральная Африка", "Восточная Африка", "Южная Африка", "Северная Америка", "Центральная Америка", "Карибский бассейн", "Южная Америка", "Австралия и Новая Зеландия", "Меланезия", "Микронезия", "Полинезия" };
        public string RegionName { get; set; }
        public Region() : base()
        {
            RegionName = "Без имени";
        }
        public Region(double longitude, double latitude, string name) : base(longitude, latitude)
        {
            RegionName = name;
        }
        public override void Show()
        {
            Console.WriteLine("\t\"Область\"");
            base.Show();
            Console.WriteLine($"Имя области: {RegionName}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите название области");
            RegionName = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            RegionName = regions[random.Next(0, regions.Length - 1)];
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Region reg = (Region)obj;
                return (Longitude == reg.Longitude) && (Latitude == reg.Latitude) && (RegionName == reg.RegionName);
            }
        }

        public Region ShallowCopy() //поверхностное копирование
        {
            return (Region)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Region(this.Longitude, this.Latitude, "Клон" + this.RegionName);
        }

        public Location BaseLocation
        {
            get
            {
                return new Location(Longitude, Latitude);//возвращает объект базового класса
            }
        }

        public override string ToString()
        {
            return $"{Longitude}:{Latitude}:{RegionName}";
        }
    }
}
