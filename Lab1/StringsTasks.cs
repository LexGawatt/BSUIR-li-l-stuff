using System;
using System.Linq;

namespace Lab1
{
    public class StringsTasks
    {
        private string str;

        public StringsTasks(string str)
        {
            this.str = str;
        }

        public char FindMostFrequentOf(char ch1, char ch2)
        {
            int countCh1 = 0;
            int countCh2 = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == ch1)
                    countCh1++;
                if (str[i] == ch2)
                    countCh2++;
            }

            if (countCh1 > countCh2)
            {
                return ch1;
            }

            if (countCh1 < countCh2)
            {
                return ch2;
            }

            return (char) 0;
        }

        public void PrintCapital()
        {
            var punctuation = str.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = str.Split().Select(x => x.Trim(punctuation)).Where(x => x.Trim() != "").ToArray();
            for (var i = 0; i < words.Length; i++)
            {
                if (char.IsUpper(words[i][0]))
                    Console.WriteLine(words[i]);
            }
        }

        public string Str => str;
    }
}