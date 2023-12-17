using System;

namespace LaboratoryWork_5
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
        static void ShowMenu()
        {
            Console.WriteLine("\t\tМеню");
            Console.WriteLine("0 - Завершение работы программы");
            Console.WriteLine("1 - Работа с одномерными массивами");
            Console.WriteLine("2 - Работа с двумерными массивами");
            Console.WriteLine("3 - Работа с рваными массивоми");
        }
        static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(intercept: true);
        }
        // ОДНОМЕРНЫЙ МАССИВ
        static void FillArray(int[] array)
        {
            int fillingMethod = InputInteger("Выберете способ заполнения:\n1 - случайными числами\n2 - вручную");
            CheckNumber(1, 2, ref fillingMethod);
            if (fillingMethod == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < array.Length; ++i)
                    array[i] = rand.Next(-50, 50);
            }
            if (fillingMethod == 2)
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    array[i] = InputInteger("Введите элемент массива (от -50 до 50): ");
                    CheckNumber(-50, 50, ref array[i]);
                }
            }
        }
        static void PrintArray(int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Console.WriteLine("Одномерный массив:");
            string row = "";
            foreach (int i in array)
                row = row + i + '\t';
            Console.WriteLine(row);
        }
        static void DeleteElemens(int startElement, int elementsCount, ref int[] array)
        {
            int[] newArray = new int[array.Length - elementsCount];
            int j = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (!(i >= startElement && i <= startElement + elementsCount - 1))
                {
                    newArray[j] = array[i];
                    ++j;
                }
            }
            array = newArray;
        }

        // ДВУМЕРНЫЙ МАССИВ
        /// <summary>
        /// заполнение массива
        /// </summary>
        /// <param name="array">массив, который заполняется</param>
        static void FillArray(int[,] array)
        {
            int fillingMethod = InputInteger("Выберете способ заполнения:\n1 - случайными числами\n2 - вручную");
            CheckNumber(1, 2, ref fillingMethod);
            if (fillingMethod == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                        array[i, j] = rand.Next(-50, 50);
                }
            }
            if (fillingMethod == 2)
            {
                for (int i = 0; i < array.GetLength(0); ++i)
                {
                    for (int j = 0; j < array.GetLength(1); ++j)
                    {
                        array[i, j] = InputInteger("Введите элемент массива (от -50 до 50): ");
                        CheckNumber(-50, 50, ref array[i, j]);
                    }
                }
            }
        }
        static void PrintArray(int[,] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Console.WriteLine("Двумерный массив:");
            string row = "";
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                    row = row + array[i, j] + '\t';
                Console.WriteLine(row);
                row = "";
            }
        }
        static void AddColumn(ref int[,] array)
        {
            int[,] newArray = new int[array.GetLength(0), array.GetLength(1) + 1];
            int fillingMethod = InputInteger("Выберете способ заполнения:\n1 - случайными числами\n2 - вручную");
            CheckNumber(1, 2, ref fillingMethod);
            if (fillingMethod == 1)
            {
                Random rand = new Random();
                for (int i = 0; i < newArray.GetLength(0); ++i)
                {
                    for (int j = 0; j < newArray.GetLength(1); ++j)
                    {
                        if (j == 0)
                            newArray[i, j] = rand.Next(-50, 50);
                        else
                            newArray[i, j] = array[i, j - 1];
                    }
                }
            }
            if (fillingMethod == 2)
            {
                for (int i = 0; i < newArray.GetLength(0); ++i)
                {
                    for (int j = 0; j < newArray.GetLength(1); ++j)
                    {
                        if (j == 0)
                            newArray[i, j] = InputInteger("Введите новый элемент массива: ");
                        else
                            newArray[i, j] = array[i, j - 1];
                    }
                }
            }
            array = newArray;
        }

        // РВАНЫЙ МАССИВ
        static void FillArray(int[][] array)
        {
            int rows = InputInteger("Введите количество строк");
            array = new int[rows][];
            CheckNumber(1, 20, ref rows);
            for (int i = 0; i < rows; i++)
            {
                int columns = InputInteger($"Введите количество элементов строки {i + 1}");
                CheckNumber(1, 20, ref columns);
                array[i] = new int[columns];
                FillArray(array[i]);
            }
        }
        static void PrintArray(int[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Console.WriteLine("Рваный массив:");
            string row = "";
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                    row = row + array[i][j] + '\t';
                Console.WriteLine(row);
                row = "";
            }
        }

        static void DeleteElemens(int lowerBound, int upperBound, ref int[][] array)
        {
            int[][] newArray = new int[array.Length - upperBound + lowerBound - 1][];
            int j = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (i < lowerBound || i > upperBound)
                {
                    newArray[j] = new int[array[i].Length];
                    for (int k = 0; k < array[i].Length; ++k)
                        newArray[j][k] = array[i][k];
                    ++j;
                }
            }
            array = newArray;
        }

        // МЕНЮ
        static void Menu()
        {
            int switchN, switchOperation;
            int[] oneDimensionalArray = { };
            int[,] twoDimensionalArray = { { }, { } };
            int[][] unevenArray = { };
            do
            {
                Console.Clear();
                ShowMenu();
                switchN = InputInteger();
                switch (switchN)
                {
                    case 0:
                        Console.WriteLine("Работа завершена!");
                        break;
                    case 1:
                        Console.Clear();
                        MenuOneDimensionalArray(ref oneDimensionalArray);
                        break;
                    case 2:
                        Console.Clear();
                        MenuTwoDimensionalArray(ref twoDimensionalArray);
                        break;
                    case 3:
                        Console.Clear();
                        MenuUnevenArray(ref unevenArray);
                        break;
                    default:
                        Console.WriteLine("Неправильно введено значение!");
                        Pause();
                        break;
                }
            } while (switchN != 0);
        }
        /// <summary>
        /// Меню одномерного массива
        /// </summary>
        /// <param name="oneDimensionalArray"></param>
        static void MenuOneDimensionalArray(ref int[] oneDimensionalArray)
        {
            int switchOperation;
            do
            {
                Console.Clear();
                switchOperation = InputInteger("0 - выйти в главное меню\n1 - Создать массив\n2 - Вывести массив\n3 - Удалить N элементов, начиная с номера K");
                CheckNumber(0, 3, ref switchOperation);
                if (switchOperation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (switchOperation == 1)
                {
                    int lengthArray = InputInteger("Введите длину массива: ");
                    CheckNumber(1, 50, ref lengthArray);
                    oneDimensionalArray = new int[lengthArray];
                    FillArray(oneDimensionalArray);
                    Console.WriteLine("Массив создан!");
                }
                if (switchOperation == 2)
                {
                    PrintArray(oneDimensionalArray);
                }
                if (switchOperation == 3)
                {
                    if (oneDimensionalArray.Length > 0)
                    {
                        int startElement = InputInteger("Введите элемент, с которого необходимо удалить:");
                        CheckNumber(1, oneDimensionalArray.Length, ref startElement);
                        int elementsCount = InputInteger("Введите количество элементов:");
                        CheckNumber(1, oneDimensionalArray.Length - startElement + 1, ref elementsCount);
                        --startElement;
                        DeleteElemens(startElement, elementsCount, ref oneDimensionalArray);
                        Console.WriteLine($"Элементы {startElement + 1}-{startElement + elementsCount} удалены!");
                    }
                    else Console.WriteLine("Массив пуст! Невозможно выполнить это действие!");
                }
                Pause();
            } while (switchOperation != 0);
        }
        /// <summary>
        /// Меню двумерного массива
        /// </summary>
        /// <param name="oneDimensionalArray"></param>
        static void MenuTwoDimensionalArray(ref int[,] twoDimensionalArray)
        {
            int switchOperation;
            do
            {
                Console.Clear();
                switchOperation = InputInteger("0 - выйти в главное меню\n1 - Создать массив\n2 - Вывести массив\n3 - Добавить столбец в начало матрицы");
                CheckNumber(0, 3, ref switchOperation);
                if (switchOperation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (switchOperation == 1)
                {
                    int rows = InputInteger("Введите количество строк: ");
                    CheckNumber(1, 20, ref rows);
                    int columns = InputInteger("Введите количество столбцов: ");
                    CheckNumber(1, 20, ref columns);
                    twoDimensionalArray = new int[rows, columns];
                    FillArray(twoDimensionalArray);
                    Console.WriteLine("Массив создан!");
                }
                if (switchOperation == 2)
                {
                    PrintArray(twoDimensionalArray);
                }
                if (switchOperation == 3)
                {
                    if (twoDimensionalArray.Length > 0)
                    {
                        AddColumn(ref twoDimensionalArray);
                        Console.WriteLine("Столбец добавлен!");
                    }
                    else Console.WriteLine("Массив пуст! невозможно выполнить это действие!");
                }
                Pause();
            } while (switchOperation != 0);
        }
        /// <summary>
        /// Меню рваного массива
        /// </summary>
        /// <param name="oneDimensionalArray"></param>
        static void MenuUnevenArray(ref int[][] unevenArray)
        {
            int switchOperation;
            do
            {
                Console.Clear();
                switchOperation = InputInteger("0 - выйти в главное меню\n1 - Создать массив\n2 - Вывести массив\n3 - Удалить строки начиная с номера K1 и заканчивая номером К2 включительно");
                CheckNumber(0, 3, ref switchOperation);
                if (switchOperation == 0)
                {
                    Console.WriteLine("Выход в меню");
                }
                if (switchOperation == 1)
                {
                    FillArray(unevenArray);
                    Console.WriteLine("Массив создан!");
                }
                if (switchOperation == 2)
                {
                    PrintArray(unevenArray);
                }
                if (switchOperation == 3)
                {
                    if (unevenArray.Length > 0)
                    {
                        int lowerBound = InputInteger("Введите строку с которой нужно удалить (удаление строк будет совершаться включительно)");
                        CheckNumber(1, unevenArray.Length, ref lowerBound);
                        int upperBound = InputInteger("Введите строку до которой нужно удалить (удаление строк будет совершаться включительно)");
                        CheckNumber(1, unevenArray.Length, ref upperBound);
                        --lowerBound; --upperBound;
                        if (lowerBound > upperBound)
                            (lowerBound, upperBound) = (upperBound, lowerBound);
                        DeleteElemens(lowerBound, upperBound, ref unevenArray);
                        Console.WriteLine($"Строки {lowerBound + 1}-{upperBound + 1} удалены!");
                    }
                    else Console.WriteLine("Массив пуст! Невозможно выполнить это действие!");
                }
                Pause();
            } while (switchOperation != 0);
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}