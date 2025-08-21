﻿using System.ComponentModel.DataAnnotations;

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
    }
}
