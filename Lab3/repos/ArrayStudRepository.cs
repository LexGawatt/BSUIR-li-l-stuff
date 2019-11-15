using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.model;

namespace Lab3.repos
{
    public class ArrayStudRepository : IStudRepository
    {
        private static readonly ArrayStudRepository instance = new ArrayStudRepository();
        
        private readonly IList<Stud> allStuds;

        private ArrayStudRepository()
        {
            allStuds = new List<Stud>
            {
                new Enrollee("Jack", new DateTime(1990, 2, 5), "math"),
                new Enrollee("John", new DateTime(1989, 6, 15), "math"),
                new Enrollee("Peter", new DateTime(1992, 3, 25), "math"),
                new Enrollee("Meghna", new DateTime(1976, 8, 1), "math"),
                new Student("Pol", new DateTime(1995, 2, 12), "math", 3),
                new Student("James", new DateTime(1998, 7, 21), "math", 1),
                new Student("Molly", new DateTime(1998, 9, 13), "math", 1),
                new Student("Floor", new DateTime(1993, 12, 1), "math", 4),
                new Teacher("Sven", new DateTime(1970, 1, 4), "math", "phd", 10),
                new Teacher("Mary", new DateTime(1976, 8, 8), "math", "phd", 15)
            };
        }

        public IList<Stud> GetAllStuds()
        {
            return new List<Stud>(allStuds);
        }

        public IList<Stud> GetPersonWithAgeBetween(int from, int to)
        {
            return allStuds.Where(stud => stud.GetAge() >= from && stud.GetAge() <= to).ToList();
        }

        public static ArrayStudRepository Instance => instance;
    }
}