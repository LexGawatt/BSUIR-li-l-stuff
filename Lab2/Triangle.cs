using System;
using System.Text.RegularExpressions;

namespace Lab2
{
    public class Triangle
    {
        private int a;
        private int b;
        private int c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public int CalcPerimeter()
        {
            if(!Exists)
                throw new Exception("Perimeter cant be calculated, triangle does not exist");
            return a + b + c;
        }

        public double CalcSquare()
        {
            var halfPerimeter = CalcPerimeter() / 2.0;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
        }

        public bool Exists => a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;

        public int A
        {
            get => a;
            set => a = value;
        }

        public int B
        {
            get => b;
            set => b = value;
        }

        public int C
        {
            get => c;
            set => c = value;
        }

        public int this[int i] => i == 0 ? a : i == 1 ? b : i == 2 ? c : throw new IndexOutOfRangeException();

        public static Triangle operator ++(Triangle triangle)
        {
            triangle.a++;
            triangle.b++;
            triangle.c++;
            return triangle;
        }

        public static Triangle operator --(Triangle triangle)
        {
            triangle.a--;
            triangle.b--;
            triangle.c--;
            return triangle;
        }

        public static Triangle operator *(Triangle triangle, int s)
        {
            triangle.a *= s;
            triangle.b *= s;
            triangle.c *= s;
            return triangle;
        }

        public static bool operator true(Triangle triangle)
        {
            return triangle.Exists;
        }

        public static bool operator false(Triangle triangle)
        {
            return triangle.Exists;
        }

        public static implicit operator Triangle(string triangle)
        {
            string validation = $"{nameof(a)}: \\d, {nameof(b)}: \\d, {nameof(c)}: \\d";
            if (Regex.Matches(triangle, validation).Count == 0)
                throw new Exception($"Invalid triangle string, {triangle}");

            var matches = Regex.Matches(triangle, "\\b+: \\d+");
            var splitter = new[] {": "};
            var trA = int.Parse(matches[0].Value.Split(splitter, StringSplitOptions.None)[1]);
            var trB = int.Parse(matches[1].Value.Split(splitter, StringSplitOptions.None)[1]);
            var trC = int.Parse(matches[2].Value.Split(splitter, StringSplitOptions.None)[1]);
            return new Triangle(trA, trB, trC);
        }

        public static implicit operator string(Triangle triangle)
        {
            return triangle.ToString();
        }

        public override string ToString()
        {
            return $"{nameof(a)}: {a}, {nameof(b)}: {b}, {nameof(c)}: {c}";
        }
    }
}