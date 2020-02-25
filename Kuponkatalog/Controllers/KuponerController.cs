using Kuponkatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    [Route("[controller]")]
    public class KuponerController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public KuponerController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            var activePages = _pageRepository.GetAllActivePages();

            return View(activePages);
        }

        [HttpGet("{pageMoniker}")]
        public IActionResult Kupon(string pageMoniker)
        {
            var pageViewModel = _pageRepository.GetPageByMoniker(pageMoniker);

            return View(pageViewModel);
        }
    }
}