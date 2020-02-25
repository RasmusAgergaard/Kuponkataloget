namespace Kuponkatalog.Models
{
    public class Enums
    {
        public enum pageTypes
        {
            FrontPage,
            Affiliate,
            BackPage
        }

        public enum pageStatus
        {
            Active,
            Expired
        }

        public enum catalogStatus
        {
            Draft,
            Active,
            Archived
        }

        public enum messageStatus
        {
            Unread,
            Read,
            Archived
        }
    }
}
