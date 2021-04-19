using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;

namespace TheFinalProject.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetCourses { get; }
        Course GetCourse(int? Id);
        void Add(Course course);
        void Remove(int? Id);
    }

}
