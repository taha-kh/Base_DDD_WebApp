namespace Web.App.Data.Database.Interfaces
{
    using Domain.Entity.Interfaces;
    using System;

    /// <summary>
    /// Defines the contract for a read-only unit-of-work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets a repository.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns></returns>
        IDbRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TKey : struct, IEquatable<TKey>
            where TEntity : class, IDbEntity<TKey>;

        /// <summary>
        /// Save changes.
        /// </summary>
        void SaveChanges();
    }
}
