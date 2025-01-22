using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BZ2KMT_SOF_2023231.Repository;
using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Logic
{
    public class TeacherLogic : ITeacherLogic
    {
        TeacherRepository repository;

        public TeacherLogic(TeacherRepository _tchrepo)
        {
            repository = _tchrepo;
        }

        public void Create(Teacher _item)
        {
            this.repository.Create(_item);
        }

        public void Delete(int _id)
        {
            this.repository.Delete(_id);
        }

        public Teacher Read(int _id)
        {
            var teacher = this.repository.Read(_id);
            if (teacher == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return teacher;
        }

        public IQueryable<Teacher> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Teacher _teacher)
        {
            this.repository.Update(_teacher);
        }

        //Non CRUD methods

        /// <summary>
        /// Read metódus név alapján - lassabb
        /// </summary>
        public Teacher ReadName(string _name)
        {
            IQueryable<Teacher> all = this.repository.ReadAll();
            return all.First(t => t.Name.Equals(_name));
        }

        /// <summary>
        /// Returns the teacher who has the highest salary
        /// </summary>
        /// <returns></returns>
        public Teacher MostPaidTeacher()
        {
            IQueryable<Teacher> teachers = this.repository.ReadAll();
            int maxsalary = teachers.Max(Teacher => Teacher.Salary);
            return teachers.First(t => t.Salary.Equals(maxsalary));
        }

        /// <summary>
        /// Returns the teacher who has the lowest salary
        /// </summary>
        /// <returns></returns>
        public Teacher LeastPaidTeacher()
        {
            IQueryable<Teacher> teachers = this.repository.ReadAll();
            int minsalary = teachers.Min(Teacher => Teacher.Salary);
            return teachers.First(t => t.Salary.Equals(minsalary));
        }
    }

}
