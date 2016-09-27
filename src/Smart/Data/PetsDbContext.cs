using Microsoft.EntityFrameworkCore;
using SmartBowl;

namespace Smart.Data
{
    public class PetsDbContext : DbContext
    {
        public PetsDbContext(DbContextOptions<PetsDbContext> options) 
            : base(options)
        {

        }


        public DbSet<Bowl> Bowl { get; set; }
        public DbSet<Pet> Pet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<BowlPet>()
                .HasKey(t => new { t.PetId, t.BowlId });

            builder.Entity<BowlPet>()
                .HasOne(pet => pet.Bowl)
                .WithMany(p => p.BowlPet)
                .HasForeignKey(pet => pet.BowlId);

            builder.Entity<BowlPet>()
                .HasOne(bowl => bowl.Pet)
                .WithMany(b => b.BowlPet)
                .HasForeignKey(bowl => bowl.PetId);

        }

        
    }
}
