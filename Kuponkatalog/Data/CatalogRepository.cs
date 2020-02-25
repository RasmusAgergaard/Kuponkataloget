using Kuponkatalog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuponkatalog.Data
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly AppDbContext _appDbContext;

        public CatalogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddCatalog(Catalog catalog)
        {
            _appDbContext.Catalogs.Add(catalog);
            _appDbContext.SaveChanges();
        }

        public void AddPageToCatalog(int catalogId, int pageId)
        {
            var pageRepository = new PageRepository(_appDbContext);
            var catalog = GetCatalogById(catalogId);
            var page = pageRepository.GetPageById(pageId).Page;

            _appDbContext.Add(new CatalogPages { Catalog = catalog.Catalog, Page = page });
            _appDbContext.SaveChanges();
        }

        public void DeleteCatalogById(int id)
        {
            var catalog = _appDbContext.Catalogs.FirstOrDefault(c => c.CatalogId == id);
            _appDbContext.Catalogs.Remove(catalog);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<CatalogViewModel> GetActiveCatalogs()
        {
            var catalogViewModels = new List<CatalogViewModel>();
            var catalogs = _appDbContext.Catalogs;

            foreach (var catalog in catalogs)
            {
                if (catalog.Status == Enums.catalogStatus.Active)
                {
                    var catalogViewModel = new CatalogViewModel();

                    catalogViewModel.Catalog = catalog;
                    catalogViewModel.Pages = GetCatalogPages(catalog.CatalogId);

                    catalogViewModels.Add(catalogViewModel);
                }
            };

            catalogViewModels = catalogViewModels.OrderByDescending(c => c.Catalog.CatalogId).ToList();

            return catalogViewModels;
        }

        public IEnumerable<CatalogViewModel> GetAllCatalogs()
        {
            var catalogViewModels = new List<CatalogViewModel>();
            var catalogs = _appDbContext.Catalogs;

            foreach (var catalog in catalogs)
            {
                var catalogViewModel = new CatalogViewModel();

                catalogViewModel.Catalog = catalog;
                catalogViewModel.Pages = GetCatalogPages(catalog.CatalogId);

                catalogViewModels.Add(catalogViewModel);
            };

            return catalogViewModels;
        }

        public List<int> GetActiveCatalogIds()
        {
            var allCatalogs = _appDbContext.Catalogs;
            var catalogIds = new List<int>();

            foreach (var catalog in allCatalogs)
            {
                if (catalog.Status == Enums.catalogStatus.Active)
                {
                    catalogIds.Add(catalog.CatalogId);
                }
            }

            return catalogIds;
        }

        public CatalogViewModel GetCatalogById(int id)
        {
            var pages = GetCatalogPages(id);
            var catalog = _appDbContext.Catalogs.FirstOrDefault(c => c.CatalogId == id);
            var catalogViewModel = new CatalogViewModel { Pages = pages, Catalog = catalog };

            return catalogViewModel;
        }

        public CatalogViewModel GetCatalogByMoniker(string moniker)
        {
            //Set catalog and pages
            var catalog = _appDbContext.Catalogs.FirstOrDefault(c => c.Moniker == moniker);

            if (catalog == null)
            {
                //Return a empty CatalogViewModel
                return new CatalogViewModel { Catalog = null };
            }

            var pages = GetCatalogPages(catalog.CatalogId);
            var catalogViewModel = new CatalogViewModel { Pages = pages, Catalog = catalog };

            //Set the next and previous catalog
            var catalogs = _appDbContext.Catalogs.ToList();
            var index = catalogs.IndexOf(catalog);
            var nextIndex = index - 1;

            if (nextIndex >= 0)
            {
                catalogViewModel.NextCatalogMoniker = catalogs[nextIndex].Moniker;
                catalogViewModel.NextCatalogTitle = catalogs[nextIndex].Title;
            }
            else
            {
                catalogViewModel.NextCatalogMoniker = catalogs[catalogs.Count - 1].Moniker;
                catalogViewModel.NextCatalogTitle = catalogs[catalogs.Count - 1].Title;
            }

            //Return the model
            return catalogViewModel;
        }

        public List<Page> GetCatalogPages(int catalogId)
        {
            var pageRepository = new PageRepository(_appDbContext);
            var pages = new List<Page>();

            //Add front- and backpage
            var frontPage = new Page { Type = Enums.pageTypes.FrontPage, Title = "Forsiden", Moniker = "Forside", SortNumber = 1 };
            var backPage = new Page { Type = Enums.pageTypes.BackPage, Title = "Bagsiden", Moniker = "Bagside", SortNumber = 99 };
            pages.Add(frontPage);
            pages.Add(backPage);

            foreach (var item in _appDbContext.CatalogPages)
            {
                if (item.CatalogId == catalogId)
                {
                    var page = pageRepository.GetPageById(item.PageId).Page;

                    if (page.Status == Enums.pageStatus.Active)
                    {
                        pages.Add(page);
                    } 
                }
            }

            pages = pages.OrderBy(p => p.SortNumber).ToList();

            return pages;
        }

        public Catalog GetFrontPageCatalog()
        {
            var catalog = _appDbContext.Catalogs.FirstOrDefault(c => c.ShowOnFrontpage == true);

            return catalog;
        }

        public void UpdateCatalog(CatalogViewModel catalogViewModel)
        {
            var newCatalog = catalogViewModel.Catalog;
            newCatalog.CatalogId = (int)catalogViewModel.SavedCatalogId;

            _appDbContext.Catalogs.Update(newCatalog);
            _appDbContext.SaveChanges();
        }

        public void RemovePageFromCatalog(int catalogId, int pageId)
        {
            var catalogPages = _appDbContext.CatalogPages.ToList();

            foreach (var item in catalogPages)
            {
                if (item.PageId == pageId && item.CatalogId == catalogId)
                {
                    _appDbContext.CatalogPages.Remove(item);
                    _appDbContext.SaveChanges();
                }
            }
        }
    }
}
