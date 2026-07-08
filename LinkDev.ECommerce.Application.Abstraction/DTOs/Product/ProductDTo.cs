using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Application.Abstraction.DTOs.Product
{
    public record ProductDTo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public int? BrandId { get; set; } 
        public string? ProductBrand { get; set; }
        public int? CategoryId { get; set; } 
        public string? ProductCategory { get; set; }
    }
}
