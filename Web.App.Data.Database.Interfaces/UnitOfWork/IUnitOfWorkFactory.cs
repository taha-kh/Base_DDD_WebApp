namespace Web.App.Data.Database.Interfaces
{

    /// <summary>
    /// Defines the contract for a unit of work factory.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates a new unit of work.
        /// </summary>
        /// <param name="isReadOnly">True to get a read-only unit of work.</param>
        /// <returns>The newly created unit of work.</returns>
        IUnitOfWork Create(bool isReadOnly = false);
    }
}
