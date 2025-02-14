using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketManager.Infrastructure.Data.Extensions
{
    internal abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        internal abstract void Configure(EntityTypeBuilder<TEntity> entity);
    }
}