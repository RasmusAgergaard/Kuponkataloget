using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Kuponkatalog.Models.Enums;

namespace Kuponkatalog.Models
{
    public class Page
    {
        public Page()
        {
            CreateDate = DateTime.Now.ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PageId { get; set; }
        public string Moniker { get; set; }

        public pageStatus Status { get; set; }
        public string CreateDate { get; set; }
        public string LastEditDate { get; set; }
        public pageTypes Type { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
        public string ButtonText { get; set; }
        public string TargetUrl { get; set; }
        public int SortNumber { get; set; }

        public ICollection<CatalogPages> CatalogPages { get; } = new List<CatalogPages>();
        public ICollection<TagPages> TagPages { get; } = new List<TagPages>();
    }
}
