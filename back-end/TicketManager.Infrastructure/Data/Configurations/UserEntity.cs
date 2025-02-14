using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Domain.Entities;

namespace TicketManager.Infrastructure.Data.Configurations
{
    public class UserEntity : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("TB_USER");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("ID_USER")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder
                .Property(c => c.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(c => c.Login)
                .HasColumnName("LOGIN")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired(true);

            builder
                .Property(c => c.Password)
                .HasColumnName("PASSWORD")
                .HasColumnType("VARCHAR");

            builder
                .HasIndex(t => t.DtInsert)
                .HasDatabaseName("IX_TICKET_INSERT_DATE");

            builder
                .Property(c => c.DtInsert)
                .HasColumnName("DT_INSERT")
                .HasColumnType("DATETIME");

            builder
                .Property(c => c.DtUpdate)
                .HasColumnName("DT_UPDATE")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(c => c.Active)
                .HasColumnName("ACTIVE")
                .HasColumnType("BIT")
                .HasDefaultValueSql("1")
                .IsRequired(true);
        }
    }
}
