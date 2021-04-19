using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;

namespace TheFinalProject.Services
{
    public interface IEnrollment
    {
        IEnumerable<Enrollment> GetEnrollments { get; }
        Enrollment GetEnrollment(int? Id);
        void Add(Enrollment enrollment);
        void Remove(int? Id);
    }

}
