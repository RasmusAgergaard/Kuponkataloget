using Kuponkatalog.Models;
using System.Collections.Generic;

namespace Kuponkatalog.Data
{
    public interface ICatalogRepository
    {
        void AddCatalog(Catalog catalog);
        IEnumerable<CatalogViewModel> GetAllCatalogs();
        IEnumerable<CatalogViewModel> GetActiveCatalogs();
        List<int> GetActiveCatalogIds();
        CatalogViewModel GetCatalogById(int id);
        CatalogViewModel GetCatalogByMoniker(string moniker);
        Catalog GetFrontPageCatalog();
        void DeleteCatalogById(int id);
        void AddPageToCatalog(int catalogId, int pageId);
        void RemovePageFromCatalog(int catalogId, int pageId);
        void UpdateCatalog(CatalogViewModel catalogViewModel);
        List<Page> GetCatalogPages(int catalogId);
    }
}
