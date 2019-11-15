using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class Custom2DArray
    {
        private int[,] arr;

        public Custom2DArray(int[,] arr)
        {
            if (arr.GetLength(0) == 0 || arr.GetLength(1) == 0) throw new Exception("Array can't be empty");
            this.arr = arr;
        }

        public void ReplaceElWith0Between(int start, int end)
        {
            if (start > end || start < 0 || end >= arr.GetLength(0) * arr.GetLength(1))
                throw new Exception("invalid args");

            Console.WriteLine($"start: {start} end: {end}");

            int id = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (id >= start && id <= end)
                    {
                        arr[i, j] = 0;
                    }

                    id++;
                }
            }
        }

        public int CollateralDiagonalSum()
        {
            if (arr.GetLength(0) != arr.GetLength(1)) throw new Exception("Array should be NxN");

            int length = arr.GetLength(0);
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == length - j - 1) sum += arr[i, j];
                }
            }

            return sum;
        }

        //1 Вставить новую строку после строки, в которой находится первый встреченный минимальный элемент.
        public void InsertRowAfterFirstMin()
        {
            var result = new int[arr.GetLength(0) + 1, arr.GetLength(1)];
            var minRowNum = FindMinRowNum();
            for (int i = 0, k = 0; i < arr.GetLength(0); i++, k++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    result[k, j] = arr[i, j];
                }

                if (i == minRowNum)
                {
                    k++;
                }
            }

            arr = result;
        }

        private int FindMinRowNum()
        {
            var lineWithMinEl = -1;
            var min = int.MaxValue;
            for (var i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                for (var j = arr.GetLength(1) - 1; j >= 0; j--)
                {
                    if (arr[j, i] >= min) continue;
                    min = arr[j, i];
                    lineWithMinEl = j;
                }
            }

            return lineWithMinEl;
        }

        //2.	Вставить новый столбец перед всеми столбцами, в которых встречается заданное число.
        public void InsertNewColBeforeColThatContainsNum(int num)
        {
            var list = new List<int>();
            for (var i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[j, i] == num)
                    {
                        list.Add(i);
                        break;
                    }
                }
            }

            var result = new int[arr.GetLength(0), arr.GetLength(1) + list.Count];
            for (int i = 0, k = 0; i < arr.GetLength(1); i++, k++)
            {
                if (list.Contains(i))
                {
                    k++;
                }

                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    result[j, k] = arr[j, i];
                }
            }

            arr = result;
        }

        //3.	Удалить все строки, в которых нет ни одного четного элемента.
        public void RemoveRowsWithNoEvenNums()
        {
            var removeRows = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (!RowContainsEven(i))
                    removeRows++;
            }

            var result = new int[arr.GetLength(0) - removeRows, arr.GetLength(1)];
            for (int i = 0, k = 0; i < arr.GetLength(0); i++, k++)
            {
                if (!RowContainsEven(i))
                {
                    i++;
                }

                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    result[k, j] = arr[i, j];
                }
            }

            arr = result;
        }

        private bool RowContainsEven(int rowNum)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[rowNum, j] % 2 == 0)
                {
                    return true;
                }
            }

            return false;
        }

        //4.	Удалить все столбцы, в которых все элементы положительны.
        public void RemoveColsWithPositiveNums()
        {
            var cols = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                if (!IsColPositive(i))
                    cols++;
            }

            var result = new int[arr.GetLength(0), cols];
            for (int i = 0, k = 0; i < arr.GetLength(1); i++)
            {
                if (IsColPositive(i))
                {
                    continue;
                }

                for (var j = 0; j < result.GetLength(0); j++)
                {
                    result[j, k] = arr[j, i];
                }

                k++;
            }

            arr = result;
        }

        private bool IsColPositive(int colNum)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, colNum] <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        //5.	Удалить из массива k-тую строку и j-тый столбец, если их значения совпадают.
        public void RemoveEqualRowAndCol()
        {
            var removeRows = new List<int>();
            var removeCols = new List<int>();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                var row = new List<int>();
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    row.Add(arr[i, j]);
                }

                var sameCols = GetSameCols(row).ToList();
                if (sameCols.Count != 0)
                {
                    removeRows.Add(i);
                    removeCols.AddRange(sameCols);
                }
            }
            
            var result = new int[arr.GetLength(0) - removeRows.Count, arr.GetLength(1) - removeCols.Count];
            for (int i = 0, k = 0; k < result.GetLength(0); i++, k++)
            {
                if (removeRows.Contains(i)) i++;
                for (int j = 0, n = 0; n < result.GetLength(1); j++, n++)
                {
                    if (removeCols.Contains(j)) j++;
                    result[k, n] = arr[i, j];
                }
            }

            arr = result;
        }

        private IEnumerable<int> GetSameCols(List<int> row)
        {
            var result = new List<int>();
            for (var j = 0; j < arr.GetLength(1); j++)
            {
                var col = new List<int>();
                for (var i = 0; i < arr.GetLength(0); i++)
                {
                    col.Add(arr[i, j]);
                }
                if(row.SequenceEqual(col)) result.Add(j);
            }

            return result;
        }

        //6.	Уплотнить массив, удалив из него все нулевые строки и столбцы. 
        public void RemoveZeros()
        {
            var zeroRows = new List<int>();
            var zeroCols = new List<int>();

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                if (IsRowZero(i)) zeroRows.Add(i);
            }

            for (var i = 0; i < arr.GetLength(1); i++)
            {
                if (IsColZero(i)) zeroCols.Add(i);
            }

            var result = new int[arr.GetLength(0) - zeroRows.Count, arr.GetLength(1) - zeroCols.Count];
            for (int i = 0, k = 0; k < result.GetLength(0); i++, k++)
            {
                if (zeroRows.Contains(i)) i++;
                for (int j = 0, n = 0; n < result.GetLength(1); j++, n++)
                {
                    if (zeroCols.Contains(j)) j++;
                    result[k, n] = arr[i, j];
                }
            }

            arr = result;
        }

        private bool IsRowZero(int row)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[row, j] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsColZero(int col)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, col] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public int[,] Arr => arr;

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                builder.Append('[');
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    builder.Append($"{arr[i, j]} ");
                }

                builder.Append("]\n");
            }

            return builder.ToString();
        }
    }
}