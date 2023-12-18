using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LocationLibrary;

namespace LaboratoryWork_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCollections cols = new TestCollections(1000);
            Stopwatch stopWatch = new Stopwatch();
            long firstCollectionTime;
            long secondCollectionTime;

            void printTimeList(List<Address> list1, List<string> list2, Address address)
            {
                bool firstFound;

                //ПОДСЧЁТ ВРЕМЕНИ
                stopWatch = Stopwatch.StartNew();
                firstFound = list1.Contains(address);
                stopWatch.Stop();
                firstCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("List<Address>\tTime " + firstCollectionTime);
                Console.Write(firstFound ? " \t  Найдено\n" : " \t  Не найдено\n");

                string addressString = address.ToString();
                bool IsSecondFound;

                //ПОДСЧЁТ ВРЕМЕНИ
                stopWatch = Stopwatch.StartNew();
                IsSecondFound = list2.Contains(addressString);
                stopWatch.Stop();
                secondCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("List<string>\tTime " + secondCollectionTime);
                Console.WriteLine(IsSecondFound ? " \t  Найдено\n" : " \t  Не найдено\n");
            }

            void printTimeDict(SortedDictionary<Location, Address> sd1,
                SortedDictionary<string, Address> sd2, Address address1, Address address2)
            {
                bool firstFound, secondFound;
                Console.WriteLine("Поиск по ключу");
                Location addressBase1 = address1.BaseLocation;
                Location addressBase2 = address2.BaseLocation;

                //ПОДСЧЁТ ВРЕМЕНИ
                stopWatch = Stopwatch.StartNew();
                firstFound = sd1.ContainsKey(addressBase1);
                stopWatch.Stop();

                firstCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("SortedDictionary<Location, Address>\tTime " + firstCollectionTime);
                Console.Write(firstFound ? " \t  Найдено\n" : " \t  Не найдено\n");

                string addressBaseString = addressBase2.ToString();

                //ПОДСЧЁТ ВРЕМЕНИ
                stopWatch = Stopwatch.StartNew();
                secondFound = sd2.ContainsKey(addressBaseString);
                stopWatch.Stop();

                secondCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("SortedDictionary<string, Address>\tTime " + secondCollectionTime);
                Console.WriteLine(secondFound ? " \t  Найдено\n" : " \t  Не найдено\n");

                Console.WriteLine("Поиск по значению");

                stopWatch = Stopwatch.StartNew();
                firstFound = sd1.ContainsValue(address1);
                stopWatch.Stop();
                firstCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("SortedDictionary<Location, Address>\tTime " + firstCollectionTime);
                Console.Write(firstFound ? " \t  Найдено\n" : " \t  Не найдено\n");

                string AddressString = address2.ToString();

                stopWatch = Stopwatch.StartNew();
                secondFound = sd2.ContainsValue(address2);
                stopWatch.Stop();
                secondCollectionTime = stopWatch.ElapsedTicks;
                Console.Write("SortedDictionary<string, Address>\tTime " + secondCollectionTime);
                Console.WriteLine(secondFound ? " \t  Найдено\n" : " \t  Не найдено\n");
            }

            Console.WriteLine("Сравнение List<Address> и List<string>\n");
            Console.WriteLine("\tПоиск первого элемента");
            Address firstRef = cols.listAddress.First();
            Address first = new Address(firstRef.Longitude,
                firstRef.Latitude,
                firstRef.Subject,
                firstRef.City,
                firstRef.Locality,
                firstRef.Street,
                firstRef.House);

            printTimeList(cols.listAddress, cols.listString, first);

            Console.WriteLine("\tПоиск центрального элемента");
            Address midRef = cols.listAddress[cols.listAddress.Count / 2];
            Address mid = new Address(midRef.Longitude,
                midRef.Latitude,
                midRef.Subject,
                midRef.City,
                midRef.Locality,
                midRef.Street,
                midRef.House);

            printTimeList(cols.listAddress, cols.listString, mid);

            Console.WriteLine("\tПоиск последнего элемента");
            Address lastRef = cols.listAddress.Last();
            Address last = new Address(lastRef.Longitude,
                lastRef.Latitude,
                lastRef.Subject,
                lastRef.City,
                lastRef.Locality,
                lastRef.Street,
                lastRef.House);

            printTimeList(cols.listAddress, cols.listString, last);

            Console.WriteLine("\tПоиск несуществующего");
            Address nonExistent = new Address(lastRef.Longitude,
                lastRef.Latitude,
                "МЕНЯ НЕ СУЩЕСТВУЕТ",
                lastRef.City,
                lastRef.Locality,
                lastRef.Street,
                lastRef.House);

            printTimeList(cols.listAddress, cols.listString, nonExistent);

            //-------------------------------------------------------------------------//

            Console.WriteLine("\nСравнение SortedDictionary<Location, Address> и SortedDictionary<string, Address>\n");
            Console.WriteLine("\tПоиск первого элемента");
            firstRef = cols.sdLocation.First().Value;
            first = new Address(firstRef.Longitude,
                firstRef.Latitude,
                firstRef.Subject,
                firstRef.City,
                firstRef.Locality,
                firstRef.Street,
                firstRef.House);
            firstRef = cols.sdString.First().Value;
            Address first2 = new Address(firstRef.Longitude,
                firstRef.Latitude,
                firstRef.Subject,
                firstRef.City,
                firstRef.Locality,
                firstRef.Street,
                firstRef.House);

            printTimeDict(cols.sdLocation, cols.sdString, first, first2);

            Console.WriteLine("\tПоиск центрального элемента");
            midRef = cols.sdLocation.ToArray()[cols.sdLocation.Count / 2].Value;
            mid = new Address(midRef.Longitude,
                midRef.Latitude,
                midRef.Subject,
                midRef.City,
                midRef.Locality,
                midRef.Street,
                midRef.House);
            midRef = cols.sdString.ToArray()[cols.sdString.Count / 2].Value;
            Address mid2 = new Address(midRef.Longitude,
                midRef.Latitude,
                midRef.Subject,
                midRef.City,
                midRef.Locality,
                midRef.Street,
                midRef.House);

            printTimeDict(cols.sdLocation, cols.sdString, mid, mid2);

            Console.WriteLine("\tПоиск последнего элемента");
            lastRef = cols.sdLocation.Last().Value;
            last = new Address(lastRef.Longitude,
                lastRef.Latitude,
                lastRef.Subject,
                lastRef.City,
                lastRef.Locality,
                lastRef.Street,
                lastRef.House);
            lastRef = cols.sdString.Last().Value;
            Address last2 = new Address(lastRef.Longitude,
                lastRef.Latitude,
                lastRef.Subject,
                lastRef.City,
                lastRef.Locality,
                lastRef.Street,
                lastRef.House);

            printTimeDict(cols.sdLocation, cols.sdString, last, last2);

            Console.WriteLine("\tПоиск несуществующего");
            nonExistent = new Address(lastRef.Longitude,
                lastRef.Latitude,
                "МЕНЯ НЕ СУЩЕСТВУЕТ",
                lastRef.City,
                lastRef.Locality,
                lastRef.Street,
                lastRef.House);

            printTimeDict(cols.sdLocation, cols.sdString, nonExistent, nonExistent);
        }
    }
}
