using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }

        [Key]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Product Product { get; set; }

        [ForeignKey("ProductId")]
        public virtual Order Order { get; set; }
    }
}