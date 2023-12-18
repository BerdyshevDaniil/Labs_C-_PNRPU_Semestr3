using System;

namespace LocationLibrary
{
    public class CustomFunctions
    {
        public static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(intercept: true);
        }
        public static double InputDouble(string stringForUser = "")
        {
            double input;
            if (stringForUser != "")
                Console.WriteLine(stringForUser);
            bool isDouble = Double.TryParse(Console.ReadLine(), out input);
            while (!isDouble)
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова:");
                isDouble = Double.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static public int InputInteger(string stringForUser = "")
        {
            int input;
            if (stringForUser != "")
                Console.WriteLine(stringForUser);
            bool isInteger = Int32.TryParse(Console.ReadLine(), out input);
            while (!isInteger)
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова:");
                isInteger = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static public void CheckNumber(int lowerBound, int upperBound, ref int value, string msgRepetitive = "Неверное значение! Попробуйте снова: ")
        {
            if (lowerBound > upperBound)
                (lowerBound, upperBound) = (upperBound, lowerBound);
            while (value < lowerBound || value > upperBound)
            {
                Console.WriteLine(msgRepetitive);
                value = InputInteger();
            }
        }
        static public void CheckNumber(double lowerBound, double upperBound, ref double value, string msgRepetitive = "Неверное значение! Попробуйте снова: ")
        {
            if (lowerBound > upperBound)
                (lowerBound, upperBound) = (upperBound, lowerBound);
            while (value < lowerBound || value > upperBound)
            {
                Console.WriteLine(msgRepetitive);
                value = InputDouble();
            }
        }
    }
}
