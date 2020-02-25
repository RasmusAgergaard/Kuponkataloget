using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class PageAdminViewModel
    {
        public Page Page { get; set; }
        public List<Catalog> Catalogs { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
