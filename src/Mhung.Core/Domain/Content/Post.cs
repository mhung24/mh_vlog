using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Unit1_Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public required string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public required string Slug { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public Post(string? description)
        {
            Description = description;
        }

        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(500)]
        public string? Thumbnail { get; set; }

        [MaxLength(500)]
        public string? Content { get; set; }

        [MaxLength(500)]
        public Guid AuthorUserId { get; set; }

        [MaxLength(128)]
        public  string? Source { get; set; }

        [MaxLength(250)]
        public  string? Tag { get; set; }

        [MaxLength(160)]
        public  string SeoDescription { get; set; }
        public int ViewCount { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataModifined { get; set; }
        public bool IsPaid { get; set; }
        public double RoyaltyMount { get; set; }
        public PostStatus Status { get; set; }
    }

    public enum PostStatus
    {
        Draft = 1,
        Cancelled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublish = 5,
        Published = 6,
    }
}
