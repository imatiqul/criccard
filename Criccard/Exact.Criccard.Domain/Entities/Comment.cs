using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exact.Criccard.Domain.Entities
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public virtual Bowl Bowl { get; set; }
        public string Text { get; set; }
    }
}
