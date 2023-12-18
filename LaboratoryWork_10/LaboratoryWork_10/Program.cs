using System;
using LocationLibrary;

namespace LaboratoryWork_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*  Место: область, город, мегаполис, адрес */
            Menu();
        }

        static void Menu()
        {
            Location[] locations = new Location[25];
            for (int i = 0; i < 10; ++i)
            {
                locations[i] = new Address();
                locations[i].RandomInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                locations[i] = new City();
                locations[i].RandomInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                locations[i] = new Region();
                locations[i].RandomInit();
            }
            for (int i = 20; i < 25; ++i)
            {
                locations[i] = new Megacity();
                locations[i].RandomInit();
            }

            IInit[] inits = new IInit[20];
            for (int i = 0; i < 10; ++i)
            {
                inits[i] = new Animal();
                inits[i].RandomInit();
            }
            for (int i = 10; i < 15; ++i)
            {
                inits[i] = new Location();
                inits[i].RandomInit();
            }
            for (int i = 15; i < 20; ++i)
            {
                inits[i] = new City();
                inits[i].RandomInit();
            }
            int choice;
            do {
                Console.Clear();
                Console.Write("1. Первая часть (наследование и полиморфизм)\n" +
                    "2. Вторая часть (динамическая типизация)\n" +
                    "3. Третья часть (интерфейс)\n" +
                    "4. Выход\n");
                choice = CustomFunctions.InputInteger("Введите число: ");
                switch (choice)
                {
                    case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Демонстрация наследования");
                        Address ad = new Address();
                        ad.RandomInit();
                        City city = new City();
                        city.RandomInit();
                        Region reg = new Region();
                        reg.RandomInit();
                        Megacity mc = new Megacity();
                        mc.RandomInit();
                        Location[] demonstationLocations = { ad, city, reg, mc };
                        foreach (var l in demonstationLocations)
                        {
                            l.Show();
                        }
                        CustomFunctions.Pause();
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Console.Write("1. Количество адресов, находящихся в Северном полушарии \n" +
                            "2. Количество городов-многомиллиоников\n" +
                            "3. Количество адресов с улицей Мира\n");
                        int count = 0;
                        int choice1 = CustomFunctions.InputInteger();
                        CustomFunctions.CheckNumber(1, 3, ref choice1);
                        switch (choice1)
                        {
                            case 1:
                                count = CountNorthernHemisphereAddresses(locations);
                                Console.WriteLine(count);
                                break;
                            case 2:
                                count = CountMultimillionCities(locations);
                                Console.WriteLine(count);
                                break;
                            case 3:
                                count = CountSpecifiedStreetAddresses(locations, "Мира");
                                Console.WriteLine(count);
                                break;
                        }
                        CustomFunctions.Pause();
                        break;
                    }
                    case 3:
                    {
                        int choice1 = 0;
                        do
                        {
                            Console.Clear();
                            Console.Write("0. Вернуться к общему меню\n" +
                                "1. Отсортировать массив объектов по долготе (используя IComparable)\n" +
                                "2. Отсортировать массив объектов по широте (используя IComparer)\n" +
                                "3. Найти элемент, ближайщий к заданной долготе \n" +
                                "4. Просмотр массива элементов типа IInit\n" +
                                "5. Демонстрация работы методов клонирования IClonable\n");
                            choice1 = CustomFunctions.InputInteger();
                            CustomFunctions.CheckNumber(0, 5, ref choice1);
                            switch (choice1)
                            {
                                case 1:
                                    Array.Sort(locations);
                                    Console.WriteLine("Сортировка по долготе:");
                                    ShowLocations(locations);
                                    CustomFunctions.Pause();
                                    break;
                                case 2:
                                    Console.WriteLine("Сортировка по широте");
                                    Array.Sort(locations, new SortByLatitude());
                                    ShowLocations(locations);
                                    CustomFunctions.Pause();
                                    break;
                                case 3:
                                    double longitude = CustomFunctions.InputDouble("Введите долготу (значение от -180.0000 до 180.0000)");
                                    CustomFunctions.CheckNumber(-180, 180, ref longitude);
                                    Array.Sort(locations);
                                    var res = SearchBinary(locations, longitude);
                                    res.Show();
                                    CustomFunctions.Pause();
                                    break;
                                case 4:
                                    Console.WriteLine("Массив элементов типа IInit");
                                    foreach (var item in inits)
                                    {
                                        item.Show();
                                        Console.WriteLine();
                                    }
                                    CustomFunctions.Pause();
                                    break;
                                case 5:
                                    Address newItem = new Address();
                                    newItem.RandomInit();
                                    Address shallowCopyItem = CopyShallow(newItem);
                                    Address deepCopyItem = CopyDeep(newItem);

                                    Console.WriteLine("Поверхностное копирование (ShallowCopy):");
                                    shallowCopyItem.Show();

                                    Console.WriteLine("Глубокое копирование (Clone): ");
                                    deepCopyItem.Show();

                                    CustomFunctions.Pause();
                                    break;
                            }
                        } while (choice1 > 0);
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Завершение работы программы");
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Выберите из списка");
                        break;
                    }
                }
            } while (choice != 4);
        }
        /// <summary>
        /// Подсчёт адресов, находящихся в Северном полушарии
        /// </summary>
        /// <param name="locations">Массив местоположений (базовый класс для класса Address)</param>
        /// <returns></returns>
        public static int CountNorthernHemisphereAddresses(Location[] locations)
        {
            int count = 0;
            foreach (var item in locations)
            {
                if (item is Address)
                {
                    if (((Address)item).Latitude > 0)
                    {
                        count++;
                        item.Show();
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Подсчёт городов-многомиллиоников
        /// </summary>
        /// <param name="locations">Массив местоположений (базовый класс для класса City)</param>
        /// <returns></returns>
        public static int CountMultimillionCities(Location[] locations)
        {
            int count = 0;
            foreach (var item in locations)
            {
                if (item is City)
                {
                    if (((City)item).PopulationCount >= 2000000)
                    {
                        count++;
                        item.Show();
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Подсчёт адресов с заданной улицей
        /// </summary>
        /// <param name="locations">Массив местоположений (базовый класс для класса Address)</param>
        /// <param name="street">Заданная улица</param>
        /// <returns></returns>
        public static int CountSpecifiedStreetAddresses(Location[] locations, string street)
        {
            int count = 0;
            foreach (var item in locations)
            {
                if (item is Address)
                {
                    if (((Address)item).Street == street)
                    {
                        count++;
                        item.Show();
                    }
                }
            }
            return count;
        }
        public static void ShowLocations(Location[] locations)
        {
            foreach (var item in locations)
            {
                item.Show();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Бинарный поиск для массива типа Location[] по долготе (поле longitude). 
        /// Возвращает объект с ближайшей долготой к заданной
        /// </summary>
        /// <param name="loc">Массив, по которому проводится поиск</param>
        /// <param name="longitude">Заданная долгота</param>
        /// <returns></returns>
        public static Location SearchBinary(Location[] loc, double longitude)
        {
            int left = 0;
            int right = loc.Length - 1;
            int midle = (left + right) / 2;
            Array.Sort(loc);
            while (left <= right)
            {
                midle = (left + right) / 2;
                if (Math.Truncate(loc[midle].Longitude) == Math.Truncate(longitude))
                    return loc[midle];
                if (loc[midle].Longitude < longitude)
                    left = midle + 1;
                if (loc[midle].Longitude > longitude)
                    right = midle - 1;
            }

            if (loc.Length == 0)
                return null;
            else 
                if (midle == 0 && loc.Length > 1)
            {
                if (Math.Abs(longitude - loc[midle].Longitude) > Math.Abs(longitude - loc[midle + 1].Longitude))
                    return loc[midle + 1];
            }
            else 
                if (midle == loc.Length - 1 && loc.Length > 1)
            {
                if (Math.Abs(longitude - loc[midle].Longitude) > Math.Abs(longitude - loc[midle - 1].Longitude))
                    return loc[midle - 1];
            }
            else
                if (loc.Length > 2)
            {
                double midleIncr = Math.Abs(longitude - loc[midle + 1].Longitude);
                double midleDec = Math.Abs(longitude - loc[midle - 1].Longitude);
                if (midleIncr > midleDec)
                {
                    if (Math.Abs(longitude - loc[midle].Longitude) > midleDec)
                        midle = midle - 1;
                }
                else
                    if (Math.Abs(longitude - loc[midle].Longitude) > midleIncr)
                {
                    midle = midle + 1;
                }
            }
            return loc[midle];
        }
        public static Address CopyShallow(Address copyAddress)
        {
            return copyAddress.ShallowCopy();
        }
        public static Address CopyDeep(Address copyAddress)
        {
            return (Address)copyAddress.Clone();
        }
    }
}
