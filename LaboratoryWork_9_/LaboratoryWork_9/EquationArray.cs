using System;

namespace LaboratoryWork_9
{
    public class EquationArray
    {
        private Equation[] equations;
        private static int count;
        public Equation[] Equations
        {
            get { return equations; }
            set { equations = value; }
        }
        public static int Count
        {
            get { return count; }
            private set { count = value; }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Equation this[int index]
        {
            get
            {
                if (index >= 0 && index < equations.Length)
                    return equations[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < equations.Length)
                    equations[index] = value;
            }
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public EquationArray()
        {
            equations = new Equation[0];
            count++;
        }
        /// <summary>
        /// Конструктор с параметрами, заполняемый пользователем с консоли
        /// </summary>
        /// <param name="size">Размер массива (количество уравнений)</param>
        public EquationArray(int size)
        {
            equations = new Equation[size];
            Console.WriteLine("Создание массива уравнений:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Уравнение {i+1}:");
                equations[i] = new Equation();
                Console.WriteLine("Введите коэффициент A:");
                equations[i].A = Program.InputDouble();
                Console.WriteLine("Введите коэффициент B:");
                equations[i].B = Program.InputDouble();
                Console.WriteLine("Введите коэффициент C:");
                equations[i].C = Program.InputDouble();
            }
            count++;
        }
        /// <summary>
        /// Конструктор с параметрами, заполняемый случайными числами в определённых границах
        /// </summary>
        /// <param name="size">Размер массива (количество уравнений)</param>
        /// <param name="lowerBound">Нижняя граница значений</param>
        /// <param name="upperBound">Верхняя граница значений</param>
        public EquationArray(int size, int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound)
                (lowerBound, upperBound) = (upperBound, lowerBound);
            equations = new Equation[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                equations[i] = new Equation();
                equations[i].A = (double) rand.Next(lowerBound * 10 + rand.Next(0, 10), upperBound * 10 - rand.Next(0, 10) + 1) / 10;
                equations[i].B = (double) rand.Next(lowerBound * 10 + rand.Next(0, 10), upperBound * 10 - rand.Next(0, 10) + 1) / 10;
                equations[i].C = (double) rand.Next(lowerBound * 10 + rand.Next(0, 10), upperBound * 10 - rand.Next(0, 10) + 1) / 10;
            }
            count++;
        }
        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="array"></param>
        public EquationArray(EquationArray array)
        {
            equations = new Equation[array.equations.Length];
            for (int i = 0; i < array.equations.Length; i++)
            {
                equations[i] = new Equation(array.equations[i]);
            }
            count++;
        }
        /// <summary>
        /// Вывод уравнений и их решений
        /// </summary>
        public void Print()
        {
            if (equations.Length > 0)
                foreach (Equation i in equations)
                {
                    i.Print();
                    i.PrintSolveEquation();
                }
            else
                Console.WriteLine("Массив пуст!");
        }
    }
}
