using Kuponkatalog.Models;
using System.Collections.Generic;

namespace Kuponkatalog.Data
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAllTags();
        IEnumerable<Tag> GetTagsForPage(int pageId);
        IEnumerable<Page> GetPagesForTag(int tagId);
        KategoriViewModel GetKategoriAndPages(string tagMoniker);
        void AddTagToPage(int tagId, int pageId);
        void RemoveTagFromPage(int tagId, int pageId);
        Tag GetTagById(int tagId);
        Tag GetTagByMoniker(string tagMoniker);
    }
}
