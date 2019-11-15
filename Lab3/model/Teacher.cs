using System;

namespace Lab3.model
{
    public class Teacher : Stud
    {
        private string position;
        private int experience;
        
        public Teacher(string name, DateTime birthday, string faculty, string position, int experience)
            : base(name, birthday, faculty)
        {
            this.position = position;
            this.experience = experience;
        }

        public static implicit operator Teacher(string line)
        {
            var split = line.Split('|');
            return new Teacher(split[1], DateTime.Parse(split[2]), split[3], split[4], int.Parse(split[5]));
        }

        public override string ToString()
        {
            return $"{nameof(Teacher)}: {base.ToString()}, {nameof(position)}: {position}, {nameof(experience)}: {experience}";
        }
    }
}