using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class CatalogViewModel
    {
        public Catalog Catalog { get; set; }
        public List<Page> Pages { get; set; }
        public int? SavedCatalogId { get; set; }
        public string NextCatalogTitle { get; set; }
        public string NextCatalogMoniker { get; set; }
        public int PageId { get; set; }
    }
}
