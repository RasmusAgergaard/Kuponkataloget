using Kuponkatalog.Data;
using Kuponkatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kuponkatalog.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPageRepository _pageRepository;

        public HomeController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            var newPages = _pageRepository.GetNewPages(6);

            return View(newPages);
        }

        public IActionResult TakForDinTilmelding()
        {
            return View();
        }

        public IActionResult LukketKampagne()
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
