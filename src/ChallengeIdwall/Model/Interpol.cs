using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeIdwall.Model
{
    [Table("InterpolTable")]
    public class Interpol
    {
        [Key]
        [Required]
        [Column("EntityId")]
        public int EntityId { get; set; }
        [Column("Forename")]
        public string? Forename { get; set; }
        [Column("Name")]
        public string? Name { get; set; }

        [Column("Nationalities")]
        public string? Nationalities { get; set; }

        public ICollection<Fbi> fbis { get; set; } = new List<Fbi>();


        public Interpol()
        {
        }

        public Interpol(int entityId, string? forename, string? name, string? nacionalities)
        {
            EntityId = entityId;
            Forename = forename;
            Name = name;
            Nationalities = nacionalities;
        }
    }
}
