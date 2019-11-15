using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class CustomArray
    {
        private int[] arr;

        public CustomArray(int[] arr)
        {
            if(arr.Length == 0) throw new Exception("Array should not be empty");
            this.arr = arr;
        }

        public void ReplaceElWith0Between(int start, int end)
        {
            if (start > end || start < 0 || end >= arr.Length)
                throw new Exception("invalid args");

            Console.WriteLine($"start: {start} end: {end}");
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= start && i <= end)
                {
                    arr[i] = 0;
                }
            }    
        }

        public void ReplaceMaxWith0()
        {
            int max = arr.Max();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == max)
                {
                    arr[i] = 0;
                }
            }
        }
        
        //#1 Удалить из массива все чётные числа
        void RemoveEven()
        {
            arr = arr.Where(el => el % 2 != 0).ToArray();
        }

        //#2 Вставить новый элемент после всех элементов,которые заканчиваются на данную цифру
        void InsertElAfterEndingDigit(int endingDigit, int element)
        {
            var list = arr.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] % 5 == endingDigit)
                {
                    list.Insert(i, element);
                }
            }

            arr = list.ToArray();
        }

        //#3 Удалить из массива повторяющиеся элементы,оставив только их первые вхождения
        void RemoveDuplicates()
        {
            arr = arr.Distinct().ToArray();
        }
        
        //#4 Вставить новый элемент между всеми парами элементов,имеющими разные знаки
        void InsertElBetweenElsWithDifferentSigns()
        {
            var result = new List<int>();
            for (var i = 0; i <= arr.Length; i++)
            {
                result.Add(arr[i]);
                if (HasDifferentSigns(arr[i], arr[i + 1]))
                {
                    result.Add(arr[i + 1]);
                }
            }

            result.Add(arr[arr.Length-1]);
            arr = result.ToArray();
        }
        
        private bool HasDifferentSigns(int first, int second )
        {
            return (first < 0 && second > 0) || (first > 0 && second < 0);
        }
        
        //#5 Уплотнить массив,удалив из него все нулевые значения
        void RemoveZeros()
        {
            arr = arr.Where(el => el != 0).ToArray();
        }
        
        public int[] Arr => arr;

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append('[');
            foreach (var el in arr)
            {
                builder.Append($"{el} ");
            }

            builder.Append(']');
            return builder.ToString();
        }
    }
}