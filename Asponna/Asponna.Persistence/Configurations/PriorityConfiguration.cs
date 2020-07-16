using Asponna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asponna.Persistence.Configurations
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> priorityConfiguration)
        {
            priorityConfiguration.ToTable(nameof(Priority));
            
            priorityConfiguration.HasKey(c => c.Id);

            priorityConfiguration.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            priorityConfiguration.Property(c => c.Color)
                .HasMaxLength(7)
                .IsRequired();
        }
    }
}