using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FCS.Test.Models;

namespace FCS.Test.Controllers
{
    public class HomeController : Controller
    {
        public static ClassRoom ClassRoom;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(ClassRoom);
        }
        
        public IActionResult Details(string id)
        {
            var student = ClassRoom.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadFiles(List<Student> students)
        {
            foreach (var student in students)
            {
                await ClassRoom.SaveImage(student.Id, student.FormFile);
            }
            return View("Index", ClassRoom);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}