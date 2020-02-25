using Kuponkatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    public class AlleController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public AlleController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            var activePages = _pageRepository.GetAllActivePages();

            return View(activePages);
        }
    }
}