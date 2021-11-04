using APIWebApplication.Data.EntityConfig;
using APIWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWebApplication.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NotaTag> NotaTag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new NotaTagMap());
        }
    }
}
