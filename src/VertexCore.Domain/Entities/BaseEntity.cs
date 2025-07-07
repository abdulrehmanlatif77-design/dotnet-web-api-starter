namespace VertexCore.Domain.Entities
{
    /**
     * BaseEntity class serves as a base class for all entities in the domain.
     * It provides common properties such as Id, CreatedAt, and UpdatedAt.
     * This class can be extended by other entities to inherit these properties.
     **/
    public abstract class BaseEntity<T>
    {
        public required T Id { get; set; } // Unique identifier for the entity.
        public DateTime CreatedAt { get; set; } // Timestamp for when the entity was created
        public DateTime? UpdatedAt { get; set; } // Timestamp for when the entity was last updated
    }
}