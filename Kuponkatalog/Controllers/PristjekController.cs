using Kuponkatalog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    public class PristjekController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public PristjekController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categorys = _categoryRepository.GetAllCategorys();

            return View(categorys);
        }

        public IActionResult Magasiner()
        {
            return View();
        }
        
        public IActionResult Mobilabonnement()
        {
            return View();
        }

        public IActionResult Bredbaand()
        {
            return View();
        }

        public IActionResult Akasse()
        {
            return View();
        }

        public IActionResult Dating()
        {
            return View();
        }

        public IActionResult Webhosting()
        {
            return View();
        }

    }
}