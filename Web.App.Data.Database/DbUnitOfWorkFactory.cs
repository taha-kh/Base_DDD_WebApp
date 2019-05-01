namespace Web.App.Data.Database
{
    using Web.App.Data.Database.Interfaces;

    /// <summary>
    /// The DbUnitOfWork factory class.
    /// </summary>
    public class DbUnitOfWorkFactory : IUnitOfWorkFactory
    {
        #region -- Methods --
        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        /// <param name="isReadOnly">True to get a read-only unit of work.</param>
        /// <returns>The newly created unit of work.</returns>
        public IUnitOfWork Create(bool isReadOnly = false)
        {
            return new DbUnitOfWork(isReadOnly);
        }
        #endregion -- Methods --
    }
}
