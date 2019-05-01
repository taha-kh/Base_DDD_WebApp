namespace Web.App.Application.Services
{
    using System;
    using Data.Database.Interfaces;
    using Domain.Entity;
    using Extentions.Post;
    using Interfaces.Post;
    using Web.App.Application.Dtos.Post;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The PostServices implementation class
    /// </summary>
    public  class PostServices : IPostService
    {
        #region Members

        /// <summary>
        /// The unit of work factory to use.
        /// </summary>
        public IUnitOfWorkFactory unitOfWorkFactory ;

        #endregion Members

        #region Constructors
        /// <summary>
        ///  Initializes a new instance of the PostServices class.
        /// </summary>
        /// <param name="unitOfWorkFactory"></param>
        public PostServices(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Add a Post
        /// </summary>
        public void AddPost(PostDto post)
        {
            try
            {
                using (IUnitOfWork unitofwork = this.unitOfWorkFactory.Create())
                {
                    unitofwork.GetRepository<Post, long>()
                        .Add(post.ToEntity());
                    unitofwork.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }           
        }

        public List<PostDto> GetAllPost()
        {
            try
            {
                using (IUnitOfWork unitOfWork = this.unitOfWorkFactory.Create())
                {

                   var posts = unitOfWork.GetRepository<Post, long>()
                        .All()
                        .OrderByDescending(p => p.PublicationDate)
                        .ToDtos().ToList();

                    return posts;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        #endregion Methods
    }
}
