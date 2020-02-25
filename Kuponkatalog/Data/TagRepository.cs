using Kuponkatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuponkatalog.Data
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _appDbContext;

        public TagRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddTagToPage(int tagId, int pageId)
        {
            var pageRepository = new PageRepository(_appDbContext);
            var tag = GetTagById(tagId);
            var page = pageRepository.GetPageById(pageId).Page;

            _appDbContext.Add(new TagPages { Page = page, Tag = tag });
            _appDbContext.SaveChanges();
        }

        public void RemoveTagFromPage(int tagId, int pageId)
        {
            //var pageRepository = new PageRepository(_appDbContext);
            //var tag = GetTagById(tagId);
            //var page = pageRepository.GetPageById(pageId).Page;

            //_appDbContext.Remove(new TagPages { Page = page, Tag = tag });
            //_appDbContext.SaveChanges();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _appDbContext.Tags;
        }

        public KategoriViewModel GetKategoriAndPages(string tagMoniker)
        {
            var kategoriViewModel = new KategoriViewModel();

            kategoriViewModel.Tag = GetTagByMoniker(tagMoniker);
            kategoriViewModel.Pages = GetPagesForTag(kategoriViewModel.Tag.TagId).ToList();
            kategoriViewModel.AllTags = GetAllTags().ToList();

            return kategoriViewModel;
        }

        public IEnumerable<Page> GetPagesForTag(int tagId)
        {
            var pageRepository = new PageRepository(_appDbContext);
            var pages = new List<Page>();

            foreach (var item in _appDbContext.TagPages)
            {
                if (item.TagId == tagId)
                {
                    pages.Add(pageRepository.GetPageById(item.PageId).Page);
                }
            }

            return pages;
        }

        public Tag GetTagById(int tagId)
        {
            return _appDbContext.Tags.FirstOrDefault(t => t.TagId == tagId);
        }

        public Tag GetTagByMoniker(string tagMoniker)
        {
            return _appDbContext.Tags.FirstOrDefault(t => t.Moniker == tagMoniker);
        }

        public IEnumerable<Tag> GetTagsForPage(int pageId)
        {
            var tags = new List<Tag>();

            foreach (var item in _appDbContext.TagPages)
            {
                if (item.PageId == pageId)
                {
                    tags.Add(GetTagById(item.TagId));
                }
            }

            return tags;
        }


    }
}
