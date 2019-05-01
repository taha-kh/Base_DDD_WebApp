namespace Web.App.Application.Services.Interfaces.Post
{
    using System.Collections.Generic;
    using Web.App.Application.Dtos.Post;

    /// <summary>
    /// The post services contract.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Add a Post.
        /// </summary>
        void AddPost(PostDto post);

        /// <summary>
        /// Get a list of All Posts
        /// </summary>
        /// <returns></returns>
        List<PostDto> GetAllPost();
    }
}
