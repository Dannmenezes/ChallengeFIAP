using Microsoft.EntityFrameworkCore;
using MoneyChallenge.Models;
using System.Collections.Generic;

namespace MoneyChallenge.Data
{
    public class FBIContext : DbContext
    {
        public FBIContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<FBIPerson> FBI { get; set; }

        public DbSet<FBIResponse> FBIList { get; set; }

        public DbSet<InterpolPerson> Interpol { get; set; }
    }
}
