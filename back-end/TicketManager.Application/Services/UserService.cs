using Application.Services;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;

namespace TicketManager.Application.Services
{
    public class UserService(IUserRepository repository) : BaseService<User, UserDto>(repository), IUserService
    {
        protected override User MapToEntity(UserDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Login = dto.Login,
                Password = dto.Password,
                DtInsert = DateTime.UtcNow
            };
        }

        protected override void MapToEntity(UserDto dto, User entity)
        {
            entity.Name = dto.Name;
            entity.Login = dto.Login;
            entity.Password = dto.Password;
        }

        protected override UserDto MapToDto(User entity)
        {
            return new UserDto
            {
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password
            };
        }

        protected override IEnumerable<UserDto> MapToDtoList(IEnumerable<User> entities)
        {
            List<UserDto> dtos = [];

            foreach (var entity in entities)
            {
                dtos.Add(MapToDto(entity));
            }
            return dtos;
        }
    }
}