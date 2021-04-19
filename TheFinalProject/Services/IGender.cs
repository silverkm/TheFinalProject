using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;

namespace TheFinalProject.Services
{
    public interface IGender
    {
        IEnumerable<Gender> GetGenders { get; }
        Gender GetGender(int? Id);
        void Add(Gender gender);
        void Remove(int? Id);
    }

}
