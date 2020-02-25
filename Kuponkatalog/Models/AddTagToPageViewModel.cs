using System.Collections.Generic;

namespace Kuponkatalog.Models
{
    public class AddTagToPageViewModel
    {
        public AddTagToPageViewModel()
        {
            TagsAvalible = new List<Tag>();
            TagsOnPage = new List<Tag>();
        }

        public int TagId { get; set; }
        public int PageId { get; set; }
        public List<Tag> TagsAvalible { get; set; }
        public List<Tag> TagsOnPage { get; set; }
    }
}
