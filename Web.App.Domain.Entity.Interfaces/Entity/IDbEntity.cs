namespace Web.App.Domain.Entity.Interfaces
{
    /// <summary>
    /// The database entity contract.
    /// </summary>
    public interface IDbEntity<TKey> : IIdentifiedEntity<TKey>
        where TKey : struct
    {
    }
}
