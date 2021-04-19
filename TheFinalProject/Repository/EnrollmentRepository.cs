using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private readonly StudentDbContext _db;
        public EnrollmentRepository(StudentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Enrollment> GetEnrollments => _db.Enrollments.Include(s => s.Students).Include(c => c.Courses);
        public void Add(Enrollment enrollment)
        {
            if (enrollment.EnrollmentId == 0)
            {
                _db.Enrollments.Add(enrollment);
            }
            else
            {
                var dbEntity = _db.Enrollments.Find(enrollment.EnrollmentId);
                dbEntity.CourseId = enrollment.CourseId;
                dbEntity.EndDate = enrollment.EndDate;
                dbEntity.StartDate = enrollment.StartDate;
                dbEntity.StartDate = enrollment.StartDate;
                dbEntity.Grade = enrollment.Grade;
            }
            _db.SaveChanges();
        }

        public Enrollment GetEnrollment(int? Id)
        {
            Enrollment dbEntity = _db.Enrollments.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Enrollment dbEntity = _db.Enrollments.Find(Id);
            _db.Enrollments.Remove(dbEntity);
            _db.SaveChanges();
        }
    }
}
