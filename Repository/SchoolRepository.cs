using BZ2KMT_SOF_2023231.Data;
using BZ2KMT_SOF_2023231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BZ2KMT_SOF_2023231.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        protected SchollingDbContext context;
        public SchoolRepository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(School _item)
        {
            context.Set<School>().Add(_item);
            context.SaveChanges();
        }

        public void Delete(int _id)
        {
            context.Set<School>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<School> ReadAll()
        {
            return context.Set<School>();
        }

        public School Read(string name)
        {
            if (this.context.Schools.Count(x => x.Name == name) < 2)
                return this.context.Schools.FirstOrDefault(x => x.Name == name);
            else return null;
        }

        public School Read(int _id)
        {
            return this.context.Schools.First(x => x.Id == _id);
        }

        public void Update(School _item)
        {
            var old = Read(_item.Id);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(_item));
            }
            context.SaveChanges();
        }
    }
}
