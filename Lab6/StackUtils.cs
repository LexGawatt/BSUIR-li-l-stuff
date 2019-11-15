using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab6
{
    public class StackUtils
    {
        public static void ReverseNumbers(string source, string target)
        {
            var stack = new Stack<string>(File.ReadAllText(source).Split(' '));
            var writer = File.AppendText(target);
            foreach (var num in stack)
            {
                writer.Write(num + " ");
            }

            writer.Close();
        }

        public static void PrintReverseVowels(string source)
        {
            var vowels = "aeiouy";
            var stack = new Stack<char>(File.ReadAllText(source).ToCharArray()
                .Where(ch => vowels.Contains(ch)));
            foreach (var ch in stack)
            {
                Console.Write(ch);
            }
        }

        public static void PrintReverseChars(string source)
        {
            var stack = new Stack<char>(File.ReadAllText(source).ToCharArray());
            foreach (var ch in stack)
            {
                Console.Write(ch);
            }
        }

        public static bool EqualsReverse(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            for (int i = 0, j = str2.Length - 1; i < str1.Length; i++, j--)
            {
                if (!str1[i].Equals(str2[j]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}