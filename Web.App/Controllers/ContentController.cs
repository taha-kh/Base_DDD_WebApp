namespace Web.App.Controllers
{
    using System;
    using System.Web.Mvc;
    using Web.App.Application.Dtos.Post;
    using Web.App.Application.Services.Interfaces.Post;
    using Crossculting.Ioc.Unity;

    /// <summary>
    /// Controller de Création d'un Post
    /// </summary>
    public class ContentController : Controller
    {
        #region Members
        private IPostService postService;
        #endregion Members

        #region Constructor 
        public ContentController()
        {
                this.postService = IocUnityContainer.Instance.Resolve<IPostService>();
        }
        #endregion Constructor

        #region Actions

        /// <summary>
        /// Get Create View Action 
        /// </summary>
        /// <returns>Partial View Create</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Create Action 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publicationDate"></param>
        /// <returns>Home/Index View</returns>
        [HttpPost]
        public ActionResult Create(string content, DateTime publicationDate)
        {
            var dto = new PostDto() {
                CreationDate = DateTime.Now,
                Content = content,
                UpdateDate = DateTime.Now,
                PublicationDate= publicationDate
            };

            postService.AddPost(dto);

            return View();
        }
        #endregion Actions

    }
}