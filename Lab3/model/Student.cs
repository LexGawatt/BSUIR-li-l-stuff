using System;

namespace Lab3.model
{
    public class Student : Stud
    {
        private int studyYear;
        
        public Student(string name, DateTime birthday, string faculty, int studyYear) : base(name, birthday, faculty)
        {
            this.studyYear = studyYear;
        }

        public static implicit operator Student(string line)
        {
            var split = line.Split('|');
            return new Student(split[1], DateTime.Parse(split[2]), split[3], int.Parse(split[4]));
        }

        public override string ToString()
        {
            return $"{nameof(Student)} {base.ToString()}, {nameof(studyYear)}: {studyYear}";
        }
    }
}