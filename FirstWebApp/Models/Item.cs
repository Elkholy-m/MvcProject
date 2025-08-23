using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? ImgPath { get; set; }
        [NotMapped]
        public IFormFile? ClientFile {  get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
        [Required]
        [DisplayName("The Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation Property  (One To Many Relation Ship)
        public Category? Category { get; set; }
    }
}
