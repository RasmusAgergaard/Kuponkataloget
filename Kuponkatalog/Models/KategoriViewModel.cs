using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class KategoriViewModel
    {
        public KategoriViewModel()
        {
            Pages = new List<Page>();
            AllTags = new List<Tag>();
        }

        public Tag Tag { get; set; }
        public List<Page> Pages { get; set; }
        public List<Tag> AllTags { get; set; }
    }
}
