using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using TicketManager.Application.DTOs;
using TicketManager.Domain.Entities;
using TicketManager.Infrastructure.Data;
using TicketManager.Infrastructure.Repositories;

namespace TicketManager.Tests.Repositories
{
    public class TicketRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public TicketRepositoryTests()
        {
            // Configura o banco de dados em memória
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TicketManagerTestDB")
                .Options;
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTicket()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                await context.Database.EnsureDeletedAsync();

                var ticket = new Ticket { Id = 2, Title = "Ticket 1", Description = "Descrição 1", IdResponsible = 1 };
                context.Tickets.Add(ticket);
                await context.SaveChangesAsync();
            }

            // Act
            using (var context = new AppDbContext(_options))
            {
                var repository = new TicketRepository(context);
                var result = await repository.GetByIdAsync(2);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Ticket 1", result.Title);
            }
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResultWithTickets()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                await context.Database.EnsureDeletedAsync();

                var tickets = new List<Ticket>
                {
                    new() { Title = "Ticket 1", Description = "Descrição 1", IdStatus = 1, IdUser = 1,  IdResponsible = 1 },
                    new() { Title = "Ticket 1", Description = "Descrição 1", IdStatus = 1, IdUser = 1,  IdResponsible = 1 }
                };

                foreach (Ticket ticket in tickets)
                {
                    context.Tickets.Add(ticket);
                    await context.SaveChangesAsync();
                }
            }

            // Act
            using (var context = new AppDbContext(_options))
            {
                var repository = new TicketRepository(context);
                var results = await repository.GetAllAsync();

                // Assert
                Assert.Equal(2, results.Count());
            }
        }

        [Fact]
        public async Task AddAsync_ShouldAddTicket()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                await context.Database.EnsureDeletedAsync();

                var repository = new TicketRepository(context);
                var ticket = new Ticket { Id = 1, Title = "Novo Ticket", Description = "Descrição do Novo Ticket", IdResponsible = 1 };

                // Act
                await repository.AddAsync(ticket);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new AppDbContext(_options))
            {
                var ticketInDb = await context.Tickets.FirstOrDefaultAsync();
                Assert.NotNull(ticketInDb);
                Assert.Equal("Novo Ticket", ticketInDb.Title);
            }
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateTicket()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                await context.Database.EnsureDeletedAsync();

                var repository = new TicketRepository(context);
                var ticketAdd = new Ticket { Id = 1, Title = "Novo Ticket", Description = "Descrição do Novo Ticket", IdResponsible = 1 };                

                // Act
                await repository.AddAsync(ticketAdd);
                await context.SaveChangesAsync();
            }

            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new TicketRepository(context);                
                var ticketUpdate = new Ticket { Id = 1, Title = "Ticket Atualizado", Description = "Descrição do Ticket Atualizado", IdResponsible = 1 };

                // Act
                await repository.UpdateAsync(ticketUpdate);
                await context.SaveChangesAsync();
            }


            // Assert
            using (var context = new AppDbContext(_options))
            {
                var ticketInDb = await context.Tickets.FirstOrDefaultAsync();
                Assert.NotNull(ticketInDb);
                Assert.Equal("Ticket Atualizado", ticketInDb.Title);
            }
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteTicket()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                await context.Database.EnsureDeletedAsync();

                var repository = new TicketRepository(context);

                // Act
                await repository.DeleteAsync(2);
                await context.SaveChangesAsync();
            }

            // Assert
            using (var context = new AppDbContext(_options))
            {
                var repository = new TicketRepository(context);

                var ticketInDb = await repository.GetByIdAsync(2);
                Assert.Null(ticketInDb);
            }
        }
    }
}