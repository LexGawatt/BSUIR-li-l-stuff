using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace Lab5
{
    internal class Program
    {
        // read students from file
        // find all students that passed all exams
        // order by group num
        // write to file
        public static void Main(string[] args)
        {
            var students = File.ReadLines("D:\\univer\\oop\\OOP\\Lab5\\people.txt")
                .Select(line => (Student) line)
                .Where(student => student.ExamResults.All(pair => pair.Value >= 4)) //passed exam
                .OrderBy(student => student.GroupNumber)
                .Select(student => student.ToString());
            File.WriteAllLines("D:\\univer\\oop\\OOP\\Lab5\\target_people.txt", students);   
        }
    }
}