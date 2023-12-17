using System;

namespace Task_1
{
    internal class Program
    {
        static int InputInteger(string msg)
        {
            int input;
            Console.WriteLine(msg);
            bool isInteger = Int32.TryParse(Console.ReadLine(), out input);
            while (!isInteger)
            {
                Console.WriteLine("Input error! Try again:");
                isInteger = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static double InputDouble(string msg)
        {
            double input;
            Console.WriteLine(msg);
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
            int n, m; // Исходные
            double x; //  данные
            int res1;
            bool res2, res3;
            double res4;

            n = InputInteger("Enter n:");
            m = InputInteger("Enter m:");
            res1 = m - ++n;
            Console.WriteLine($"n = {n}, m = {m}, m - ++n = {res1};");
            res2 = m++ > --n;
            Console.WriteLine($"n = {n}, m = {m}, m++ > --n = {res2};");
            res3 = m-- < ++n;
            Console.WriteLine($"n = {n}, m = {m}, m-- < ++n = {res3};");

            x = InputDouble("Enter x:");
            while (x > -1 && x < 0)
            {
                Console.WriteLine("Invalid x value!");
                Console.WriteLine("Enter x:");
                x = InputDouble("Enter x:");
            }
            res4 = 25 * Math.Pow(x, 5) - Math.Pow(Math.Pow(x, 2) + x, 0.5);
            Console.WriteLine($"25 * x^5 - sqrt(x^2 + x) = {res4}");
        }
    }
}