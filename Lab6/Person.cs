using System;

namespace Lab6
{
    public class Person
    {
        private string name;
        private string sex;
        private int age;
        private decimal salary;

        public Person(string name, string sex, int age, decimal salary)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.salary = salary;
        }

        public string Name => name;
        public string Sex => sex;
        public int Age => age;
        public decimal Salary => salary;

        public static implicit operator Person(string line)
        {
            var split = line.Split('|');
            return new Person(split[0], split[1], int.Parse(split[2]), decimal.Parse(split[3]));
        }

        public override string ToString()
        {
            return $"{nameof(name)}: {name}, {nameof(sex)}: {sex}, {nameof(age)}: {age}, {nameof(salary)}: {salary}";
        }
    }
}