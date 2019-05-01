namespace Web.App.Controllers
{
    using Application.Services.Interfaces;
    using Application.Services.Interfaces.Post;
    using Crossculting.Ioc.Unity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        #region Members
        private IPostService postService;
        #endregion Members

        #region Constructor 
        public HomeController()
        {
            this.postService = IocUnityContainer.Instance.Resolve<IPostService>();
        }
        #endregion Constructor

        #region Actions

        /// <summary>
        /// Get a list of Posts in the Index View
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var posts = postService.GetAllPost();
            return View(posts);
        }
        #endregion Actions
    }
}