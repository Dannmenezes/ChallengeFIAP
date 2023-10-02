using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeIdwall.Model
{
    [Table("FBI")]
    public class FBIWantedResponse
    {
        [Key]
        public List<Fbi> items { get; set; }
    }
}
