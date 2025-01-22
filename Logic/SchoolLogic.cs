using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BZ2KMT_SOF_2023231.Repository;
using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Logic
{
    public class SchoolLogic : ISchoolLogic
    {
        SchoolRepository repository;

        public SchoolLogic(SchoolRepository _screpo)
        {
            repository = _screpo;
        }
        public void Create(School _item)
        {
            if (_item.Name == null || _item.Name.Length > 100) throw new Exception("School name is wrong");
            else if (_item.Type == null) throw new Exception("School type cannot be null");
            else this.repository.Create(_item);
        }
        public void Delete(int _id)
        {
            this.repository.Delete(_id);
        }
        public School Read(int _id)
        {
            var school = this.repository.Read(_id);
            if (school == null)
            {
                throw new ArgumentException("School doesn't exists");
            }

            return school;
        }
        public IQueryable<School> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(School _school)
        {
            this.repository.Update(_school);
        }
        //Non CRUD methods

        ///<summary>
        ///Visszaadja az iskolaba jaro diakok osszesitett atlagat
        ///</summary>
        public double SchoolGradesAVG(int _schoolId) //Többtáblás
        {
            School school = Read(_schoolId);

            ICollection<Student> _students = school.Students;
            if (_students.Count() == 0) throw new Exception("School has zero students");
            double sum = 0;
            foreach (Student st in _students)
            {
                sum += st.GradesAVG;
            }
            return sum / _students.Count();
        }
        /// <summary>
        /// Read metódus név alapján - lassabb
        /// </summary>
        public School ReadName(string _name)
        {
            IQueryable<School> all = this.repository.ReadAll();
            return all.First(t => t.Name.Equals(_name));
        }

        /// <summary>
        /// Returns how many people are working AND learning there
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public int CountAll(int _id) //Többtáblás
        {
            School sch = repository.Read(_id);
            return sch.Students.Count() + sch.Teachers.Count();
        }

        /// <summary>
        /// Returns the teachers of a school
        /// </summary>
        /// <param name="_schoolId"></param>
        /// <returns></returns>
        public IEnumerable<Teacher> TeachersOfSchool(int _schoolId) //Többtáblás
        {
            School sch = repository.Read(_schoolId);
            return sch.Teachers;
        }

        /// <summary>
        /// Returns the students of a school
        /// </summary>
        /// <param name="_schoolId"></param>
        /// <returns></returns>
        public IEnumerable<Student> StudentsOfSchool(int _schoolId) //Többtáblás
        {
            School sch = repository.Read(_schoolId);
            return sch.Students;
        }

        /// <summary>
        /// Returns the avarage salary in the school
        /// </summary>
        /// <param name="_SchoolId"></param>
        /// <returns></returns>
        public int SchoolSalaryAVG(int _SchoolId) //Többtáblás
        {
            School sch = repository.Read(_SchoolId);
            var teachers = sch.Teachers;
            if (teachers.Count() == 0) throw new Exception("School has zero teachers");
            int sum = 0;
            foreach (Teacher teacher in teachers)
            {
                sum += teacher.Salary;
            }
            return sum / teachers.Count();
        }
    }
}
