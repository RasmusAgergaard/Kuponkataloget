using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuponkatalog.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string LinkName { get; set; }
    }
}
