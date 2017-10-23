using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthApp.Models;
using Microsoft.AspNetCore.Mvc;
using Mnema.Models;

namespace Mnema.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }


    }
}
