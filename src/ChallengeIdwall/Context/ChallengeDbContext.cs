using ChallengeIdwall.Model;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIdwall.Context
{
    public class ChallengeDbContext
    {
        public class DataBaseContext : DbContext
        {
            public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
            {
            }

            protected DataBaseContext()
            {
            }

            public DbSet<Fbi> FBITable { get; set; }
            public DbSet<FBIWantedResponse> FBIWantedResponse { get; set; }
            public DbSet<Interpol> InterpolTable { get; set; }
            public DbSet<InterpolWantedResponse> Interpol { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<FBIWantedResponse>()
                    .HasNoKey();
                modelBuilder.Entity<InterpolWantedResponse>()
                    .HasNoKey();
            }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    modelBuilder.Entity<DataNascimentoSuspeitoModel>()
            //        .HasKey(d => new { d.uid, d.dates_of_birth_used });

            //    base.OnModelCreating(modelBuilder);
            //}
        }
    }
}
