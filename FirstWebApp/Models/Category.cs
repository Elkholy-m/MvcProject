using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        // Navigation Property
        public ICollection<Item>? Items { get; set; }

        // Save Image To DB
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
        public byte[]? ImgaeDB { get; set; }

        [NotMapped]
        public string? ImageSrc
        {
            get
            {
                if (ImgaeDB != null)
                {
                    string base64String = Convert.ToBase64String(ImgaeDB);
                    return "data:image/jpeg;base64," + base64String;
                }
                return string.Empty;
            }
        }
    }
}
