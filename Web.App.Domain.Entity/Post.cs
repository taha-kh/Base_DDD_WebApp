namespace Web.App.Domain.Entity
{
    using Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Post Class
    /// </summary>
    [Table("Post")]
    public class Post : IDbEntity<long>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the Content of the Post.
        /// </summary>
        [Column("Content")]
        [StringLength(4000)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the Publication Date.
        /// </summary>
        [Column("PublicationDate")]
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Gets or sets the Creation Date.
        /// </summary>
        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the Update Date.
        /// </summary>
        [Column("UpdateDate")]
        public DateTime UpdateDate { get; set; }
    }
}
