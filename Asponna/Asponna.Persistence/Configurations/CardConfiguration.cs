using Asponna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asponna.Persistence.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> cardConfiguration)
        {
            cardConfiguration.ToTable(nameof(Card));
            
            cardConfiguration.HasKey(c => c.Id);

            cardConfiguration.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();

            cardConfiguration.Property(c => c.Description);

            cardConfiguration.Property(c => c.Completed)
                .IsRequired();

            cardConfiguration.Property(c => c.Position)
                .IsRequired();

            cardConfiguration.HasOne(c => c.TaskBoard)
                .WithMany(t => t.Cards)
                .HasForeignKey(c => c.TaskBoardId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            cardConfiguration.HasOne(c => c.Priority)
                .WithMany(p => p.Cards)
                .HasForeignKey(c => c.PriorityId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}