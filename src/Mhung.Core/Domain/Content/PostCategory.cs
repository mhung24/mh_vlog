using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mhung.Core.Domain.Content
{
    [Table("PostCategories")]
    [Index(nameof(Slug), IsUnique = true)]
    public class PostCategory
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        public required string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public required string Slug { get; set; }

        public Guid ParentId { get; set; }

        public bool IsActive { get; set; }

        public DateTime DataCreated { get; set; }

        public DateTime DataModifined { get; set; }

        [MaxLength(160)]
        public string? SeoDescription { get; set; }

        public int SortOrder { get; set; }
    }
}
