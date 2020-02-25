using Kuponkatalog.Models;
using System.Collections.Generic;

namespace Kuponkatalog.Data
{
    public interface IPageRepository
    {
        void AddPage(Page page);
        IEnumerable<Page> GetAllPages();
        IEnumerable<Page> GetAllActivePages();
        PageViewModel GetPageById(int id);
        PageViewModel GetPageByMoniker(string moniker);
        void UpdatePage(PageViewModel pageViewModel);
        void DeletePageById(int id);
        IEnumerable<PageAdminViewModel> GetPagesWithCatalogs();
        List<Catalog> GetPageCatalogs(int pageId);
        IEnumerable<Page> GetNewPages(int numberOfPages);
    }
}
