using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asponna.Persistence.Common.Interfaces
{
    public interface IOwnedNavigationConfiguration<TEntity, TOwnedEntity>
        where TEntity : class
        where TOwnedEntity : class
    {
        void Configure(OwnedNavigationBuilder<TEntity, TOwnedEntity> buyerConfiguration);
    }
}