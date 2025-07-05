using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VertexCore.Domain.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string? Name { get; set; } // Name of the product
        public string? Description { get; set; } // Description of the product
        public decimal Price { get; set; } // Price of the product
        public bool IsActive { get; set; } // Indicates if the product is active, true if available for sale
    }
}