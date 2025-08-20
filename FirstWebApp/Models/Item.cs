using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [DisplayName("The Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("The Price")]
        [Range(10, 1000, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
    }
}
