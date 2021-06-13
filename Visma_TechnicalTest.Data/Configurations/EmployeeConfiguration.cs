using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Visma_TechnicalTest.Core.Models;

namespace Visma_TechnicalTest.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .UseIdentityColumn();
            builder
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150);
            builder
                .Property(e => e.SocialSecurityNumber)
                .IsRequired()
                .HasMaxLength(12);
            builder
                .Property(e => e.Phone)
                .HasMaxLength(9);
        }
    }
}
