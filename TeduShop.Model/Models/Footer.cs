using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tự động tăng
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}