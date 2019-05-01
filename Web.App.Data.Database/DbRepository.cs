namespace Web.App.Data.Database
{
    using Domain.Entity.Interfaces;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The DbRepository class.
    /// </summary>
    internal class DbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey>
        where TKey : struct, IEquatable<TKey>
        where TEntity : class, IDbEntity<TKey>
    {
        #region -- Members --
        /// <summary>
        /// The current database context.
        /// </summary>
        private AppDbContext context;

        /// <summary>
        /// The current db set (used to speed up accesses).
        /// </summary>
        private DbSet<TEntity> dbSet;
        #endregion -- Members --

        #region -- Properties --
        #endregion -- Properties --

        #region -- Constructors --
        /// <summary>
        /// Initializes a new instance of the DbRepository class.
        /// </summary>
        /*public DbRepository()
        {
            throw new InvalidOperationException("A database repository MUST be created ONLY within a Unit Of Work.");
        }*/

        /// <summary>
        /// Initializes a new instance of the DbRepository class.
        /// </summary>
        /// <param name="context">The context to use with this repository.</param>
        internal DbRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }
        #endregion -- Constructors

        #region -- Methods --
        #region ---- IRepository Implementation ----

        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(TEntity item)
        {
            this.dbSet.Add(item);
        }

        /// <summary>
        /// Updates an item.
        /// </summary>
        /// <param name="item">The item to update.</param>
        public void Update(TEntity item)
        {
            this.dbSet.Attach(item);
            this.context.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="item">The item to delete.</param>
        public void Delete(TEntity item)
        {
            if(context.Entry(item).State == EntityState.Detached)
            {
                this.dbSet.Attach(item);
            }

            this.dbSet.Remove(item);
        }

        /// <summary>
        /// Gets a single item by it id.
        /// </summary>
        /// <param name="id">The id of the item to get.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The item if found, null otherwise.</returns>
        public TEntity Single(TKey id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>
        /// Gets a single item by it id, optionally including linked entities.
        /// </summary>
        /// <param name="id">The id of the item to get.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The item if found, null otherwise.</returns>
        public TEntity Single(TKey id, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).FirstOrDefault(item => item.Id.Equals(id));   
        }

        /// <summary>
        /// Gets a collection of items matching the filter.
        /// </summary>
        /// <param name="filter">The filter to use.</param>
        /// <returns>A collection of items matching the filter.</returns>
        public IEnumerable<TEntity> Where(Func<TEntity, bool> filter)
        {
            return this.Where(filter);
        }

        /// <summary>
        /// Gets a collection of items matching the filter, optionally including linked entities.
        /// </summary>
        /// <param name="filter">The filter to use.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>A collection of items matching the filter.</returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).Where(filter);
        }

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
        public IQueryable<TEntity> Where<TOrderColumn>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TOrderColumn>> orderBy, int pageIndex, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).Where(filter).OrderBy(orderBy).Skip(pageIndex * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Gets the whole collection of items.
        /// </summary>
        /// <returns>The whole collection of items.</returns>
        public IQueryable<TEntity> All()
        {
            IQueryable<TEntity> query = this.dbSet;

            return query;
        }

        /// <summary>
        /// Gets the whole collection of items, optionally including linked entities.
        /// </summary>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole collection of items.</returns>
        public IQueryable<TEntity> All(params String[] includes)
        {
            IQueryable<TEntity> query = this.dbSet;
            foreach(string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        /// <summary>
        /// Gets the whole collection of items, optionally including linked entities.
        /// </summary>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole collection of items.</returns>
        public IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this.dbSet;
            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        /// <summary>
        /// Gets the whole paginated collection of items, optionally including linked entities.
        /// </summary>
        /// <typeparam name="TOrderColumn">Type of the column used to sort.</typeparam>
        /// <param name="orderBy">The sort expression to use.</param>
        /// <param name="pageIndex">The page index to get.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="includes">Optionally included linked entities.</param>
        /// <returns>The whole paginated collection of items.</returns>
        public IQueryable<TEntity> All<TOrderColumn>(Expression<Func<TEntity, TOrderColumn>> orderBy, int pageIndex, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).OrderBy(orderBy).Skip(pageIndex * pageSize).Take(pageSize);
        }
        #endregion ---- IRepository Implementation ----
        #endregion -- Methods --
    }
}
