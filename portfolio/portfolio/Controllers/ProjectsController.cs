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
                    Id = Guid.NewGuid(),
                    Name = "Project 3",
                    TagDescription = "This project was the class's introduction into databases.",
                    FullDescription = "This was obviously the third project in CS 330 at Alabama. The outline of the project was to implement a website that could store Actors and Movies and associated date, like IMDB. " +
                    "There also needed to be AI generated reviews for the movies and tweets about the actors. We also used a sentiment analysis tool called VaderSharp2. All of this would need to be stored in a database using Azure.\n\n " +
                    "I had already taken a class on databases, but this was my first time implementing one. I was also still getting used to Azure and managing the resources for the project, but" +
                    "Azure (Microsoft) has a deal with OpenAI making the API really easy to use. ",
                    Type = "CS 330 - Web Development",
                    Images = LoadImages("Assets/Project3"),
                    URLs = ["https://github.com/morrowwc/Fall2024-Assignment3-wcmorrow2",
                            "https://fall2024-assignment3-wcmorrow2.azurewebsites.net/"]
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Project Two",
                    TagDescription = "Description of project two.",
                    FullDescription = "Description of project two.",
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
        public ActionResult Details(Guid id)
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
