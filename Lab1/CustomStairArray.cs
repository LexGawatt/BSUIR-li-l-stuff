using System;
using System.Text;

namespace Lab1
{
    public class CustomStairArray
    {
        private int[][] arr;

        public CustomStairArray(int[][] arr)
        {
            if (arr.Length == 0 || arr[0].Length == 0) throw new Exception("Array cant be empty");
            this.arr = arr;
        }

        public void ReplaceEvenColsWith(int[] target)
        {
            if (arr.Length != target.Length)
                throw new Exception("Invalid target size");

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 2; j < arr[i].Length; j += 2)
                {
                    arr[i][j] = target[i];
                }
            }
        }

        public int[][] Arr => arr;

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var top in arr)
            {
                builder.Append('[');
                foreach (var el in top)
                {
                    builder.Append($"{el} ");
                }

                builder.Append("]\n");
            }

            return builder.ToString();
        }
    }
}