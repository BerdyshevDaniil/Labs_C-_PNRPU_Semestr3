using System;

namespace LaboratoryWork_9
{
    public class Program
    {
        public static double InputDouble()
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
        /// <summary>
        /// Вычисление корней уравнения
        /// </summary>
        /// <param name="eq"></param>
        static void PrintSolveEquation(Equation eq)  
        {
            double x1, x2;
            double discriminant = Math.Pow(eq.B, 2) - 4 * eq.A * eq.C;
            if (discriminant < 0)
            {
                Console.WriteLine("Нет решений уравнения!");
            }
            else if (eq.A == 0 && eq.B == 0)
            {
                if (eq.C == 0)
                    Console.WriteLine("Бесконечное количество решений уравнения!");
                else
                    Console.WriteLine("Нет решений уравнения!");
            }
            else if (discriminant == 0)
            {
                x1 = (0 - eq.B) / (2 * eq.A);
                Console.WriteLine($"Решение:\nx = {x1}");
            }
            else if (discriminant > 0 && eq.A != 0)
            {
                x1 = (0 - eq.B - Math.Sqrt(discriminant)) / (2 * eq.A);
                x2 = (0 - eq.B + Math.Sqrt(discriminant)) / (2 * eq.A);
                Console.WriteLine($"Решение:\nx1 = {x1}\nx2 = {x2}");
            }
            else if (discriminant > 0 && eq.A == 0)
            {
                x1 = (0 - eq.C) / (eq.B);
                Console.WriteLine($"Решение:\nx = {x1}");
            }
        }
        /// <summary>
        /// Нахождение уравнения с самым большим по абсолютному значению корнем
        /// </summary>
        /// <param name="array">Список уравнений</param>
        /// <returns></returns>
        public static Equation FindMaxAbsRoot(EquationArray array)
        {
            if (array == null || array.Equations.Length == 0)
                return null;
            Equation maxEquation = array.Equations[0];
            for (int i = 0; i < array.Equations.Length; i++)
            {
                if (array.Equations[i] > maxEquation)
                    maxEquation = array.Equations[i];
            }
            return maxEquation;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t\tЧАСТЬ 1");
            Console.WriteLine($"Количество созданных экземпляров класса: {Equation.Count}\n");

            Console.WriteLine("Создание конструктором с параметрами:");
            Equation eq1 = new Equation(1, -1, -6);
            eq1.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {Equation.Count}\n");

            Console.WriteLine("Создание конструктором без параметров параметрами:");
            Equation eq2 = new Equation();
            eq2.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {Equation.Count} \n");

            Console.WriteLine("Создание конструктором копирования:");
            Equation eq3 = new Equation(eq1);
            eq3.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {Equation.Count} \n");

            Console.WriteLine("\tРешение уравнений:");
            eq1.Print();
            eq1.PrintSolveEquation();
            PrintSolveEquation(eq1);
            eq2.Print();
            eq2.PrintSolveEquation();
            PrintSolveEquation(eq2);
            eq3--;
            eq3.Print();
            eq3.PrintSolveEquation();
            PrintSolveEquation(eq3);

            Console.WriteLine(@"
        ЧАСТЬ 2
    Унарные операции:
До инкрементирования (++):");
            eq3.Print();
            eq3++;
            Console.WriteLine("После:");
            eq3.Print();
            Console.WriteLine("До декрементирования (--):");
            eq2.Print();
            eq2--;
            Console.WriteLine("После:");
            eq2.Print();

            Console.WriteLine(@"
    Операции приведения типа:
double (неявная):");
            eq2++;
            eq3.C = 35;
            eq1.Print();
            eq1.PrintSolveEquation();
            Console.WriteLine($"(double)eq1 = {(double)eq1}");
            eq2.Print();
            eq2.PrintSolveEquation();
            Console.WriteLine($"(double)eq1 = {(double)eq2}");
            eq3.Print();
            eq3.PrintSolveEquation();
            Console.WriteLine($"(double)eq1 = {(double)eq3}");
            Console.WriteLine("\nbool (явная):");
            eq1.Print();
            eq1.PrintSolveEquation();
            Console.WriteLine($"(bool)eq1 = {(bool)eq1}");
            eq2.Print();
            eq2.PrintSolveEquation();
            Console.WriteLine($"(bool)eq2 = {(bool)eq2}");
            eq3.Print();
            eq3.PrintSolveEquation();
            Console.WriteLine($"(bool)eq3 = {(bool)eq3}");

            Console.WriteLine("\n\tБинарные операции:");
            eq3.C = -6;
            eq1.Print();
            eq2.Print();
            eq3.Print();
            Console.WriteLine($"eq1 == eq2: {eq1 == eq2}");
            Console.WriteLine($"eq1 != eq2: {eq1 != eq2}");
            Console.WriteLine($"eq1 == eq3: {eq1 == eq3}");
            Console.WriteLine($"eq1 != eq3: {eq1 != eq3}");

            Console.WriteLine(@"
        ЧАСТЬ 3
    Конструкторы:
С параметрами (заполнение вручную):");
            Console.WriteLine($"Количество созданных экземпляров класса: {EquationArray.Count}\n");
            EquationArray equationArray = new EquationArray(2);
            equationArray.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {EquationArray.Count}\n");
            Console.WriteLine("С параметрами (случайными числами):");
            EquationArray equationArrayRnd = new EquationArray(3, -50, 50);
            equationArrayRnd.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {EquationArray.Count}\n");
            Console.WriteLine("Без параметров: ");
            EquationArray equationArrayWithoutParameters = new EquationArray();
            equationArrayWithoutParameters.Print();
            Console.WriteLine($"Количество созданных экземпляров класса: {EquationArray.Count}\n");

            Console.WriteLine("\n\tИндексатор");
            equationArrayRnd[1].Print();
            try
            {
                equationArray[5].Print();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ошибка: выход за границы массива!");
            }

            Console.WriteLine("\n\tНахождение уравнения с самым большим по абсолютному значению корнем");
            equationArrayRnd.Print();
            Equation equation = FindMaxAbsRoot(equationArrayRnd);
            equation.Print();
            equation.PrintSolveEquation();
        }
    }
}
