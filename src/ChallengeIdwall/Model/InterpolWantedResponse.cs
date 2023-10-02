using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeIdwall.Model
{
    [Table("Interpol")]
    public class InterpolWantedResponse
    {
        [Key]
        public List<Interpol> items { get; set; }
    }
}
