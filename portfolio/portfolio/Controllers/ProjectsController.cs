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
                    Name = "Project 3",
                    Description = "This project was my first shot at using a database and chatGPTs API.",
                    Type = "CS 330 - Web Development",
                    Images = LoadImages("Assets/Project3"),
                    URLs = ["https://github.com/morrowwc/Fall2024-Assignment3-wcmorrow2",
                            "https://fall2024-assignment3-wcmorrow2.azurewebsites.net/"]
                },
                new Project
                {
                    Name = "Project Two",
                    Description = "Description of project two.",
                    Type = "Art",
                    Images = LoadImages("Assets/TestProject"),
                    URLs = ["https://example.com/project-two"]
                }
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
