using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class SitemapViewModel
    {
        public SitemapViewModel()
        {
            kategorier = new List<KategoriViewModel>();
            categories = new List<Category>();
        }

        public List<KategoriViewModel> kategorier { get; set; }
        public List<Category> categories { get; set; }
    }
}
