using System.Collections.Generic;
using Lab3.model;

namespace Lab3.repos
{
    public interface IStudRepository
    {
        IList<Stud> GetAllStuds();

        IList<Stud> GetPersonWithAgeBetween(int from, int to);
    }
}