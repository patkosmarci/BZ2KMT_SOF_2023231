using BZ2KMT_SOF_2023231.Models;
using System.Collections.Generic;
using System.Linq;

namespace BZ2KMT_SOF_2023231.Logic
{
    public interface ISchoolLogic
    {
        int CountAll(int _id);
        void Create(School _item);
        void Delete(int _id);
        School Read(int _id);
        IQueryable<School> ReadAll();
        School ReadName(string _name);
        double SchoolGradesAVG(int _schoolId);
        int SchoolSalaryAVG(int _SchoolId);
        IEnumerable<Student> StudentsOfSchool(int _schoolId);
        IEnumerable<Teacher> TeachersOfSchool(int _schoolId);
        void Update(School _school);
    }
}