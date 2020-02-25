using Kuponkatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    public class NyhederController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public NyhederController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            return View(_pageRepository.GetNewPages(30));
        }
    }
}