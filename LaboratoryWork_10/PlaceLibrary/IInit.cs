using System;
using System.Collections.Generic;

namespace LocationLibrary
{
    public interface IInit
    {
        void Show();
        void Init();
        void RandomInit();
    }
    public class Animal : IInit
    {
        string name;
        int weight;
        static Random random = new Random();

        public string Name { get; set; }
        public int Weight { get; set; }
        public Animal()
        {
            Name = "NULL";
            Weight = 0;
        }
        public Animal(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
        public void Init()
        {
            Console.WriteLine("\t\"Животное\"");
            Console.Write("Название животного: ");
            Name = Console.ReadLine();
            Weight = CustomFunctions.InputInteger("Введите вес (int): ");
        }
        public void RandomInit()
        {
            Name = RandomName();
            Weight = RandomWeight();
        }
        private string RandomName()
        {
            string[] words = { "Зебра", "Кошка", "Лев", "Кролик" };
            return words[random.Next(0, words.Length)];
        }
        private int RandomWeight()
        {
            return random.Next(5, 100);
        }

        public void Show()
        {
            Console.WriteLine("\t\"Животное\"");
            Console.WriteLine($"Название: {Name}\nВес:{Weight}");
        }
    }
}
