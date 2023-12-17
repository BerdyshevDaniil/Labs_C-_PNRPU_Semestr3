using System;

namespace Task_3 {
    internal class Program {
        static void Main(string[] args) 
        {
            float aFloat = 1000f, bFloat = 0.0001f;
            float cFloat = (float) Math.Pow(aFloat - bFloat, 3);
            float dFloat = (float) (Math.Pow(aFloat, 3) + 3 * aFloat * Math.Pow(bFloat, 2));
            float eFloat = (float) ((-3) * Math.Pow(aFloat, 2)* bFloat - Math.Pow(bFloat, 3));
            float resFloat = (cFloat - dFloat) / eFloat;
            Console.WriteLine($"resFloat = {resFloat}");
            double aDouble = 1000, bDouble = 0.0001;
            double resDouble = (Math.Pow(aDouble - bDouble, 3) - (Math.Pow(aDouble, 3) 
                + 3 * aDouble * Math.Pow(bDouble, 2))) / ((-3) * Math.Pow(aDouble, 2) 
                * bDouble - Math.Pow(bDouble, 3));
            Console.WriteLine($"resDouble = {resDouble}");
        }
    }
}