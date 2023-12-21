using System;
using System.IO;

namespace RelationsMatrix
{
    internal class Program
    {
        static int InputInteger(string stringForUser = "")
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
        static void CheckNumber(int lowerBound, int upperBound, ref int value, string msgRepetitive = "Неверное значение! Попробуйте снова: ")
        {
            if (lowerBound > upperBound)
                (lowerBound, upperBound) = (upperBound, lowerBound);
            while (value < lowerBound || value > upperBound)
            {
                Console.WriteLine(msgRepetitive);
                value = InputInteger();
            }
        }
        static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(intercept: true);
        }
        /// <summary>
        /// Заполнение массива
        /// </summary>
        /// <param name="array">массив, который заполняется</param>
        static void FillArray(int[,] array)
        {
            int fillingMethod = InputInteger("Выберете способ заполнения:\n1 - случайными числами\n2 - вручную\n3 - заполнить единицами\n4 - заполнить нулями");
            CheckNumber(1, 4, ref fillingMethod);
            if (fillingMethod == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                        array[i, j] = rand.Next(0, 2);
                }
            }
            if (fillingMethod == 2)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    Console.WriteLine($"Строка {i + 1}");
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        array[i, j] = InputInteger("Введите элемент матрицы (0 или 1): ");
                        CheckNumber(0, 1, ref array[i, j]);
                    }
                }
            }
            if (fillingMethod == 3)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                        array[i, j] = 1;
                }
            }
            if (fillingMethod == 4)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                        array[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// Печать массива
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(int[,] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Console.WriteLine("Матрица:");
            string row = "";
            Console.WriteLine("  1 2 3 4 5 6");
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                row = row + (i+1) + ' '; 
                for (int j = 0; j < array.GetLength(1); ++j)
                    row = row + array[i, j] + ' ';
                Console.WriteLine(row);
                row = "";
            }
        }
        /// <summary>
        /// Определение рефлексивности отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        static void DetermineReflexivity(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) {
                Console.WriteLine("Неверно введена матрица!");
                return;
            }
            int diagonalСount1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (matrix[i, j] == 1)
                            ++diagonalСount1;
                    }
                }
            }
            if (diagonalСount1 == matrix.GetLength(0))
                Console.WriteLine("Отношение рефлексивно");
            else if (diagonalСount1 == 0)
                Console.WriteLine("Отношение антирефлескивно");
            else
                Console.WriteLine("Отношение не рефлексивно");
        }
        /// <summary>
        /// Определение симметричености отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        static bool IsSymmetric(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((matrix[i, j] != matrix[j, i]) && (i != j))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Определение Антисимметричности отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        static bool IsAntiSymmetric(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((matrix[i, j] == 1) && (matrix[j, i] != 0) && (i != j))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Определение Асимметричности отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        static bool IsAsymmetric(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        if (matrix[i, j] != 0) 
                            return false;
                    }
                    else if ((matrix[i, j] == 1) && (matrix[j, i] != 0) && (i != j))
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Определение транзитивности отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        /// <returns></returns>
        static bool IsTransitive(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[j, k] == 1 && matrix[i, k] != 1)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Определение Антитранзитивности отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        /// <returns></returns>
        static bool IsAntiTransitive(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[j, k] == 1 && matrix[i, k] == 1)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Определение Полноты отношения
        /// </summary>
        /// <param name="matrix">Матрица отношения</param>
        /// <returns></returns>
        static bool IsConnectivity(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (((matrix[i, j] == 0 && matrix[j, i] == 0) && (i != j)))
                        return false;
                }
            }
            return true;
        }

        static void Menu(ref int[,] relation)
        {
            int switchOperation;
            string path = @"D:\repos\Diskretka\RelationsMatrix\RelationsMatrix\TextFile1.txt";
            do
            {
                Console.Clear();
                switchOperation = InputInteger("\t\tМеню\n0 - Выход из программы\n\n1 - Заполнить матрицу\n2 - Загрузить матрицу из файла\n3 - Изменить элемент матрицы\n\n"
                                                + "4 - Загрузить текущую матрицу в файл\n\n5 - Вывести массив\n6 - Вывести свойства");
                CheckNumber(0, 6, ref switchOperation);
                if (switchOperation == 1)
                {
                    FillArray(relation);
                    Console.WriteLine("Массив заполнен!");
                }
                if (switchOperation == 2)
                {
                    using (StreamReader reader = File.OpenText(path))
                    {
                        int j = 0;
                        for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                        {
                            string[] str = line.Split(' ');
                            for (int i = 0; i < str.Length; i++)
                            {
                                relation[j, i] = Convert.ToInt32(str[i]);
                            }
                            ++j;
                        }
                    }
                    Console.WriteLine("Матрица загружена!");
                    PrintArray(relation);
                }
                if (switchOperation == 3)
                {
                    int i = InputInteger("Введите номер строки");
                    CheckNumber(1, 6, ref i, "Номер строки может быть только от 1 до 6! Попробуйте снова: ");
                    int j = InputInteger("Введите номер столбца");
                    CheckNumber(1, 6, ref j, "Номер столбца может быть только от 1 до 6! Попробуйте снова: ");
                    relation[i - 1, j - 1] = relation[i - 1, j - 1] == 1
                        ? 0
                        : 1;
                    Console.WriteLine($"Элемент <{i},{j}> изменён на {relation[i - 1, j - 1]}!");
                }
                if (switchOperation == 4)
                {
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        for (int i = 0; i < relation.GetLength(0); i++)
                        {
                            for (int j = 0; j < relation.GetLength(1); j++)
                            {
                                writer.Write(relation[i, j]);
                                if (j != relation.GetLength(0) - 1)
                                    writer.Write(' ');
                            }
                            if (i != relation.GetLength(1) - 1)
                                writer.WriteLine();
                        }
                    }
                }
                if (switchOperation == 5)
                {
                    PrintArray(relation);
                }
                if (switchOperation == 6)
                {
                    PrintArray(relation);

                    DetermineReflexivity(relation);

                    if (IsSymmetric(relation) || IsAntiSymmetric(relation) || IsAsymmetric(relation))
                    {
                        if (IsSymmetric(relation))
                            Console.WriteLine("Отношение симметрично");
                        if (IsAntiSymmetric(relation))
                            Console.WriteLine("Отношение антисимметрично");
                        if (IsAsymmetric(relation))
                            Console.WriteLine("Отношение асимметрично");
                    }
                    else
                        Console.WriteLine("Отношение не симметрично");

                    if (IsTransitive(relation))
                        Console.WriteLine("Отношение транзитивно");
                    else if (IsAntiTransitive(relation))
                        Console.WriteLine("Отношение антитранзитивно");
                    else
                        Console.WriteLine("Отношение не транзитивно");
                    if (IsConnectivity(relation))
                        Console.WriteLine("Отношение связное");
                    else
                        Console.WriteLine("Отношение не связное");
                }
                Pause();
            } while (switchOperation != 0);
        }
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            int[,] relation = new int[6, 6];
            Menu(ref relation);
        }
    }
}
