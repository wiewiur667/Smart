using Microsoft.EntityFrameworkCore;
using SmartBowl;

namespace Smart.Data
{
    public class PetsDbContext : DbContext
    {

        public DbSet<Bowl> Bowl { get; set; }
        public DbSet<Pet> Pet { get; set; }

        public PetsDbContext(DbContextOptions<PetsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<BowlPet>()
                .HasKey(x => new { x.BowlId, x.PetId });

            builder.Entity<BowlPet>()
                .HasOne(x => x.Pet)
                .WithMany(x => x.BowlPet)
                .HasForeignKey(x => x.PetId);

            builder.Entity<BowlPet>()
                .HasOne(x => x.Bowl)
                .WithMany(x => x.BowlPet)
                .HasForeignKey(x => x.BowlId);

        }
    }
}
