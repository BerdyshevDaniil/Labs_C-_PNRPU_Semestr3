using System;

namespace Task_2 {
    internal class Program {
        static double InputDouble()
        {
            double input;
            bool isDouble = Double.TryParse(Console.ReadLine(), out input);
            while (!isDouble)
            {
                Console.WriteLine("Input error! Try again:");
                isDouble = Double.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static void Main(string[] args) 
        {
            double x1, y1; // Исходные данные
            Console.WriteLine("Enter x1:");
            x1 = InputDouble();
            Console.WriteLine("Enter y1:");
            y1 = InputDouble();
            bool isInArea = (y1 <= 0) && (Math.Pow(x1, 2) + Math.Pow(y1, 2) <= 1);
            Console.WriteLine($"isInArea = {isInArea}");
        }
    }
}

