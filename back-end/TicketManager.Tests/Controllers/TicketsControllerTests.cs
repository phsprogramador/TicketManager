using Microsoft.AspNetCore.Mvc;
using Moq;
using TicketManager.API.Controllers;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.Tests.Controllers
{
    public class TicketsControllerTests
    {
        private readonly Mock<ITicketService> _mockService;
        private readonly TicketsController _controller;

        public TicketsControllerTests()
        {
            _mockService = new Mock<ITicketService>();
            _controller = new TicketsController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResultWithTickets()
        {
            // Arrange
            var tickets = new List<TicketDto>
            {
                new() { Title = "Ticket 1", Description = "Descrição 1" },
                new() { Title = "Ticket 2", Description = "Descrição 2" }
            };

            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(tickets);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTickets = Assert.IsType<List<TicketDto>>(okResult.Value);
            Assert.Equal(2, returnedTickets.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResultWithTicket()
        {
            // Arrange
            var ticket = new TicketDto { Title = "Ticket 1", Description = "Descrição 1" };
            _mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(ticket);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTicket = Assert.IsType<TicketDto>(okResult.Value);
            Assert.Equal("Ticket 1", returnedTicket.Title);
        }

        [Fact]
        public async Task Create_ShouldReturnOkResult()
        {
            // Arrange
            var ticketDto = new TicketDto { Title = "Novo Ticket", Description = "Descrição do Novo Ticket", IdStatus = 1, IdUser = 1, IdResponsible = 2 };

            _mockService.Setup(service => service.AddAsync(ticketDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(ticketDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnOkResult()
        {
            // Arrange
            var ticketDto = new TicketDto { Title = "Ticket Atualizado", Description = "Descrição Atualizada", IdStatus = 1, IdUser = 1, IdResponsible = 1 };

            _mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(ticketDto);
            _mockService.Setup(service => service.UpdateAsync(1, ticketDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, ticketDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnOkResult()
        {
            // Arrange
            _mockService.Setup(service => service.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var okResultValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal("Ticket deletado com sucesso.", okResultValue);
        }
    }
}