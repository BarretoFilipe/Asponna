using Asponna.Persistence.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Asponna.Persistence.Common.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> ApplyOwnsOneConfiguration<TEntity, TOwnedEntity>(
            this EntityTypeBuilder<TEntity> entityTypeBuilder,
            Expression<Func<TEntity, TOwnedEntity>> navigationExpression,
            IOwnedNavigationConfiguration<TEntity, TOwnedEntity> configuration)
                where TEntity : class
                where TOwnedEntity : class
        {
            entityTypeBuilder.OwnsOne(navigationExpression, configuration.Configure);
            return entityTypeBuilder;
        }

        public static OwnedNavigationBuilder<TEntity, TNewDependentEntity> ApplyOwnsOneConfiguration<TEntity, TNewDependentEntity, TOwnedEntity>(
            this OwnedNavigationBuilder<TEntity, TNewDependentEntity> entityTypeBuilder,
            Expression<Func<TNewDependentEntity, TOwnedEntity>> navigationExpression,
            IOwnedNavigationConfiguration<TNewDependentEntity, TOwnedEntity> configuration)
                where TEntity : class
                where TNewDependentEntity : class
                where TOwnedEntity : class
        {
            entityTypeBuilder.OwnsOne(navigationExpression, configuration.Configure);
            return entityTypeBuilder;
        }

        public static EntityTypeBuilder<TEntity> ApplyOwnsManyConfiguration<TEntity, TOwnedEntity>(
            this EntityTypeBuilder<TEntity> entityTypeBuilder,
            Expression<Func<TEntity, IEnumerable<TOwnedEntity>>> navigationExpression,
            IOwnedNavigationConfiguration<TEntity, TOwnedEntity> configuration)
                where TEntity : class
                where TOwnedEntity : class
        {
            entityTypeBuilder.OwnsMany(navigationExpression, configuration.Configure);
            return entityTypeBuilder;
        }

        public static OwnedNavigationBuilder<TEntity, TNewDependentEntity> ApplyOwnsManyConfiguration<TEntity, TNewDependentEntity, TOwnedEntity>(
            this OwnedNavigationBuilder<TEntity, TNewDependentEntity> entityTypeBuilder,
            Expression<Func<TNewDependentEntity, IEnumerable<TOwnedEntity>>> navigationExpression,
            IOwnedNavigationConfiguration<TNewDependentEntity, TOwnedEntity> configuration)
                where TEntity : class
                where TNewDependentEntity : class
                where TOwnedEntity : class
        {
            entityTypeBuilder.OwnsMany(navigationExpression, configuration.Configure);
            return entityTypeBuilder;
        }
        }
    }
