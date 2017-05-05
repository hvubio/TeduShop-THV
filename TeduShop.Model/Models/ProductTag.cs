using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        public int ProductId { get; set; }

        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string TagId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}