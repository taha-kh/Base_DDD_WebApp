namespace Web.App.Data.Database
{
    using Domain.Entity.Interfaces;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The DbUnitOfWork class.
    /// </summary>
    internal class DbUnitOfWork : IUnitOfWork
    {
        #region -- Members --
        /// <summary>
        /// Is this unit of work disposed or not.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// The repositories dictionary.
        /// </summary>
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// The data context.
        /// </summary>
        private AppDbContext dataContext;
        #endregion -- Members --

        #region -- Properties --
        /// <summary>
        /// Gets or sets a value indicating whether this unit of work is read-only or not.
        /// </summary>
        protected bool IsReadOnly { get; set; }
        #endregion -- Properties --

        #region -- Constructors --
        /// <summary>
        /// Initializes a new instance of the DbUnitOfWork class.
        /// </summary>
        /// <remarks>By default, this creates an updatable unit of work. Use the other specialized constructor to obtain a read-only unit of work.</remarks>
        public DbUnitOfWork()
            : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DbUnitOfWork class.
        /// </summary>
        /// <param name="isReadOnly">A value indicating whether this unit of work is read-only or not.</param>
        public DbUnitOfWork(bool isReadOnly)
        {
            this.dataContext = new AppDbContext();
            this.IsReadOnly = isReadOnly;
            this.repositories = new Dictionary<Type, object>();
        }
        #endregion -- Constructors

        #region -- Methods --

        /// <summary>
        /// Gets a repository.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns></returns>
        public IDbRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TKey : struct, IEquatable<TKey>
            where TEntity : class, IDbEntity<TKey>
        {
            if (this.repositories.ContainsKey(typeof(TEntity)))
            {
                return this.repositories[typeof(TEntity)] as IDbRepository<TEntity, TKey>;
            }

            IDbRepository<TEntity, TKey> repository = new DbRepository<TEntity, TKey>(this.dataContext);
            this.repositories[typeof(TEntity)] = repository;
            return repository;
        }

        /// <summary>
        /// Save changes (for a non-readonly unit of work).
        /// </summary>
        public void SaveChanges()
        {
            if(this.IsReadOnly)
            {
                throw new InvalidOperationException("Trying to save changes to a read-only unit of work!");
            }

            this.dataContext.SaveChanges();
        }

        /// <summary>
        /// Disposes this unit of work.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes this unit of work.
        /// </summary>
        /// <param name="disposing">True if this unit of work is disposing, false otherwise.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataContext.Dispose();
                }
            }

            this.disposed = true;
        }
        #endregion -- Methods --
    }
}
