using System;

namespace LaboratoryWork_9
{
    /// <summary>
    /// Класс, описывающий квадратное уравнение вида ax^2 + bx + c = 0
    /// </summary>
    public class Equation
    {
        private double a;
        private double b;
        private double c;
        private static int count;
        /// <summary>
        /// Коэффициент перед x^2
        /// </summary>
        public double A
        {
            get => a;
            set => a = value;
        }
        /// <summary>
        /// Коэффициент перед x
        /// </summary>
        public double B
        {
            get => b;
            set => b = value;
        }
        /// <summary>
        /// Свободный коэффициент
        /// </summary>
        public double C
        {
            get => c;
            set => c = value;
        }
        /// <summary>
        /// Счётчик созданных объектов класса
        /// </summary>
        public static int Count 
        {
            get { return count; }
            private set { count = value; }
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Equation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            ++Count;
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Equation()
        {
            A = 0;
            B = 0;
            C = 0;
            ++Count;
        }
        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="eq"></param>
        public Equation(Equation eq)
        {
            A = eq.A;
            B = eq.B;
            C = eq.C;
            ++Count;
        }
        /// <summary>
        /// Вывод коэффициентов уравнения
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Коэффиценты уравнения:\nA = {A}\tB = {B}\tC = {C}");
            //this.SolveEquation();
        }
        /// <summary>
        /// Метод, проверяющий, существуют ли корни уравнения
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            double discriminant = Math.Pow(B, 2) - 4 * A * C;
            if (discriminant < 0)
                return false;
            else if (A == 0 && B == 0 && C != 0)
                return false;
            return true;
        }
        /// <summary>
        /// Вычисление корней уравнения
        /// </summary>
        public bool SolveEquation(out double x1, out double x2)
        {
            double discriminant = Math.Pow(B, 2) - 4 * A * C;
            if (discriminant < 0)
            {
                x1 = Double.MinValue;
                x2 = Double.MinValue;
                return false;
            }
            else if (A == 0 && B == 0)
            {
                if (C == 0)
                {
                    x1 = Double.MaxValue;
                    x2 = Double.MaxValue;
                    return true;
                }
                else
                {
                    x1 = Double.MinValue;
                    x2 = Double.MinValue;
                    return false;
                }
            }
            else if (discriminant == 0)
            {
                x1 = x2 = (0 - B) / (2 * A);
                return true;
            }
            else if (discriminant > 0 && A != 0)
            {
                x1 = (0 - B - Math.Sqrt(discriminant)) / (2 * A);
                x2 = (0 - B + Math.Sqrt(discriminant)) / (2 * A);
                return true;
            }
            else if (discriminant > 0 && A == 0)
            {
                x1 = (0 - C) / (B);
                x2 = double.MinValue;
                return true;
            }
            x1 = Double.MinValue;
            x2 = Double.MinValue;
            return false;
        }
        public void PrintSolveEquation()
        {
            if (!this.IsExist())
            {
                Console.WriteLine("Нет решений уравнения!");
            }
            else
            {
                double x1, x2;
                SolveEquation(out x1, out x2);
                if (x1 == Double.MaxValue)
                    Console.WriteLine("Бесконечное количество решений уравнения!");
                else
                    if (x2 == Double.MinValue)
                        Console.WriteLine($"Решение уравнения:\nx = {x1}");
                else
                    if (x1 == x2)
                        Console.WriteLine($"Решение уравнения:\nx1 = x2 = {x1}");
                else
                    Console.WriteLine($"Решение уравнения:\nx1 = {x1}; x2 = {x2}");
            }
        }
        /// <summary>
        /// Инкрементирует коэффициенты уравнения
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public static Equation operator ++(Equation equation)
        {
            return new Equation(++equation.A, ++equation.B, ++equation.C);
        }
        /// <summary>
        /// Декрементирует коэффициенты уравнения
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public static Equation operator --(Equation equation)
        {
            return new Equation(--equation.A, --equation.B, --equation.C);
        }

        /// <summary>
        /// Приведение к типу double (Выводит максимальный по значению корень, если он есть; если корня нет или количество корней бесконечно - выводить 0
        /// </summary>
        /// <param name="equation"></param>
        public static implicit operator double(Equation equation)
        {
            if (equation.IsExist())
            {
                double discriminant = Math.Pow(equation.B, 2) - 4 * equation.A * equation.C;
                if (equation.A == 0 && equation.B == 0 && equation.C == 0)
                    return Double.MaxValue;
                if (equation.A == 0)
                    return (0 - equation.C) / (equation.B);
                return
                    Math.Max((0 - equation.B - Math.Sqrt(discriminant)) / (2 * equation.A), (0 - equation.B + Math.Sqrt(discriminant)) / (2 * equation.A));
            }
            return 0;
        }
        /// <summary>
        /// Возвращает true, если корни есть; false - если корней нет
        /// </summary>
        /// <param name="equation"></param>
        public static explicit operator bool(Equation equation)
        {
            return equation.IsExist();
        }
        /// <summary>
        /// Проверяет коэффициенты уравнения на равенство
        /// </summary>
        /// <param name="eq1"></param>
        /// <param name="eq2"></param>
        /// <returns></returns>
        public static bool operator ==(Equation eq1, Equation eq2)
        {
            return eq1.A == eq2.A && eq1.B == eq2.B && eq1.C == eq2.C;
        }
        /// <summary>
        /// Проверяет коэффициенты уравнения на неравенство
        /// </summary>
        /// <param name="eq1"></param>
        /// <param name="eq2"></param>
        /// <returns></returns>
        public static bool operator !=(Equation eq1, Equation eq2)
        {
            return !(eq1.A == eq2.A && eq1.B == eq2.B && eq1.C == eq2.C);
        }
        /// <summary>
        /// Сравнивает максимальные по значению корни уравнений и возвращает true, если больший корень у уравнения 1
        /// Если корней уравнения не существует у обоих уравнений, то возвращает false
        /// </summary>
        /// <param name="eq1"></param>
        /// <param name="eq2"></param>
        /// <returns></returns>
        public static bool operator >(Equation eq1, Equation eq2)
        {
            if (eq1.IsExist() && eq2.IsExist())
            {
                double maxX1 = 0, maxX2 = 0;
                double x11 = 0, x12 = 0, x21 = 0, x22 = 0;
                double discriminant1 = Math.Pow(eq1.B, 2) - 4 * eq1.A * eq1.C;
                eq1.SolveEquation(out x11, out x12);
                if (x12 == Double.MinValue)
                    x12 = 0;
                maxX1 = Math.Max(Math.Abs(x11), Math.Abs(x12));

                eq2.SolveEquation(out x21, out x22);
                if (x22 == Double.MinValue)
                    x22 = 0;
                maxX2 = Math.Max(Math.Abs(x21), Math.Abs(x22));

                if (maxX1 > maxX2)
                    return true;
            }
            else 
                if (eq1.IsExist() && !eq2.IsExist())
                    return true;
            return false;
        }
        /// <summary>
        /// Сравнивает максимальные по значению корни уравнений и возвращает true, если больший корень у уравнения 2
        /// Если корней уравнения не существует у обоих уравнений, то возвращает false
        /// </summary>
        /// <param name="eq1"></param>
        /// <param name="eq2"></param>
        /// <returns></returns>
        public static bool operator <(Equation eq1, Equation eq2)
        {
            if (eq1.IsExist() && eq2.IsExist())
            {
                double maxX1 = 0, maxX2 = 0;
                double x11 = 0, x12 = 0, x21 = 0, x22 = 0;
                double discriminant1 = Math.Pow(eq1.B, 2) - 4 * eq1.A * eq1.C;
                eq1.SolveEquation(out x11, out x12);
                if (x11 == Double.MinValue)
                    x11 = 0;
                if (x12 == Double.MinValue)
                    x12 = 0;
                maxX1 = Math.Max(Math.Abs(x11), Math.Abs(x12));

                eq2.SolveEquation(out x21, out x22);
                if (x21 == Double.MinValue)
                    x21 = 0;
                if (x22 == Double.MinValue)
                    x22 = 0;
                maxX2 = Math.Max(Math.Abs(x21), Math.Abs(x22));

                if (maxX1 < maxX2)
                    return true;
            }
            else 
                if (!eq1.IsExist() && eq2.IsExist())
                    return true;
            return false;
        }
    }

}
