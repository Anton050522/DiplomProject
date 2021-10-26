using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class FileController : Controller
    {
        private readonly IUserServices _userServices;

        public static UserIndexViewModel currentModel;

        private readonly string wwwrootDirectory =
           Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");


        public FileController(IUserServices _userServices)
        {
            this._userServices = _userServices;
        }
        public IActionResult GetOne(int id)
        {
            var _user = _userServices.GetById(id);

            var model = new UserInfo
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                SurName = _user.SurName,
                Email = _user.Email


            };
            return PartialView(model);
        }
        public IActionResult Index()
        {
            List<string> file = Directory.GetFiles(wwwrootDirectory, "")
                .Select(Path.GetFileName)
                .ToList();

            return View(file);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myFile)
        {
            if (myFile != null)
            {
                var path = Path.Combine(wwwrootDirectory,
                    DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName));

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }
                return RedirectToAction("Index");

            }

            return View();
        }
        public async Task<IActionResult> DownloadFile(string filePath)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);



            return File(memory, contentType, fileName);


        }
    }
}
