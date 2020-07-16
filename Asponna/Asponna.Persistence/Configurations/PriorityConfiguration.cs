using Asponna.Domain.Entities;
using Asponna.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asponna.Persistence.Configurations
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> priorityConfiguration)
        {
            priorityConfiguration.ToTable(nameof(Priority));

            priorityConfiguration.HasKey(p => p.Id);

            priorityConfiguration.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            priorityConfiguration.Property(p => p.Color)
                .HasMaxLength(7)
                .IsRequired();

            /*priorityConfiguration.OwnsOne(p => p.Color)
                .Property(c => c)
                .HasColumnName(nameof(Color))
                .HasMaxLength(7)
                .IsRequired();*/
        }
    }
}