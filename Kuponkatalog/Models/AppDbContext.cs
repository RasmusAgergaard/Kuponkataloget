using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kuponkatalog.Models
{
    //The "trafic agent" that moves code between the code and the db
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Types that should be created in the database
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<CatalogPages> CatalogPages { get; set; }
        public DbSet<TagPages> TagPages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogPages>()
                .HasKey(t => new { t.CatalogId, t.PageId });

            modelBuilder.Entity<TagPages>()
                .HasKey(t => new { t.TagId, t.PageId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
