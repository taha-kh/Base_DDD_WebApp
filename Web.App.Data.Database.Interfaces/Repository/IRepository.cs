namespace Web.App.Data.Database.Interfaces
{
    using Domain.Entity.Interfaces;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines the contract for a Read-Only Repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity type this repository will serve.</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets a collection of items matching the filter, optionally including linked entities.
        /// </summary>
        /// <param name="filter">The filter to use.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>A collection of items matching the filter.</returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Gets a paginated collection of items matching the filter, optionally including linked entities.
        /// </summary>
        /// <typeparam name="TKey">Type of the column used to sort.</typeparam>
        /// <param name="filter">The filter to use.</param>
        /// <param name="orderBy">The sort expression to use.</param>
        /// <param name="pageIndex">The page index to get.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>A collection of items matching the filter.</returns>
        IQueryable<TEntity> Where<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> orderBy, int pageIndex, int pageSize, params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Gets the whole collection of items.
        /// </summary>
        /// <returns>The whole collection of items.</returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Gets the whole collection of items, optionally including linked entities.
        /// </summary>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole collection of items.</returns>
        IQueryable<TEntity> All(params String[] includes);

        /// <summary>
        /// Gets the whole collection of items, optionally including linked entities.
        /// </summary>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole collection of items.</returns>
        IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Gets the whole paginated collection of items, optionally including linked entities.
        /// </summary>
        /// <typeparam name="TOrderColumn">Type of the column used to sort.</typeparam>
        /// <param name="orderBy">The sort expression to use.</param>
        /// <param name="pageIndex">The page index to get.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole paginated collection of items.</returns>
        IQueryable<TEntity> All<TOrderColumn>(Expression<Func<TEntity, TOrderColumn>> orderBy, int pageIndex, int pageSize, params Expression<Func<TEntity, object>>[] includes);
    }
}
