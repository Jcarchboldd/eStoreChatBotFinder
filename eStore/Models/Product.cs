using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace eStore.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}