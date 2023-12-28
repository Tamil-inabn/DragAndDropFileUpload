using DragAndDrop.DbContexts;
using DragAndDrop.EntityModels;
using DragAndDrop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace DragAndDrop.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UploadFileContext _context;
        public HomeController(UploadFileContext context)
        {
            _context= context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile files)
        {
            if (files != null && files.Length > 0)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filename = Path.GetFileName(files.FileName);
                string Guids = Guid.NewGuid() + Path.GetExtension(files.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, Guids), FileMode.Create))
                {
                    files.CopyTo(stream);
                }

                Register register = new Register()
                {
                    FirstName = "test",
                    LastName = "test",
                    Address = "test",
                    Email = "test@gmail.com",
                    Mobile = 9876543210,
                    Gender = "male"
                };
                _context.Registers.Add(register);
                _context.SaveChanges();
                var id = _context.Registers.OrderByDescending(m => m.Id).First().Id;
                Attachment attachment = new Attachment()
                {
                    Photo = files.FileName,
                    Document = files.FileName,
                    No=id
                };
                _context.Attachments.Add(attachment);
                _context.SaveChanges();
                return Json(new { success = true, message = "File uploaded successfully!" });
            }

            return Json(new { success = false, message = "Invalid file or empty file!" });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}