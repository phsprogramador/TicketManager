using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Domain.Entities;

namespace TicketManager.Infrastructure.Data.Configurations
{
    public class StatusEntity : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
                .ToTable("TB_STATUS");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("ID_STATUS")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(t => t.Name)
                .HasDatabaseName("IX_STATUS_NAME");

            builder
                .Property(c => c.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);            

            builder
                .Property(c => c.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired(true);

            builder
                .HasIndex(t => t.DtInsert)
                .HasDatabaseName("IX_STATUS_INSERT_DATE");

            builder
                .Property(c => c.DtInsert)
                .HasColumnName("DT_INSERT")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
