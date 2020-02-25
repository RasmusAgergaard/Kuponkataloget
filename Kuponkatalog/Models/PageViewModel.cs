using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class PageViewModel
    {
        public PageViewModel()
        {
            KategoriViewModels = new List<KategoriViewModel>();
            AllTags = new List<Tag>();
        }

        public Page Page { get; set; }
        public int? SavedPageId { get; set; }
        public List<KategoriViewModel> KategoriViewModels { get; set; }
        public List<Tag> AllTags { get; set; }
    }
}
