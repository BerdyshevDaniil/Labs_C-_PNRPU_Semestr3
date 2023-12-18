 using System;

namespace LocationLibrary
{
    public class City : Location
    {
        static int MinPopulationCount = 5000;
        static int MaxPopulationCount = 10000000;
        static string[] countries =  { "Абхазия", "Австралия", "Австрия", "Азербайджан", "Албания", "Алжир", "Ам. Виргинские острова", "Американское Самоа", "Ангола", "Андорра", "Антигуа и Барбуда",
                "Аргентина", "Армения", "Аруба", "Афганистан", "Багамы", "Бангладеш", "Барбадос", "Бахрейн", "Белиз", "Белоруссия", "Бельгия", "Бенин", "Бермудские Острова", "Болгария",
                "Боливия", "Бонэйр", "Босния и Герцеговина", "Ботсвана", "Бразилия", "Бр. Виргинские острова", "Бруней", "Буркина-Фасо", "Бурунди", "Бутан", "Вануату", "Ватикан", "Великобритания",
                "Венгрия","Венесуэла","Восточный Тимор","Вьетнам","Габон","Гаити","Гайана","Гамбия","Гана","Гватемала","Гвинея","Гвинея-Бисау","Германия","Гондурас","Гонконг","Гренада","Греция",
                "Грузия","Дания","Д.Р. Конго","Джерси","Джибути","Доминика","Доминикана","Египет","Замбия","Зимбабве","Израиль","Индия","Индонезия","Иордания","Ирак","Иран","Ирландия","Исландия",
                "Испания","Италия","Йемен","Кабо-Верде","Казахстан","Камбоджа","Камерун","Канада","Катар","Кения","Кипр","Киргизия","Кирибати","Китай","Колумбия","Кокосовые острова",
                "Коморские Острова","Конго","КНДР","Корея","Коста-Рика","Кот-д'Ивуар","Куба","Кувейт","Кюрасао","Лаос","Латвия","Лесото","Либерия","Ливан","Ливия","Литва","Лихтенштейн","Люксембург",
                "Маврикий","Мавритания","Мадагаскар","Македония","Малави","Малайзия","Мали","Мальта","Мальдивы","Марокко","Маршалловы Острова","Мексика","Мозамбик","Молдавия (Молдова)","Монако",
                "Монголия","Мьянма","Намибия","Науру","Непал","Нигер","Нигерия","Нидерланды","Никарагуа","Новая Зеландия","Норвегия","ОАЭ","Оман","Острова Кука","Пакистан","Палау","Панама",
                "Папуа-Новая Гвинея","Парагвай","Перу","Пуэрто-Рико","Польша","Португалия","Россия","Руанда","Румыния","Саба","Сальвадор","Самоа","Сан-Марино","Сан-Томе и Принсипи",
                "Саудовская Аравия","Свазиленд","Сейшелы","Сенегал","Сент-Винсент и Гренадины","Сент-Китс и Невис","Сент-Люсия","Сен-Мартен","Сербия","Сингапур","Синт-Эстатиус","Сирия","Словакия",
                "Словения","США","Соломоновы Острова","Сомали","Судан","Суринам","Сьерра-Леоне","Таджикистан","Таиланд","Танзания","ТогоТокелау","ТонгаТринидад и Тобаго","Тувалу","Тунис",
                "Туркменистан","Турция","Уганда","Узбекистан","Украина","Уоллис и Футуна","Уругвай","Фарерские острова","Фед. Штаты Микронезии","Фиджи","Филиппины","Финляндия","Фолклендские острова",
                "Франция","Французская Полинезия","Хорватия","ЦАР","Чад","Черногория","Чехия","Чили","Швейцария","Швеция","Шри-Ланка","Эквадор","Экваториальная Гвинея","Эритрея","Эстония","Эфиопия",
                "ЮАР","Южный Судан","Ямайка","Япония" };
        protected string cityName;
        protected string countryName;
        protected int populationCount;
        virtual public string CityName { get; set; }
        virtual public string CountryName { get; set; }
        virtual public int PopulationCount
        {
            get { return populationCount; }
            set
            {
                if (value >= MinPopulationCount)
                    populationCount = value;
            }
        }
        public City() : base()
        {
            CountryName = "Не определена";
            CityName = "Не определён";
            PopulationCount = MinPopulationCount;
        }
        public City(double longitude, double latitude, string city, string country, int population) : base(longitude, latitude)
        {
            CountryName = country;
            CityName = city;
            PopulationCount = population;
        }
        public override void Show()
        {
            Console.WriteLine("\t\"Город\"");
            base.Show();
            Console.WriteLine($"Страна: {CountryName}\nГород: {CityName}\nНаселение: {PopulationCount}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите название страны: ");
            CountryName = Console.ReadLine();
            Console.WriteLine("Введите название города: ");
            CityName = Console.ReadLine();
            int pCount = CustomFunctions.InputInteger("Введите число населения: ");
            CustomFunctions.CheckNumber(MinPopulationCount, MaxPopulationCount, ref pCount);
            PopulationCount = pCount;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            CountryName = countries[random.Next(0, countries.Length - 1)];
            CityName = RandomCity();
            PopulationCount = random.Next(MinPopulationCount, MaxPopulationCount);
        }
        private string RandomCity()
        {
            char[] firstChars = { 'Ц','У','К','Е','Н','Г','Ш','З','Х','Ф','В','А','П','Р','О','Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Б', 'Ю'};
            char[] secondChars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            string[] endings = { "берг", "град", "поль", "дорф", "штадт", "вальд", "фельд", "хаузен" };
            string result = firstChars[random.Next(0, firstChars.Length - 1)].ToString();
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                result += secondChars[random.Next(0, secondChars.Length - 1)].ToString();
            }
            result += endings[random.Next(0, endings.Length - 1)];
            return result;

        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                City ct = (City)obj;
                return (Longitude == ct.Longitude) && (Latitude == ct.Latitude) && (CountryName == ct.CountryName) && (CityName == ct.CityName) && (PopulationCount == ct.PopulationCount);
            }
        }
        public City ShallowCopy() //поверхностное копирование
        {
            return (City)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new City(this.Longitude, this.Latitude, "(Копия)" + this.CityName, this.CountryName, this.PopulationCount);
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
            return $"{Longitude}:{Latitude}:{CityName}:{CountryName}:{PopulationCount}";
        }
    }
}
