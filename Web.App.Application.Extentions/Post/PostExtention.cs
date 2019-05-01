namespace Web.App.Application.Extentions.Post
{
    using Dtos.Post;
    using System;
    using Domain.Entity;
    using System.Collections.Generic;
    /// <summary>
    /// Post extentions class.
    /// </summary>
    public static class PostExtention
    {
        /// <summary>
        /// Converts a post DTO to a post entity
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Post ToEntity(this PostDto dto)
        {
            return new Post
            {
                Content = dto.Content,
                PublicationDate = dto.PublicationDate,
                CreationDate =dto.CreationDate,
                UpdateDate = dto.UpdateDate
            };
        }

        /// <summary>
        /// Converts a Post to a DTO
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static PostDto ToDto(this Post post)
        {
            var dto = new PostDto()
            {
                Id = post.Id,
                Content = post.Content,
                CreationDate = post.CreationDate,
                PublicationDate = post.PublicationDate,
                UpdateDate = post.UpdateDate
            };

            return dto;
        }

        /// <summary>
        /// Converts a collection of posts to a colection of their dtos.
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        public static IEnumerable<PostDto> ToDtos(this IEnumerable<Post> posts)
        {
            foreach (Post post in posts)
            {
                yield return post.ToDto();
            }
        }
    }
}
