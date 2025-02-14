using Microsoft.AspNetCore.Mvc;
using Moq;
using TicketManager.API.Controllers;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.Tests.Controllers
{
    public class StatusControllerTests
    {
        private readonly Mock<IStatusService> _mockService;
        private readonly StatusController _controller;

        public StatusControllerTests()
        {
            _mockService = new Mock<IStatusService>();
            _controller = new StatusController(_mockService.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResultWithStatus()
        {
            // Arrange
            var status = new StatusDto { Name = "Status 1", Description = "Descrição 1" };
            _mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(status);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStatus = Assert.IsType<StatusDto>(okResult.Value);
            Assert.Equal("Status 1", returnedStatus.Name);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResultWithStatus()
        {
            // Arrange
            var statuses = new List<StatusDto>
            {
                new() { Name = "Status 1", Description = "Descrição 1" },
                new() { Name = "Status 2", Description = "Descrição 2" }
            };

            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(statuses);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStatus = Assert.IsType<List<StatusDto>>(okResult.Value);
            Assert.Equal(2, returnedStatus.Count);
        }
    }
}
