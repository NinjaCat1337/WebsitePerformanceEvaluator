using DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public sealed class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Site> Sites { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new TestResultConfiguration());
            modelBuilder.ApplyConfiguration(new SiteMapUrlConfiguration());
        }
    }
}