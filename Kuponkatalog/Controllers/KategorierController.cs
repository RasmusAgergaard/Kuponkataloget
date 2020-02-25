using Kuponkatalog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kuponkatalog.Controllers
{
    [Route("[controller]")]
    public class KategorierController : Controller
    {
        private readonly ITagRepository _tagRepository;

        public KategorierController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            var tags = _tagRepository.GetAllTags();

            return View(tags);
        }

        [HttpGet("{tagMoniker}")]
        public IActionResult Kategori(string tagMoniker)
        {
            var kategoriViewModel = _tagRepository.GetKategoriAndPages(tagMoniker);

            return View(kategoriViewModel);
        }
    }
}