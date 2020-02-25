using Kuponkatalog.Data;
using Kuponkatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kuponkatalog.Controllers
{
    public class SitemapController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;

        public SitemapController(ICategoryRepository categoryRepository, ITagRepository tagRepository)
        {
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            var sitemapViewModel = new SitemapViewModel();

            var tags = _tagRepository.GetAllTags();

            foreach (var tag in tags)
            {
                sitemapViewModel.kategorier.Add(_tagRepository.GetKategoriAndPages(tag.Moniker));
            }

            sitemapViewModel.categories = _categoryRepository.GetAllCategorys().ToList();

            return View(sitemapViewModel);
        }
    }
}