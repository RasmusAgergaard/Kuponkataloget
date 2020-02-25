using Kuponkatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    [Route("[controller]")]
    public class KatalogerController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;

        public KatalogerController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public IActionResult Index()
        {
            var catalogs = _catalogRepository.GetActiveCatalogs();

            return View(catalogs);
        }

        [HttpGet("{catalogMoniker}/{pageMoniker}")]
        public IActionResult Details(string catalogMoniker, string pageMoniker)
        {
            var catalogViewModel = _catalogRepository.GetCatalogByMoniker(catalogMoniker);

            if (catalogViewModel.Catalog == null)
            {
                return NotFound();
            }

            catalogViewModel.PageId = 0;

            foreach (var page in catalogViewModel.Pages)
            {
                if (page.Moniker == pageMoniker)
                {
                    catalogViewModel.PageId = catalogViewModel.Pages.IndexOf(page);
                }
            }

            return View(catalogViewModel);
        }
    }
}