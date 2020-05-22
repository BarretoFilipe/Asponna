using Asponna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asponna.Persistence.Configurations
{
    public class TaskBoardConfiguration : IEntityTypeConfiguration<TaskBoard>
    {
        public void Configure(EntityTypeBuilder<TaskBoard> taskBoardConfiguration)
        {
            taskBoardConfiguration.ToTable(nameof(TaskBoard));

            taskBoardConfiguration.HasKey(t => t.Id);

            taskBoardConfiguration.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            taskBoardConfiguration.Property(t => t.Position)
                .IsRequired();
        }
    }
}