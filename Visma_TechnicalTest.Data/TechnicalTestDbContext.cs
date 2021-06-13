using Microsoft.EntityFrameworkCore;
using Visma_TechnicalTest.Core.Models;
using Visma_TechnicalTest.Data.Configurations;

namespace Visma_TechnicalTest.Data
{
    public class TechnicalTestDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
