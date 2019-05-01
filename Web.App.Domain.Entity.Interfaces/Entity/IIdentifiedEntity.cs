namespace Web.App.Domain.Entity.Interfaces
{
    /// <summary>
    /// The identified entity contract.
    /// </summary>
    public interface IIdentifiedEntity<TKey> : IEntity
        where TKey : struct
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        TKey Id { get; set; }
    }
}
