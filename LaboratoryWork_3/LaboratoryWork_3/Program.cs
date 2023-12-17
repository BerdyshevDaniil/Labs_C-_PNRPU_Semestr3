using System;

namespace LaboratoryWork_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double RecurrenceFun(double x, int n)
            {
                double result = 0;
                double recurrentResult = 0;
                double notReccurentResult = 0;
                for (int i = 0; i <= n; ++i)
                {
                    if (i == 0)
                    {
                        recurrentResult += 1;
                        result += recurrentResult;
                    }
                    else
                    {
                        notReccurentResult = Math.Cos(i * (Math.PI / 4));
                        recurrentResult = recurrentResult * x / i;
                        result += recurrentResult * notReccurentResult;
                    }
                }
                return result;
            }

            double a = 0.1, b = 1, k = 10;
            double resN;
            for (double x = a; x <= b; x += (b - a) / k)
            {
                int n = 25;
                resN = RecurrenceFun(x, n);

                n = 0;
                double S1 = RecurrenceFun(x, n), S2 = RecurrenceFun(x, n + 1), resE = S2;
                while (Math.Abs(S2 - S1) >= 0.0001 || S2 == S1)
                {
                    ++n;
                    S1 = S2;
                    S2 = RecurrenceFun(x, n + 1);
                    resE = S2;
                }
                double y = Math.Exp(x * Math.Cos(Math.PI / 4)) * Math.Cos(x * Math.Sin(Math.PI / 4));
                Console.WriteLine($"X = {x}   \tSN = {resN}\tSE = {resE}\tY= {y}");
            }
        }
    }
}