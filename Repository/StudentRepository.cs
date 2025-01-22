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
    public class StudentRepository : IStudentRepository
    {
        protected SchollingDbContext context;
        public StudentRepository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(Student _item)
        {
            context.Set<Student>().Add(_item);
            context.SaveChanges();
        }

        public void Delete(int _id)
        {
            context.Set<Student>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<Student> ReadAll()
        {
            return context.Set<Student>();
        }
        public Student Read(int _id)
        {
            return this.context.Students.First(x => x.Id == _id);
        }

        public void Update(Student _item)
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
