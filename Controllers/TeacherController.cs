using BZ2KMT_SOF_2023231.Logic;
using BZ2KMT_SOF_2023231.Models;
using BZ2KMT_SOF_2023231.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BZ2KMT_SOF_2023231.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherRepository repo;
        ISchoolRepository schoolRepo;

        public TeacherController(ITeacherRepository repo, ISchoolRepository schoolrepo)
        {
            this.repo = repo;
            this.schoolRepo = schoolrepo;
        }

        public IActionResult Index()
        {
            return View(repo.ReadAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Create(Teacher teacher)
        {

            repo.Create(teacher);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            var teacher = repo.Read(id);
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Update(Teacher teacher)
        {
            var DbTeacher = repo.Read(teacher.Id);
            DbTeacher.Salary = teacher.Salary;
            DbTeacher.Name = teacher.Name;
            DbTeacher.MainSubject = teacher.MainSubject;
            DbTeacher.SchoolId = teacher.SchoolId;
            DbTeacher.School = schoolRepo.Read(teacher.SchoolId);
            repo.Update(DbTeacher);
            return RedirectToAction(nameof(Index));
        }
    }
}
