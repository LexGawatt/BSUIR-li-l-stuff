using System;

namespace Lab2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Triangle tr = "a: 1, b: 2, c: 3";
            tr*=2;
            Console.WriteLine(tr);

//            testPerimeter();
//            testSquare();
        }

        private static void testPerimeter()
        {
            assert(new Triangle(2, 3, 4).CalcPerimeter() == 9);
        }

        private static void testSquare()
        {
            assert(Math.Abs(new Triangle(2, 3, 4).CalcSquare() - 2.904) < 0.0009);
        }

        private static void assert(bool b)
        {
            if (!b)
                throw new Exception("Assertion failed");

            Console.WriteLine("Assert passed");
        }
    }
}