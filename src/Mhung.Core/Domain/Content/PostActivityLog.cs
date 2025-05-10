
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Unit1_Core.Domain.Content;

namespace Mhung.Core.Domain.Content
{
    [Table("PostActivityLogs")]
    public class PostActivityLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public PostStatus FromStatus { get; set; }
        public PostStatus ToStatus { get; set; }

        public DateTime DataCreated { get; set; }

        [MaxLength(250)]
        public string? Note { get; set; }
        public Guid UserId { get; set; }
    }
}
