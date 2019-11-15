using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab6.music;

namespace Lab6
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            HashTableTask();
        }

        private static void StackTasks()
        {
            var dir = "D:\\univer\\oop\\OOP\\Lab6\\test\\";
//            StackUtils.ReverseNumbers(dir + "numbers.file.txt", dir + "target.numbers.file.txt");
//            StackUtils.PrintReverseVowels(dir + "test.text.txt");
//            StackUtils.PrintReverseChars(dir + "test.text.txt");
            var equalsReverse = StackUtils.EqualsReverse("elif siht ot dlroW olleH", "Hello World to this file");
            Console.WriteLine(equalsReverse);
        }

        private static void QueueTask()
        {
            var queue = new Queue<Person>(File.ReadLines("D:\\univer\\oop\\OOP\\Lab6\\test\\persons")
                .Select(line => (Person) line).ToList());

            var younger = new Queue<Person>();

            while (queue.Count > 0)
            {
                var person = queue.Dequeue();
                if (person.Age > 30)
                {
                    Console.WriteLine(person);
                }
                else
                {
                    younger.Enqueue(person);
                }
            }

            foreach (var person in younger)
            {
                Console.WriteLine(person);
            }
        }

        private static void ArrayListTask()
        {
            var list = new ArrayList(File.ReadLines("D:\\univer\\oop\\OOP\\Lab6\\test\\persons")
                .Select(line => (Person) line).ToList());

            var younger = new ArrayList();

            foreach (var person in list)
            {
                if (((Person) person).Age > 30)
                {
                    Console.WriteLine(person);
                }
                else
                {
                    younger.Add(person);
                }
            }

            foreach (var person in younger)
            {
                Console.WriteLine(person);
            }
        }

        private static void HashTableTask()
        {
            var discCatalog = new DiscCatalog();
            Console.WriteLine("All discs");
            Console.WriteLine(string.Join("\n", discCatalog.FindAllDiscs()));
            
            var disc = new Disc("some disc", new List<Song>());
            Console.WriteLine("\nSaved disc id");
            Console.WriteLine(discCatalog.SaveDisc(disc));
            Console.WriteLine("\nAll discs");
            Console.WriteLine(string.Join("\n", discCatalog.FindAllDiscs()));
            
            discCatalog.DeleteDisc(disc);
            Console.WriteLine("\nAll discs after del");
            Console.WriteLine(string.Join("\n", discCatalog.FindAllDiscs()));
            
            Console.WriteLine("\nSongs of RHCP author");
            Console.WriteLine(string.Join("\n", discCatalog.FindSongsByAuthor("RHCP")));
            
        }
    }
}