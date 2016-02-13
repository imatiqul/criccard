using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exact.Criccard.Domain.Entities
{
    [Table("bowl")]
    public class Bowl
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public int Run { get; set; }
        public bool IsWide { get; set; }
        public virtual Over Over { get; set; }
    }
}
