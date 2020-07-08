using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpenAuth.Mvc.Controllers
{
    public class DiaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}