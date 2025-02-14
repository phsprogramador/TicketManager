using Application.Services;
using Moq;
using System.Reflection;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;
using TicketManager.Application.Services;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;
using Xunit.Sdk;

namespace TicketManager.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService _userService;
        private Type _type = null;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepo.Object);
            _type = typeof(UserService);
        }

        [Fact]
        public async Task MapToEntity_ShouldReturnEntityOfMap()
        {
            // Arrange
            var userDto = new UserDto { Name = "Map Usuario", Login = "Map Login", Password = "Map Password" };
            MethodInfo methodInfo = typeof(UserService).GetMethod("MapToEntity", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(UserDto) }, null);

            // Act
            User result = (User)methodInfo.Invoke(new UserService(_mockRepo.Object), [userDto]);

            // Assert            
            Assert.Equal(userDto.Name, result.Name);
        }


        [Fact]
        public async Task MapToEntity_ShouldReturnListEntityOfMapTwoParameters()
        {
            // Arrange
            UserDto userDto = new() { Name = "Map Usuario 1", Login = "Map Login 1", Password = "Map Password1" };
            User user = new();

            MethodInfo methodInfo = typeof(UserService).GetMethod("MapToEntity", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(UserDto), typeof(User) }, null);

            // Act
            methodInfo.Invoke(new UserService(_mockRepo.Object), [userDto,user]);

            // Assert
            Assert.Equal(userDto.Name, user.Name);
        }

        [Fact]
        public async Task MapToDto_ShouldReturnEntityOfMap()
        {
            // Arrange
            var user = new User { Name = "Map Usuario", Login = "Map Login", Password = "Map Password" };
            MethodInfo methodInfo = typeof(UserService).GetMethod("MapToDto", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(User) }, null);

            // Act
            UserDto result = (UserDto)methodInfo.Invoke(new UserService(_mockRepo.Object), [user]);

            // Assert            
            Assert.Equal(user.Name, result.Name);
        }

        [Fact]
        public async Task MapToDtoList_ShouldReturnListEntityOfMap()
        {
            // Arrange
            List<User> users =
            [
                new() { Name = "Map Usuario 1", Login = "Map Login 1", Password = "Map Password1" },
                new() { Name = "Map Usuario 2", Login = "Map Login 2", Password = "Map Password2" }
            ];

            MethodInfo methodInfo = typeof(UserService).GetMethod("MapToDtoList", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new[] { typeof(IEnumerable<User>) }, null);

            // Act
            IEnumerable<UserDto> result = (IEnumerable<UserDto>)methodInfo.Invoke(new UserService(_mockRepo.Object), [users]);

            // Assert
            Assert.Equal(users.Count, result.Count());
        }
    }
}