using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exact.Criccard.Domain.Entities
{
    [Table("team")]
    public class Team
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(450)]
        public string Name { get; set; }
        public bool IsBowlFirst { get; set; }
        public virtual Game Game { get; set; }
    }
}