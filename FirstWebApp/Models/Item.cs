using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime Created {  get; set; } = DateTime.Now;
    }
}
