using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab3.model;

namespace Lab3.repos
{
    public class FileStudRepository : IStudRepository
    {
        private readonly string file;   
        
        public FileStudRepository(string file)
        {
            this.file = file;
        }
        
        public IList<Stud> GetAllStuds()
        {
            return ReadStuds().ToList();
        }

        public IList<Stud> GetPersonWithAgeBetween(int from, int to)
        {
            return ReadStuds().Where(stud => stud.GetAge() >= from && stud.GetAge() <= to).ToList();
        }

        private IEnumerable<Stud> ReadStuds()
        {
            return File.ReadLines(file).Select<string, Stud>(line =>
            {
                if (line.ToLower().StartsWith("teacher"))
                    return (Teacher) line;
                if (line.ToLower().StartsWith("student"))
                    return (Student) line;
                if (line.ToLower().StartsWith("enrollee"))
                    return (Enrollee) line;
                throw new Exception("Unsupported stud type " + line);
            });
        } 
    }
}