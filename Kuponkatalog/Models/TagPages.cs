namespace Kuponkatalog.Models
{
    public class TagPages
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}
