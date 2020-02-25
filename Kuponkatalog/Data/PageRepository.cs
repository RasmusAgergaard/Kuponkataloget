using Kuponkatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuponkatalog.Data
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _appDbContext;

        public PageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddPage(Page page)
        {
            _appDbContext.Page.Add(page);
            _appDbContext.SaveChanges();
        }

        public void DeletePageById(int id)
        {
            var page = _appDbContext.Page.FirstOrDefault(p => p.PageId == id);
            _appDbContext.Page.Remove(page);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Page> GetAllPages()
        {
            return _appDbContext.Page;
        }

        public IEnumerable<Page> GetAllActivePages()
        {
            var activePages = new List<Page>();

            foreach (var item in _appDbContext.Page)
            {
                if (item.Status == Enums.pageStatus.Active)
                {
                    activePages.Add(item);
                }
            }

            return activePages;
        }

        public PageViewModel GetPageById(int id)
        {
            var pageViewModel = new PageViewModel();
            var tagRepository = new TagRepository(_appDbContext);
            pageViewModel.Page = _appDbContext.Page.FirstOrDefault(p => p.PageId == id);
            pageViewModel.AllTags = tagRepository.GetTagsForPage(id).ToList();

            return pageViewModel;
        }

        public PageViewModel GetPageByMoniker(string moniker)
        {
            var pageViewModel = new PageViewModel();
            var tagRepository = new TagRepository(_appDbContext);
            pageViewModel.Page = _appDbContext.Page.FirstOrDefault(p => p.Moniker == moniker);
            pageViewModel.AllTags = tagRepository.GetAllTags().ToList();

            foreach (var tag in tagRepository.GetTagsForPage(pageViewModel.Page.PageId).ToList())
            {
                var kategoriViewModel = new KategoriViewModel();
                kategoriViewModel.Tag = tag;
                kategoriViewModel.Pages = tagRepository.GetPagesForTag(tag.TagId).ToList();
                pageViewModel.KategoriViewModels.Add(kategoriViewModel);
            }
            

            return pageViewModel;
        }
        public void UpdatePage(PageViewModel pageViewModel)
        {
            var newPage = pageViewModel.Page;
            newPage.PageId = (int)pageViewModel.SavedPageId;

            _appDbContext.Page.Update(newPage);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<PageAdminViewModel> GetPagesWithCatalogs()
        {
            var tagRepository = new TagRepository(_appDbContext);
            var pageAdminViewModels = new List<PageAdminViewModel>();

            foreach (var page in _appDbContext.Page)
            {
                var pageAdminViewModel = new PageAdminViewModel();

                pageAdminViewModel.Page = page;
                pageAdminViewModel.Catalogs = GetPageCatalogs(page.PageId);
                pageAdminViewModel.Tags = tagRepository.GetTagsForPage(page.PageId).ToList();

                pageAdminViewModels.Add(pageAdminViewModel);
            }

            return pageAdminViewModels;
        }

        public List<Catalog> GetPageCatalogs(int pageId)
        {
            var catalogRepository = new CatalogRepository(_appDbContext);
            var catalogs = new List<Catalog>();

            foreach (var item in _appDbContext.CatalogPages)
            {
                if (item.PageId == pageId)
                {
                    var catalog = catalogRepository.GetCatalogById(item.CatalogId).Catalog;
                    catalogs.Add(catalog);
                }
            }

            return catalogs;
        }

        public IEnumerable<Page> GetNewPages(int numberOfPages)
        {
            var allPages = _appDbContext.Page.OrderByDescending(p => p.PageId);

            var newPages = allPages.Take(numberOfPages);

            return newPages;
        }
    }
}
