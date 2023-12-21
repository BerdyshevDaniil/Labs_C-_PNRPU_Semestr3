using System;
using System.Collections.Specialized;
using System.Linq;
using LocationLibrary;

namespace FunctionalCompleteness_Lab4
{
    public class Program
    {
        static string BoolToString(bool temp)
        {
            if (temp == true)
                return "+";
            return "-";
        }
        static void Main(string[] args)
        {
            int functionsCount = CustomFunctions.InputInteger("Введите количество функций");
            CustomFunctions.CheckNumber(1, 3, ref functionsCount);

            Function[] functionList = new Function[functionsCount];
            for (int i = 0; i < functionsCount; i++)
            {
                Console.WriteLine($"Введите строку вектора {i + 1} (размером 1, 2, 4 или 8):");
                string vec = Console.ReadLine();
                while (vec.Length != 1 && vec.Length != 2 && vec.Length != 4 && vec.Length != 8)
                {
                    Console.WriteLine("Некорректное количество символов! Попробуйте снова:");
                    vec = Console.ReadLine();
                }
                functionList[i] = new Function();
                for (int j = 0; j < vec.Length; j++)
                {
                    if (vec[j] == '1')
                        functionList[i].Values.Add(1);
                    else if (vec[j] == '0')
                        functionList[i].Values.Add(0);
                    else
                        functionList[i].Values.Add(0);
                }
                if (vec.Length == 1)
                    functionList[i].Values.Add(functionList[i].Values[0]);
            }
            bool[] isFull = { true, true, true, true, true };
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("\t|   T0\t|   T1\t|   T*\t|   Tm\t|   Tl\t|");
            for (int i = 0; i < functionsCount; i++)
            {
                Console.WriteLine($"   f{i+1}\t| {BoolToString(functionList[i].IsT0())}\t|   " +
                    $"{BoolToString(functionList[i].IsT1())}\t|   " +
                    $"{BoolToString(functionList[i].IsTSelfDual())}\t|   " +
                    $"{BoolToString(functionList[i].IsTMonotonous())}\t|   " +
                    $"{BoolToString(functionList[i].IsTLinear())}\t|");
                if (!functionList[i].IsT0())
                    isFull[0] = false;
                if (!functionList[i].IsT1())
                    isFull[1] = false;
                if (!functionList[i].IsTSelfDual())
                    isFull[2] = false;
                if (!functionList[i].IsTMonotonous())
                    isFull[3] = false;
                if (!functionList[i].IsTLinear())
                    isFull[4] = false;
            }
            if (isFull.Contains(true))
                Console.WriteLine("Система не функциональна полная");
            else
                Console.WriteLine("Система функционально полная");
        }
    }
}
