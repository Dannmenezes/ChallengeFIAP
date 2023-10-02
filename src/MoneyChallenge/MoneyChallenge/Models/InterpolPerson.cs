using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyChallenge.Models
{
    [Keyless]
    public class InterpolPerson
    {
        public int EntityId { get; set; }
        public string? Forename { get; set; }
        public string? Name { get; set; }
        public string? Nationalities { get; set; }
        [NotMapped]
        public ICollection<FBIResponse> FBIs { get; set; } = new List<FBIResponse>();

        public InterpolPerson() { }

        public InterpolPerson(int entityId, string forename, string name, string nacionalities)
        {
            EntityId = entityId;
            Forename = forename;
            Name = name;
            Nationalities = nacionalities;
        }
    }
}
