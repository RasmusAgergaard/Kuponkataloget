using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Kuponkatalog.Models.Enums;

namespace Kuponkatalog.Models
{
    public class Catalog
    {
        public Catalog()
        {
            CreateDate = DateTime.Now.ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatalogId { get; set; }
        public string Moniker { get; set; }

        public catalogStatus Status { get; set; }
        public string CreateDate { get; set; }
        public string LastEditDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string BgImgUrl { get; set; }
        public bool ShowOnFrontpage { get; set; }
        public ICollection<CatalogPages> CatalogPages { get; } = new List<CatalogPages>();
    }
}
