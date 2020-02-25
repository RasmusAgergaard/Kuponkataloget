using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuponkatalog.Models
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        public string Moniker { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<TagPages> TagPages { get; } = new List<TagPages>();
    }
}
