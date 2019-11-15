using System;

namespace Lab3.model
{
    public class Enrollee : Stud
    {
        public Enrollee(string name, DateTime birthday, string faculty) : base(name, birthday, faculty)
        {
        }

        public static implicit operator Enrollee(string line)
        {
            var split = line.Split('|');
            return new Enrollee(split[1], DateTime.Parse(split[2]), split[3]);
        }

        
        public override string ToString()
        {
            return $"{nameof(Enrollee)}: {base.ToString()}";
        }
    }
}