using System;
using System.Collections.Generic;

namespace Lab1
{
    public static class MainClass
    {
        public static void Main()
        {
//            RunTask1OneDArr();
//            RunTask1TwoDArr();
//            RunTask2();
//            RunTask3();
//            RunTask4();
//            RunStringTask1("abc", 'a', 'b');
//            RunStringTask2("heLlo World, Guys");

//            RunKSR2DTask1();
//            RunKSR2DTask2();
//            RunKSR2DTask3();
//            RunKSR2DTask4();
//            RunKSR2DTask5();
//            RunKSR2DTask6();

//            GetMultipliersCombinations(12).ToList().ForEach(combination => Console.WriteLine(combination + "=" + 12));
//            Console.WriteLine("");
//            GetTermsCombinations(5).ForEach(combination => Console.WriteLine(combination + "=" + 5));
        }

        private static void RunTask1OneDArr()
        {
            var baseArr = RandomArray(7);

            Console.WriteLine("\nMatrix: Task1: 1D Array");
            var array = new CustomArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.ReplaceElWith0Between(2, 5);

            Console.WriteLine("After");
            Console.WriteLine(array.ToString());
        }

        private static void RunTask1TwoDArr()
        {
            var baseArr = RandomArray(2, 4);

            Console.WriteLine("\nMatrix: Task1: 2D Array");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.ReplaceElWith0Between(2, 5);

            Console.WriteLine("After");
            Console.WriteLine(array.ToString());
        }

        private static void RunTask2()
        {
            var baseArr = RandomArray(6);

            Console.WriteLine("\nMatrix: Task2");
            var array = new CustomArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.ReplaceMaxWith0();

            Console.WriteLine("After");
            Console.WriteLine(array.ToString());
        }

        private static void RunTask3()
        {
            var baseArr = RandomArray(3, 3);

            Console.WriteLine("\nMatrix: Task3");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            Console.WriteLine("Sum " + array.CollateralDiagonalSum());
        }

        private static void RunTask4()
        {
            var baseArr = RandomStairArray(3);

            Console.WriteLine("\nMatrix: Task4");
            var array = new CustomStairArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            var replacement = new CustomArray(RandomArray(3));
            Console.WriteLine("Replacement:");
            Console.WriteLine(replacement.ToString());

            array.ReplaceEvenColsWith(replacement.Arr);

            Console.WriteLine("After");
            Console.WriteLine(array.ToString());
        }

        private static void RunStringTask1(string line, char ch1, char ch2)
        {
            Console.WriteLine("\nStrings: Task1");
            Console.WriteLine("Line: " + line);
            var task = new StringsTasks(line);
            var result = task.FindMostFrequentOf(ch1, ch2);
            Console.WriteLine(result != 0 ? $"Most frequent of {ch1} and {ch2}: {result}" : "Frequency is equal");
        }

        private static void RunStringTask2(string line)
        {
            Console.WriteLine("\nStrings: Task2");
            Console.WriteLine("Line: " + line);
            var task = new StringsTasks(line);
            Console.WriteLine("Capitals:");
            task.PrintCapital();
        }

        private static void RunKSR2DTask1()
        {
            var baseArr = RandomArray(4, 4);

            Console.WriteLine("\nKSR2D Task1");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.InsertRowAfterFirstMin();
            Console.WriteLine("After:\n" + array);
        }

        private static void RunKSR2DTask2()
        {
            var baseArr = RandomArray(4, 4);
            baseArr[1, 1] = 5;

            Console.WriteLine("\nKSR2D Task2");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.InsertNewColBeforeColThatContainsNum(5);
            Console.WriteLine("After:\n" + array);
        }

        private static void RunKSR2DTask3()
        {
            var baseArr = RandomArray(7, 3);
            baseArr[2, 0] = 1;
            baseArr[2, 1] = 1;
            baseArr[2, 2] = 1;

            Console.WriteLine("\nKSR2D Task3");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.RemoveRowsWithNoEvenNums();
            Console.WriteLine("After:\n" + array);
        }

        private static void RunKSR2DTask4()
        {
            var baseArr = RandomArray(5, 7);
            baseArr[2, 0] = -1;
            baseArr[4, 1] = -15;
            baseArr[4, 6] = -15;

            Console.WriteLine("\nKSR2D Task4");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.RemoveColsWithPositiveNums();
            Console.WriteLine("After:\n" + array);
        }

        private static void RunKSR2DTask5()
        {
            var baseArr = RandomArray(3, 3);
            baseArr[0, 0] = 0;
            baseArr[0, 1] = 0;
            baseArr[0, 2] = 0;
            baseArr[0, 1] = 0;
            baseArr[1, 1] = 0;
            baseArr[2, 1] = 0;

            Console.WriteLine("\nKSR2D Task5");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.RemoveEqualRowAndCol();
            Console.WriteLine("After:\n" + array);
        }

        private static void RunKSR2DTask6()
        {
            var baseArr = RandomArray(4, 3);
            baseArr[0, 0] = 0;
            baseArr[0, 1] = 0;
            baseArr[0, 2] = 0;
            baseArr[1, 0] = 0;
            baseArr[2, 0] = 0;
            baseArr[3, 0] = 0;

            Console.WriteLine("\nKSR2D Task6");
            var array = new Custom2DArray(baseArr);
            Console.WriteLine("Before");
            Console.WriteLine(array.ToString());

            array.RemoveZeros();
            Console.WriteLine("After:\n" + array);
        }

        private static IEnumerable<string> GetMultipliersCombinations(int num)
        {
            for (int i = 2; i * i < num; i++)
            {
                if (num % i != 0)
                    continue;
                yield return $"{num / i}*{i}";
                var moreCombinations = GetMultipliersCombinations(num / i);
                foreach (string combination in moreCombinations)
                {
                    yield return $"{combination}*{i}";
                }
            }
        }

        private static List<string> GetTermsCombinations(int num)
        {
            int a = 1;
            int b = 1;
            var result = new List<string>();
            while (true)
            {
                for (int i = 1; i < num; i++)
                {
                    string combination = "" + a;
                    for (int j = num - i; j > 1; j--)
                    {
                        combination += "+1";
                    }

                    combination += "+" + b;
                    result.Add(combination);
                    b++;
                }

                b = ++a;
                if (num <= 1) return result;
                num = num - 2;
            }
        }

/*////////////////////////////////////////////////////////////////////////////////*/
        
        private static int[] RandomArray(int size)
        {
            var array = new int[size];
            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(20);
            }

            return array;
        }

        private static int[,] RandomArray(int col, int row)
        {
            var arr = new int[col, row];
            var random = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(20);
                }
            }

            return arr;
        }

        private static int[][] RandomStairArray(int size)
        {
            var arr = new int[size][];
            var random = new Random();
            for (int i = 0; i < size; ++i)
            {
                arr[i] = new int[size];
                for (int j = 0; j < size; ++j)
                {
                    arr[i][j] = random.Next(20);
                }
            }

            return arr;
        }

        private static int[] Input()
        {
            Console.WriteLine("Enter array size");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("a[{0}]= ", i);
                a[i] = int.Parse(Console.ReadLine());
            }

            return a;
        }

        private static int[,] Input(out int n, out int m)
        {
            Console.WriteLine("Enter array size");
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; ++i)
            for (int j = 0; j < m; ++j)
            {
                Console.Write("a[{0},{1}]= ", i, j);
                a[i, j] = int.Parse(Console.ReadLine());
            }

            return a;
        }

        private static int[][] InputStairArray()
        {
            Console.WriteLine("Enter arraySize");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[][] a = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                a[i] = new int [n];
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }

            return a;
        }
    }
}