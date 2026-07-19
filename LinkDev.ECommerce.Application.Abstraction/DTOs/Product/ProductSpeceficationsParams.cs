using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Application.Abstraction.DTOs.Product
{
    public record ProductSpeceficationsParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }

        private const int MaxSize = 100;
        public int PageIndex { get; set; } = 1;
        private int pageSize = 10;

        public int PageSize 
        {
            get => pageSize;
            set => pageSize = value > MaxSize ? MaxSize : value;
        }

        private string? search;
        public string? Search
        {
            get => search;
            set => search = value?.ToUpper();
        }

    }
}
