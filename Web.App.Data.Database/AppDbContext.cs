namespace Web.App.Data.Database
{
    using Domain.Entity;
    using System.Data.Entity;

    /// <summary>
    /// The SpringDbContext class.
    /// </summary>
    internal class AppDbContext : DbContext
    {
        #region -- Properties --
        
        /// <summary>
        /// Gets or Sets Posts
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        #endregion -- Properties --

        #region -- Constructors --
        /// <summary>
        /// Initializes a new instance of the DbUnitOfWork class.
        /// </summary>
        public AppDbContext()
            : base("appWebDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion -- Constructors

        #region -- Methods --
        #endregion -- Methods --
    }
}
