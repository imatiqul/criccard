using Exact.Criccard.Domain.EnumCollections;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exact.Criccard.Domain.Entities
{
    [Table("game")]
    public class Game
    {
        [Key]
        public Guid ID { get; set; }
        public Team FistTeam { get; set; }
        public Team SecondTeam { get; set; }
        public GameStatus Status { get; set; }
        public Language Language { get; set; }
    }
}
