using GeekShow.Product.Api.Entities.ProdutoContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekShow.Product.Api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<Produto> Produtos { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            //builder.Entity<User>()
            //     .HasIndex(e => e.Email)
            //     .IsUnique();

            //builder.Entity<User>()
            //       .ToTable("AspNetUsers")
            //       .HasKey(e => e.Id);

        }

    }
}
