using System;

namespace Lab3.model
{
    public abstract class Stud
    {
        protected string name;
        protected DateTime birthday;
        protected string faculty;

        protected Stud(string name, DateTime birthday, string faculty)
        {
            this.name = name;
            this.birthday = birthday;
            this.faculty = faculty;
        }

        public int GetAge()
        {
            return DateTime.Today.Subtract(birthday).Days / 365;
        }

        public void PrintInfo()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{nameof(name)}: {name}, {nameof(birthday)}: {birthday}, {nameof(faculty)}: {faculty}";
        }
    }
}