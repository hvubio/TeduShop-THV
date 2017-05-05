using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tự động tăng
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public int? HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}