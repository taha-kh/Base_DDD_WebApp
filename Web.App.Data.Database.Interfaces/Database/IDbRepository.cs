namespace Web.App.Data.Database.Interfaces
{
    using Web.App.Domain.Entity.Interfaces;

    /// <summary>
    /// Defines the contract for a database Repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type this repository will serve.</typeparam>
    public interface IDbRepository<TEntity, TKey> : IUpdatableRepository<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IDbEntity<TKey>
    {
    }
}
