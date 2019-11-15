using System;
using Lab3.repos;

namespace Lab3
{
    internal static class Program
    {
        public static void Main()
        {
//            foreach (var stud in ArrayStudRepository.Instance.GetPersonWithAgeBetween(20, 25))
//            {
//                stud.PrintInfo();
//            }

            var fileStudRepository = new FileStudRepository("D:\\univer\\oop\\OOP\\Lab3\\people.txt");
            Console.WriteLine("All studs:");
            foreach (var stud in fileStudRepository.GetAllStuds())
            {
                stud.PrintInfo();
            }
            
            Console.WriteLine("\nstuds between 20 and 25:");
            foreach (var stud in fileStudRepository.GetPersonWithAgeBetween(20, 25))
            {
                stud.PrintInfo();
            }
        }
    }
}