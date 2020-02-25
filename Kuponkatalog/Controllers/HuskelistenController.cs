using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    public class HuskelistenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}