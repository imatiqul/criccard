using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exact.Criccard.Domain.Entities
{
    [Table("over")]
    public class Over
    {
        [Key]
        public int ID { get; set; }
        public int OverNumber { get; set; }
        public virtual Team Team { get; set; }
    }
}
