using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VertexCore.Domain.Entities
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; } // Unique identifier for the entity
        public DateTime CreatedAt { get; set; } // Timestamp for when the entity was created
        public DateTime? UpdatedAt { get; set; } // Timestamp for when the entity was last updated
    }
}