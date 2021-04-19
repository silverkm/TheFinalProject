using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Repository
{
    public class GenderRepository : IGender
    {
        private readonly StudentDbContext _db;
        public GenderRepository(StudentDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Gender> GetGenders => _db.Genders;
        public void Add(Gender _Gender)
        {
            _db.Genders.Add(_Gender);
            _db.SaveChanges();
        }

        public Gender GetGender(int? Id)
        {
            Gender dbEntity = _db.Genders.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Gender dbEntity = _db.Genders.Find(Id);
            _db.Genders.Remove(dbEntity);
            _db.SaveChanges();
        }
    }

}
