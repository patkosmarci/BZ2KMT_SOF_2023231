using BZ2KMT_SOF_2023231.Logic;
using BZ2KMT_SOF_2023231.Models;
using BZ2KMT_SOF_2023231.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Newtonsoft.Json;
using System.ComponentModel;

namespace BZ2KMT_SOF_2023231.Controllers
{
    public class SchoolController : Controller
    {
        ISchoolRepository repo;
        private readonly UserManager<SiteUser> _userManager;

        public SchoolController(ISchoolRepository repo, UserManager<SiteUser> umanager)
        {
            this.repo = repo;
            _userManager = umanager;
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
        public IActionResult Create(School school, IFormFile imagedata)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            if (imagedata != null)
            {
                using (var stream = imagedata.OpenReadStream())
                {
                    byte[] buffer = new byte[imagedata.Length];
                    stream.Read(buffer, 0, (int)imagedata.Length);
                    string filename = $"{school.Id}_picture.{imagedata.FileName.Split('.')[1]}";
                    school.ImageFileName = filename;
                    System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                }
            }
            
            repo.Create(school);
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
            var school = repo.Read(id);
            return View(school);
        }
        
        [HttpPost]
        public IActionResult Update(School school, IFormFile imagedata)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var DbSchool = repo.Read(school.Id);
            if (imagedata != null)
            {
                using (var stream = imagedata.OpenReadStream())
                {
                    byte[] buffer = new byte[imagedata.Length];
                    stream.Read(buffer, 0, (int)imagedata.Length);
                    string filename = $"{school.Id}_picture.{imagedata.FileName.Split('.')[1]}";
                    if (!school.ImageFileName.Contains('.')) System.IO.File.Delete(Path.Combine("wwwroot", "images", school.ImageFileName));
                    school.ImageFileName = filename;
                    DbSchool.ImageFileName = filename;
                    System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                }
            }

            DbSchool.Age = school.Age;
            DbSchool.Name = school.Name;
            DbSchool.Type = school.Type;
            repo.Update(DbSchool);
            return RedirectToAction(nameof(Index));
        }


    }
}
