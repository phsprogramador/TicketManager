using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Domain.Entities;

namespace TicketManager.Infrastructure.Data.Configurations
{
    public class TicketEntity : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .ToTable("TB_TICKET");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("ID_TICKET")
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(c => c.Status)
                .WithMany()
                .HasForeignKey(c =>c.IdStatus)
                .HasConstraintName("FK_TICKET_STATUS")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.IdStatus)
                .HasColumnName("ID_STATUS")
                .HasColumnType("INT")
                .IsRequired();

            builder.
                HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.IdUser)
                .HasConstraintName("FK_TICKET_USER")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.IdUser)
                .HasColumnName("ID_USER")
                .HasColumnType("INT")
                .IsRequired();

            builder
                .HasOne(t => t.Responsible)
                .WithMany()
                .HasForeignKey(t => t.IdResponsible)
                .HasConstraintName("FK_TICKET_RESPONSIBLE")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.IdResponsible)
                .HasColumnName("ID_RESPONSIBLE")
                .HasColumnType("INT")
                .IsRequired();

            builder
                .HasIndex(t => t.Title)
                .HasDatabaseName("IX_TICKET_TITLE");

            builder
                .Property(c => c.Title)
                .HasColumnName("TITLE")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder
                .Property(c => c.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR")
                .HasMaxLength(1000)
                .IsRequired(true);

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
