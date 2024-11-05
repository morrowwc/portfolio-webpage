using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Collections.Generic;

namespace portfolio.Controllers
{
    public class ProjectController : Controller
    {
        private static List<Project> _projects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Name = "Project One",
                Description = "Description of project one.",
                Images = new List<byte[]>(), // Add byte array images here
                URL = "https://example.com/project-one"
            },
            new Project
            {
                Id = 2,
                Name = "Project Two",
                Description = "Description of project two.",
                Images = new List<byte[]>(), // Add byte array images here
                URL = "https://example.com/project-two"
            }
            // Add more projects as needed
        };

        // GET: ProjectController
        public ActionResult Index()
        {
            return View(_projects);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
    }
}
