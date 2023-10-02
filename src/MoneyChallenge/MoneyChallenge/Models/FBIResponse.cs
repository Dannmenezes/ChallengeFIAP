using Microsoft.EntityFrameworkCore;

namespace MoneyChallenge.Models
{
    [Keyless]
    public class FBIResponse
    {
        public List<FBIPerson> Items { get; set; }
    }
}
