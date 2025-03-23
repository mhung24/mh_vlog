
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Mhung.Core.Domain.Content
{
    [Table("Series")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Series
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public required string Slug { get; set; }

        public string? IsActive { get; set; }
        public string? SortOrder { get; set; }
        public string? SeoKeywords { get; set; }

        [MaxLength(250)]
        public string? SeoDescription { get; set; }

        [MaxLength(250)]
        public string? Thumbnail { get; set; }

        public string? Content { get; set; }

        public Guid AuthorUserId { get; set; }  

        public DateTime DataCreated { get; set; }

    }
}
