using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kuponkatalog.Models
{
    public class CatalogPages
    {
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}
