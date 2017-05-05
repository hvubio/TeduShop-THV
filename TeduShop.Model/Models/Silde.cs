using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    [Table("Sildes")]
    public class Silde
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Decsription { get; set; }

        [Required]
        [MaxLength(256)]
        public string Image { get; set; }

        [MaxLength(265)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
