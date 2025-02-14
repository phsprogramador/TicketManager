using Microsoft.AspNetCore.Mvc;
using Moq;
using TicketManager.API.Controllers;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;

namespace TicketManager.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockService = new Mock<IUserService>();
            _controller = new UserController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResultWithUser()
        {
            // Arrange
            var users = new List<UserDto>
            {
                new() { Name = "User 1", Login = "User01", Password = "User01Password" },
                new() { Name = "User 2", Login = "User02", Password = "User02Password" }
            };

            _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
            Assert.Equal(2, returnedUsers.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResultWithUser()
        {
            // Arrange
            var ticket = new UserDto { Name = "User 1", Login = "User01", Password = "User01Password" };
            _mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(ticket);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDto>(okResult.Value);
            Assert.Equal("User 1", returnedUser.Name);
        }

        [Fact]
        public async Task Create_ShouldReturnOkResult()
        {
            // Arrange
            var userDto = new UserDto { Name = "User 1", Login = "User01", Password = "User01Password" };

            _mockService.Setup(service => service.AddAsync(userDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(userDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnOkResult()
        {
            // Arrange
            var userDto = new UserDto { Name = "User 1", Login = "User01", Password = "User01Password" };

            _mockService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(userDto);
            _mockService.Setup(service => service.UpdateAsync(1, userDto)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(1, userDto);

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
            Assert.Equal("Usuario deletado com sucesso.", okResultValue);
        }

    }
}