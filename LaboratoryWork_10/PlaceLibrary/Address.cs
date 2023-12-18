using System;
using System.Xml.Linq;

namespace LocationLibrary
{
    public class Address : Location
    {
        protected const int MaxHouseNumber = 100;
        static private string[,] subjects = {
    {"Республика Адыгея", "Республика Алтай", "Республика Башкортостан", "Республика Бурятия", "Республика Дагестан",
    "Республика Ингушетия", "Кабардино-Балкарская Республика", "Республика Калмыкия", "Карачаево-Черкесская Республика",
    "Республика Карелия", "Республика Коми", "Республика Крым", "Республика Марий-Эл", "Республика Мордовия",
    "Республика Саха (Якутия)", "Республика Северная Осетия", "Республика Татарстан", "Республика Тыва",
    "Удмуртская Республика", "Республика Хакасия", "Чеченская Республика", "Чувашская Республика", "Алтайский Край",
    "Забайкальский Край", "Камчатский Край", "Краснодарский Край", "Красноярский Край", "Пермский Край",
    "Приморский Край", "Ставропольский Край", "Хабаровский Край", "Амурская область", "Архангельская область",
    "Астраханская область", "Белгородская область", "Брянская область", "Владимирская область", "Волгоградская область",
    "Вологодская область", "Воронежская область", "Ивановская область", "Иркутская область", "Калининградская область",
    "Калужская область", "Кемеровская область (Кузбасс)", "Кировская область", "Костромская область", "Курганская область",
    "Курская область", "Ленинградская область", "Липецкая область", "Магаданская область", "Московская область",
    "Мурманская область", "Нижегородская область", "Новгородская область", "Новосибирская область", "Омская область",
    "Оренбургская область", "Орловская область", "Пензенская область", "Псковская область", "Ростовская область",
    "Рязанская область", "Самарская область", "Саратовская область", "Сахалинская область", "Свердловская область",
    "Смоленская область", "Тамбовская область", "Тверская область", "Томская область", "Тульская область",
    "Тюменская область", "Ульяновская область", "Челябинская область", "Ярославская область", "Еврейская АО",
    "Ненецкий АО", "Ханты-Мансийский АО (Югра)", "Чукотский АО", "Ямало-Ненецкий АО"},
    {"Майкоп", "Горно-Алтайск", "Уфа", "Улан-Удэ", "Махачкала", "Магас", "Нальчик", "Элиста", "Черкесск",
    "Петрозаводск", "Сыктывкар", "Симферополь", "Йошкар-Ола", "Саранск", "Якутск", "Владикавказ", "Казань",
    "Кызыл", "Ижевск", "Абакан", "Грозный", "Чебоксары", "Барнаул", "Чита", "Петропавловск-Камчатский",
    "Краснодар", "Красноярск", "Пермь", "Владивосток", "Ставрополь", "Хабаровск", "Благовещенск", "Архангельск",
    "Астрахань", "Белгород", "Брянск", "Владимир", "Волгоград", "Вологда", "Воронеж", "Иваново", "Иркутск",
    "Калининград", "Калуга", "Кемерово", "Киров", "Кострома", "Курган", "Курск", "Гатчина", "Липецк",
    "Магадан", "Москва", "Мурманск", "Нижний Новгород", "Великий Новгород", "Новосибирск", "Омск", "Оренбург",
    "Орел", "Пенза", "Псков", "Ростов-на-Дону", "Рязань", "Самара", "Саратов", "Южно-Сахалинск", "Екатеринбург",
    "Смоленск", "Тамбов", "Тверь", "Томск", "Тула", "Тюмень", "Ульяновск", "Челябинск", "Ярославль",
    "Биробиджан", "Нарьян-Мар", "Ханты-Мансийск", "Анадырь", "Салехард"} };
        static private string[] streets = {
    "Центральная",
    "Молодежная",
    "Школьная",
    "Лесная",
    "Советская",
    "Новая",
    "Садовая",
    "Набережная",
    "Заречная",
    "Зеленая",
    "Мира"
};
        protected string subject;  // субъект
        protected string city;     // город
        protected string locality; // населенный пункт
        protected string street;   // улица
        protected int house;       // дом
        public string Subject { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public int House
        {
            get { return house; }
            set { if (value > 0) 
                    house = value; }
        }
        public Address() : base()
        {
            Subject = "Не определён";
            City = "Не определён";
            Locality = "";
            Street = "Не определена";
            House = 404;
        }
        public Address(double longitude, double latitude, string subject, string city, string locality, string street, int house) : base(longitude, latitude)
        {
            Subject = subject;
            City = city;
            Locality = locality;
            Street = street;
            House = house;
        }
        public override void Show()
        {
            Console.WriteLine("\t\"Адрес\"");
            base.Show();
            Console.Write($"Субъект: {Subject}, город {City}, ");
            if (Locality != "")
                Console.Write($"населенный пункт {Locality}, ");
            Console.WriteLine($"улица {Street}, дом {House}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите название субъекта");
            Subject = Console.ReadLine();
            Console.WriteLine("Введите навзание города");
            City = Console.ReadLine();
            Console.WriteLine("Введите название населённого пункта (если нет, то нажмите Enter)");
            Locality = Console.ReadLine();
            Console.WriteLine("Введите название улицы");
            Street = Console.ReadLine();
            int tempHouse = CustomFunctions.InputInteger("Введите номер дома: ");
            CustomFunctions.CheckNumber(1, MaxHouseNumber, ref tempHouse);
            House = tempHouse;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            int subjectIndex = random.Next(0, subjects.GetLength(1));
            Subject = subjects[0, subjectIndex];
            City = subjects[1, subjectIndex];
            Locality = "";
            Street = streets[random.Next(0, streets.Length)];
            House = random.Next(1, MaxHouseNumber);
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Address ad = (Address)obj;
                return (Longitude == ad.Longitude) && (Latitude == ad.Latitude) && (Subject == ad.Subject) && (City == ad.City) && (Locality == ad.Locality) && (Street == ad.Street) && (House == ad.House);
            }
        }

        public Address ShallowCopy() //поверхностное копирование
        {
            return (Address)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Address(this.Longitude, this.Latitude, "(Копия)" + this.Subject, this.City, this.Locality, this.Street, this.House);
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
            return $"{Longitude}:{Latitude}:{Subject}:{City}:{Locality}:{Street}:{House}";
        }
    }
}
