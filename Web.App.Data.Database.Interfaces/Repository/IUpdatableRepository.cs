namespace Web.App.Data.Database.Interfaces
{
    using Domain.Entity.Interfaces;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines the contract for a Repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type this repository will serve.</typeparam>
    public interface IUpdatableRepository<TEntity, TKey> : IRepository<TEntity>
        where TKey : struct
        where TEntity : class, IIdentifiedEntity<TKey>
    {
        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(TEntity item);

        /// <summary>
        /// Updates an item.
        /// </summary>
        /// <param name="item">The item to update.</param>
        void Update(TEntity item);

        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        void Delete(TEntity item);

        /// <summary>
        /// Gets a single item by it id.
        /// </summary>
        /// <param name="id">The id of the item to get.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The item if found, null otherwise.</returns>
        TEntity Single(TKey id);

        /// <summary>
        /// Gets a single item by it id, optionally including linked entities.
        /// </summary>
        /// <param name="id">The id of the item to get.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The item if found.</returns>
        TEntity Single(TKey id, params Expression<Func<TEntity, object>>[] includes);
    }
}
