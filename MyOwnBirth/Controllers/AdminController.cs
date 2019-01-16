using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyOwnBirth.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}