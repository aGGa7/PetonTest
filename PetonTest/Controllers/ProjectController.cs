using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetonTest.Controllers
{
    public class ProjectController : Controller
    {
        IGenericRepository<Pr>
        public IActionResult Index()
        {
            return View();
        }
    }
}
