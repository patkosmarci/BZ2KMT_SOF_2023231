using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BZ2KMT_SOF_2023231.Repository;
using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Logic
{
    public class StudentLogic : IStudentLogic
    {
        StudentRepository repository;

        public StudentLogic(StudentRepository _strepo)
        {
            repository = _strepo;
        }

        public void Create(Student _item)
        {
            if (_item.Name == null || _item.Name.Length > 80) throw new Exception("Name is wrong");
            else if (_item.SchoolId == null) throw new Exception("SchollId cannot be null");
            else if (_item.Age == null || _item.Age < 6 || _item.Age > 28) throw new Exception("Age must be between 6 and 28");
            else if (_item.GradesAVG != null && (_item.GradesAVG < 1 || _item.GradesAVG > 5)) throw new Exception("GradesAVG can't be less than 1 and greather than 5");
            this.repository.Create(_item);
        }
        public void Delete(int _id)
        {
            this.repository.Delete(_id);
        }
        public Student Read(int _id)
        {
            var student = this.repository.Read(_id);
            if (student == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return student;
        }
        public IQueryable<Student> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Student _student)
        {
            this.repository.Update(_student);
        }

        //Non CRUD methods
        /// <summary>
        /// Read metódus név alapján - lassabb
        /// </summary>
        public Student ReadName(string _name)
        {
            IQueryable<Student> all = this.repository.ReadAll();
            return all.First(t => t.Name.Equals(_name));
        }

        /// <summary>
        /// Returns the student with the biggest avarage grade
        /// </summary>
        /// <returns></returns>
        public Student BestStudent()
        {
            IQueryable<Student> students = this.repository.ReadAll();
            double bestavg = students.Max(t => t.GradesAVG);
            return students.First(t => t.GradesAVG == bestavg);
        }

        /// <summary>
        /// Returns the avarage age of all students
        /// </summary>
        /// <returns></returns>
        public double AvarageAge()
        {
            IQueryable<Student> students = this.repository.ReadAll();
            double sum = students.Sum(t => t.Age) / students.Count();
            return sum;
        }

        /// <summary>
        /// Returns the students under the avarage age
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> YoungStudents()
        {
            double avgAge = this.AvarageAge();
            IEnumerable<Student> all = this.repository.ReadAll();
            return all.Where(t => t.Age <= avgAge);
        }
    }
}
