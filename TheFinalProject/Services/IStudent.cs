using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;

namespace TheFinalProject.Services
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents { get; }
        Student GetStudent(int? Id);
        void Add(Student student);
        void Remove(int? Id);
    }

}
