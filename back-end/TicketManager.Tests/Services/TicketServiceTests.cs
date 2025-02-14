using Moq;
using Application.Services;
using TicketManager.Domain.Interfaces;
using TicketManager.Application.Interfaces;
using TicketManager.Domain.Entities;
using TicketManager.Application.DTOs;

namespace TicketManager.Tests.Services
{
    public class TicketServiceTests
    {
        private readonly Mock<ITicketRepository> _mockRepo;
        private readonly ITicketService _ticketService;

        public TicketServiceTests()
        {
            _mockRepo = new Mock<ITicketRepository>();
            _ticketService = new TicketService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllTicketsAsync_ShouldReturnListOfTickets()
        {
            // Arrange
            List<Ticket> tickets =
            [
                new() { Id = 1, Title = "Ticket 1", Description = "Descrição 1" },
                new() { Id = 2, Title = "Ticket 2", Description = "Descrição 2" }
            ];

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tickets);

            // Act
            var result = await _ticketService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetTicketByIdAsync_ShouldReturnTicket()
        {
            // Arrange
            var ticket = new Ticket { Id = 1, Title = "Ticket 1", Description = "Descrição 1" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(ticket);

            // Act
            var result = await _ticketService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ticket 1", result.Title);
        }

        [Fact]
        public async Task AddTicketAsync_ShouldCallServiceAdd()
        {
            // Arrange
            var ticketDto = new TicketDto
            {
                Title = "Novo Ticket",
                Description = "Descrição do Novo Ticket",
                IdStatus = 1,
                IdUser = 1,
                IdResponsible = 2
            };

            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Ticket>())).Returns(Task.CompletedTask);

            // Act
            await _ticketService.AddAsync(ticketDto);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Ticket>()), Times.Once);
        }

        [Fact]
        public async Task UpdateTicketAsync_ShouldCallServiceUpdate()
        {
            // Arrange
            var ticketDto = new TicketDto
            {
                Title = "Ticket Atualizado",
                Description = "Descrição Atualizada",
                IdStatus = 1,
                IdUser = 1,
                IdResponsible = 2
            };

            var existingTicket = new Ticket { Id = 1, Title = "Ticket Antigo", Description = "Descrição Antiga" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingTicket);

            // Act
            await _ticketService.UpdateAsync(1, ticketDto);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Ticket>()), Times.Once);
        }

        [Fact]
        public async Task DeleteTicketAsync_ShouldCallServiceDelete()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            await _ticketService.DeleteAsync(1);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }        
    }
}