using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VertexCore.Domain.Enums;

namespace VertexCore.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public required string OrderNumber { get; set; } // Unique identifier for the order
        public Guid CustomerId { get; set; } // Foreign key to the customer who placed the order
        public decimal TotalAmount { get; set; } // Total amount for the order
        public OrderStatus Status { get; set; } // Current status of the order (e.g., Pending, Completed, Cancelled)
        public DateTime OrderDate { get; set; } // Date when the order was placed
        public List<OrderItem> OrderItems { get; set; } = []; // List of products in the order

        
    }
}