using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertexCore.Domain.Entities
{
    public class OrderItem : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; } // Foreign key to the order
        public Guid ProductId { get; set; } // Foreign key to the product
        public int Quantity { get; set; } // Quantity of the product in the order
        public decimal Price { get; set; } // Price of the product at the time of order

        // Navigation properties
        public virtual required Order Order { get; set; } // Navigation property to the order
        public virtual required Product Product { get; set; } // Navigation property to the product
    }
}