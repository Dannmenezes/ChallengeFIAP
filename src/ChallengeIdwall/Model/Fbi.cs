using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeIdwall.Model
{
    [Table("FBITable")]
    public class Fbi
    {
        [Key]
        [Required]
        [Column("SuspectId")]
        public int Id { get; set; }
        [Required]
        [Column("SuspectTitle")]
        public string? Title { get; set; }

        public Fbi()
        {
        }

        public Fbi(int id, string? title)
        {
            Id = id;
            Title = title;
        }
    }
}
