using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mnema.Models;

namespace Mnema.Controllers
{
    public class GalleryController : Controller
    {
         UserContext db;
        public GalleryController(UserContext context)
        {
            db = context;
        }

       [Authorize]
        public IActionResult Index()
        {

            return View();
        }

    }
}
