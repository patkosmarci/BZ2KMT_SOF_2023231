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
    public class TeacherRepository : ITeacherRepository
    {
        protected SchollingDbContext context;
        public TeacherRepository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(Teacher _item)
        {
            context.Set<Teacher>().Add(_item);
            context.SaveChanges();
        }

        public void Delete(int _id)
        {
            context.Set<Teacher>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<Teacher> ReadAll()
        {
            return context.Set<Teacher>();
        }
        public Teacher Read(int _id)
        {
            return this.context.Teachers.First(x => x.Id == _id);
        }

        public void Update(Teacher _item)
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
