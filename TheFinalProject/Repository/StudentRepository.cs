using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly StudentDbContext _db;
        public StudentRepository(StudentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Student> GetStudents => _db.Students.Include(o => o.Genders);

        public void Add(Student student)
        {
            if (student.StudentId == 0)
            {
                _db.Students.Add(student);
            }
            else
            {
                var dbEntity = _db.Students.Find(student.StudentId);
                dbEntity.FirstName = student.FirstName;
                dbEntity.LastName = student.LastName;
                dbEntity.DOB = student.DOB;
                dbEntity.GenderId = student.GenderId;
                dbEntity.RegistrationDate = student.RegistrationDate;
                dbEntity.Status = student.Status;
            }
            _db.SaveChanges();
        }

        public Student GetStudent(int? Id)
        {
            Student dbEntity = _db.Students.Include(e => e.Enrollments)
                                            .ThenInclude(c => c.Courses)
                                            .Include(g => g.Genders)
                                            .SingleOrDefault(m => m.StudentId == Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Student dbEntity = _db.Students.Find(Id);
            _db.Students.Remove(dbEntity);
            _db.SaveChanges();
        }

    }
}
