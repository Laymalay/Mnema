using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Mnema.Models;
using System.IO;
using AuthApp.ViewModels;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mnema.Controllers
{
    public class ProfileController : Controller
    {
        UserContext _context;
        IHostingEnvironment _appEnvironment;


        public ProfileController(UserContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;

        }

       [Authorize]
        public IActionResult Index()
        {
            // var user = from u in _context.Users
            //            where u.Email == User.Identity.Name
            //            select u;
            var user = _context.Users.Include("Photos").FirstOrDefault(u => u.Email == User.Identity.Name);
            return View(user);
        }

         public async Task<IActionResult> DeleteProfileAsync()
        {
            var user = await _context.Users.Include("Photos").FirstOrDefaultAsync(u => u.Email == User.Identity.Name );
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
            //TODO: delete all photo, likes, comments etc
        }

        [HttpGet]
        public IActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(UploadPhotoModel model)
        {
            if (model.uploadedFile != null)
            {
                var user = _context.Users.Include("Photos").Where(u => u.Email == User.Identity.Name).First();
                // string path = "/Photos/" + "/" + user.Email;

                //  if (!Directory.Exists(path))
                // {
                //     Directory.CreateDirectory(path);
                // }
                // path = path + "/" + model.uploadedFile.FileName;
                string path = "/Photos/" + model.uploadedFile.FileName;
                // сохраняем файл в папку Photos/userEmail/ в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.uploadedFile.CopyToAsync(fileStream);
                }

                var photo = new Photo { Name = model.uploadedFile.FileName,
                                        Path = path ,
                                        Description = model.Description };
                Console.WriteLine(photo.Name, photo.Path, photo.Description,photo.UserId, photo.User);
                user.Photos.Add(photo);
                _context.Photos.Add(photo);
                _context.SaveChanges();
                // foreach(Photo p in user.Photos)
                //     Console.WriteLine("photo:" + p.Name + p.Path);
                Console.WriteLine(user.Photos.Count());
                }


            return RedirectToAction("Index", "Profile");

        }
    }
}
