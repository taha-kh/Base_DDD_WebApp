namespace Web.App.Application.Dtos.Post
{
    using System;

    /// <summary>
    /// The Post DTO.
    /// </summary>
    public class PostDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Content of the Post.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Publication Date.
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the Creation Date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the Update Date.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
