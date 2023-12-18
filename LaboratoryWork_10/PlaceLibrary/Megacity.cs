using System;

namespace LocationLibrary
{
    public class Megacity : City
    {
        static int MinPopulationCount = 10000000;
        static int MaxPopulationCount = 50000000;
        static int MinCityArea = 1000;
        static int MaxCityArea = 20000;
        static string[,] cityData = 
{
    {"Япония", "Индия", "Бразилия", "Индия", "Мексика", "США", "Китай", "Индия", "Бангладеш", "США",
     "Пакистан", "Аргентина", "Китай", "Бразилия", "Филиппины", "Япония", "Египет", "Нигерия", "Россия", "Турция", "Франция"},
     {"Токио", "Дели", "Сан-Паулу", "Мумбаи", "Мехико", "Нью-Йорк", "Шанхай", "Калькутта", "Дакка", "Лос-Анджелес",
     "Карачи", "Буэнос-Айрес", "Пекин", "Рио-де-Жанейро", "Манила", "Осака-Кобе", "Каир", "Лагос", "Москва", "Стамбул", "Париж"}
};
        private int cityArea;
        public override string CityName { get; set; }
        public override string CountryName { get; set; }
        public override int PopulationCount
        {
            get { return populationCount; }
            set
            {
                if (value >= MinPopulationCount)
                    populationCount = value;
            }
        }
        public int CityArea
        {
            get { return cityArea; }
            set
            {
                if (value > MinCityArea)
                    cityArea = value;
            }
        }
        public Megacity() : base()
        {
            CityArea = MinCityArea;
        }
        public Megacity(double longitude, double latitude, string city, string country, int population, int area) : base(longitude, latitude, city, country, population)
        {
            CityArea = area;
        }
        public override void Show()
        {
            Console.WriteLine("\t\"Мегаполис\"");
            Console.WriteLine("Долгота: " + "{0:0.####}", Longitude);
            Console.WriteLine("Широта: " + "{0:0.####}", Latitude);
            Console.WriteLine($"Страна: {CountryName}\nГород: {CityName}\nНаселение: {PopulationCount}\nПлощадь (км^2): {CityArea}");
        }
        public override void Init()
        {
            double lg = CustomFunctions.InputDouble("Введите широту (значение от -180.0000 до 180.0000)");
            CustomFunctions.CheckNumber(MinLongitude, MaxLongitude, ref lg);
            Longitude = lg;
            double lt = CustomFunctions.InputDouble("Введите долготу (значение от -90.0000 до 90.0000)");
            CustomFunctions.CheckNumber(MinLatitude, MaxLatitude, ref lt);
            Latitude = lt;
            Console.WriteLine("Введите название страны: ");
            CountryName = Console.ReadLine();
            Console.WriteLine("Введите название мегаполиса: ");
            CityName = Console.ReadLine();
            int pCount = CustomFunctions.InputInteger("Введите число населения: ");
            CustomFunctions.CheckNumber(MinPopulationCount, MaxPopulationCount, ref pCount);
            PopulationCount = pCount;
            int cArea = CustomFunctions.InputInteger("Введите площадь мегаполиса в км^2: ");
            CustomFunctions.CheckNumber(MinCityArea, MaxCityArea, ref cArea);
            CityArea = cArea;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            int cityIndex = random.Next(0, cityData.GetLength(0) - 1);
            CountryName = cityData[0, cityIndex];
            CityName = cityData[1, cityIndex];
            PopulationCount = random.Next(MinPopulationCount, MaxPopulationCount);
            CityArea = random.Next(MinCityArea, MaxCityArea);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Megacity ct = (Megacity)obj;
                return (Longitude == ct.Longitude) && (Latitude == ct.Latitude) && (CountryName == ct.CountryName) && (CityName == ct.CityName) && (PopulationCount == ct.PopulationCount) && (CityArea == ct.CityArea);
            }
        }
        public Megacity ShallowCopy() //поверхностное копирование
        {
            return (Megacity)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Megacity(this.Longitude, this.Latitude, "(Клон) " + this.CityName, this.CountryName, this.PopulationCount, this.CityArea);
        }

        public Location BaseLocation
        {
            get
            {
                return new Location(Longitude, Latitude);//возвращает объект базового класса
            }
        }
        public City BaseCity
        {
            get
            {
                return new City(Longitude, Latitude, CityName, CountryName, PopulationCount);//возвращает объект базового класса
            }
        }

        public override string ToString()
        {
            return $"{Longitude}:{Latitude}:{CityName}:{CountryName}:{PopulationCount}:{CityArea}";
        }
    }
}
