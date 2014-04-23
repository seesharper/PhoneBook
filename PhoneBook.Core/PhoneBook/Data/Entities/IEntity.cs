namespace Hik.PhoneBook.Data.Entities
{
    /// <summary>
    /// Defines interface for base entity type.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Primary key of the entity.
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}