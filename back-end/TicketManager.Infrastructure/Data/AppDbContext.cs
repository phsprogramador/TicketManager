
using Microsoft.EntityFrameworkCore;
using TicketManager.Domain.Entities;
using TicketManager.Infrastructure.Data.Configurations;

namespace TicketManager.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusEntity());
            modelBuilder.ApplyConfiguration(new TicketEntity());
            modelBuilder.ApplyConfiguration(new UserEntity());
        }
    }
}