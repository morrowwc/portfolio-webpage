using Microsoft.AspNetCore.Mvc;
using portfolio.Models;
using System.Collections.Generic;
using System.Linq;

namespace portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private static List<Project> _projects = InitializeProjects();

        private static List<Project> InitializeProjects()
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "Project One",
                    Description = "Description of project one.",
                    Type = "Programming",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-one"
                },
                new Project
                {
                    Id = 2,
                    Name = "Project Two",
                    Description = "Description of project two.",
                    Type = "Art",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-two"
                },
                new Project
                {
                    Id = 3,
                    Name = "Project Two",
                    Description = "Description of project two.",
                    Type = "Art",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-two"
                },
                new Project
                {
                    Id = 4,
                    Name = "Project Two",
                    Description = "Description of project two.",
                    Type = "Art",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-two"
                },
                new Project
                {
                    Id = 5,
                    Name = "Project One",
                    Description = "Description of project one.",
                    Type = "Programming",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-one"
                },
                new Project
                {
                    Id = 6,
                    Name = "Project One",
                    Description = "Description of project one.",
                    Type = "Programming",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-one"
                },new Project
                {
                    Id = 7,
                    Name = "Project One",
                    Description = "Description of project one.",
                    Type = "Programming",
                    Images = LoadImages("Assets/TestProject"),
                    URL = "https://example.com/project-one"
                },
            };
            return projects;
        }

        private static List<byte[]> LoadImages(string folderPath)
        {
            var images = new List<byte[]>();
            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), folderPath);

            if (Directory.Exists(absolutePath))
            {
                foreach (var filePath in Directory.GetFiles(absolutePath))
                {
                    images.Add(System.IO.File.ReadAllBytes(filePath));
                }
            }
            return images;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            var groupedProjects = _projects.GroupBy(p => p.Type)
                                           .ToDictionary(g => g.Key, g => g.ToList());
            return View(groupedProjects);
        }

        // GET: ProjectsController/Details/5
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
