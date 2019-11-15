using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public struct Student: IComparable<Student>
    {
        private readonly string fio;
        private readonly int groupNumber;
        private readonly Dictionary<string, int> examResults; //name, mark

        private Student(string fio, int groupNumber, Dictionary<string, int> examResults)
        {
            this.fio = fio;
            this.groupNumber = groupNumber;
            this.examResults = examResults;
        }

        public int CompareTo(Student other)
        {
            return groupNumber.CompareTo(other.groupNumber);
        }
        
        public static implicit operator Student(string line)
        {
            var split = line.Split('|');
            var exams = split[2].Split(',').Select(exam => exam.Split(':'))
                .ToDictionary(strings => strings[0], strings => int.Parse(strings[1]));
            
            return new Student(split[0], int.Parse(split[1]), exams);
        }

        public override string ToString()
        {
            return $"{fio}|" +
                   $"{groupNumber}|" +
                   $"{string.Join(",", examResults.Select(x => x.Key + ":" + x.Value).ToArray())}";
        }

        public bool Equals(Student other)
        {
            return string.Equals(fio, other.fio)
                   && groupNumber == other.groupNumber
                   && Equals(examResults, other.examResults);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = fio != null ? fio.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ groupNumber;
                hashCode = (hashCode * 397) ^ (examResults != null ? examResults.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string Fio => fio;

        public int GroupNumber => groupNumber;

        public Dictionary<string, int> ExamResults => examResults;

    }
}