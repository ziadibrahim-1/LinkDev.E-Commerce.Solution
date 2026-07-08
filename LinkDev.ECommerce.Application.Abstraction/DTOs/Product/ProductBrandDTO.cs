using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.ECommerce.Application.Abstraction.DTOs.Product
{
    public  record ProductBrandDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
