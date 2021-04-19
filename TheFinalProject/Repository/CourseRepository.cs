using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly StudentDbContext _db;
        public CourseRepository(StudentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Course> GetCourses => _db.Courses;
        public void Add(Course course)
        {
            if (course.CourseId == 0)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
            }
            else
            {
                var dbEntity = _db.Courses.Find(course.CourseId);
                dbEntity.CourseName = course.CourseName;
                dbEntity.Credits = course.Credits;
                _db.SaveChanges();
            }
        }

        public Course GetCourse(int? Id)
        {
            return _db.Courses.Include(e => e.Enrollments)
                               .ThenInclude(s => s.Students)
                               .SingleOrDefault(a => a.CourseId == Id);
        }

        public void Remove(int? Id)
        {
            Course dbEntity = _db.Courses.Find(Id);
            _db.Courses.Remove(dbEntity);
            _db.SaveChanges();
        }
    }
}
