using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;

namespace Application.Services
{
    public class TicketService(ITicketRepository repository) : BaseService<Ticket, TicketDto>(repository), ITicketService
    {
        protected override Ticket MapToEntity(TicketDto dto)
        {
            return new Ticket
            {
                Title = dto.Title,
                Description = dto.Description,
                IdStatus = dto.IdStatus,
                IdUser = dto.IdUser,
                IdResponsible = dto.IdResponsible,
                DtInsert = DateTime.UtcNow
            };
        }

        protected override void MapToEntity(TicketDto dto, Ticket entity)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.IdStatus = dto.IdStatus;
            entity.IdUser = dto.IdUser;
            entity.IdResponsible = dto.IdResponsible;
        }

        protected override TicketDto MapToDto(Ticket entity)
        {
            return new TicketDto
            {
                Title = entity.Title,
                Description = entity.Description,
                IdStatus = entity.IdStatus,
                IdUser = entity.IdUser,
                IdResponsible = entity.IdResponsible
            };
        }

        protected override IEnumerable<TicketDto> MapToDtoList(IEnumerable<Ticket> entities)
        {
            List<TicketDto> dtos = [];

            foreach (var entity in entities)
            {
                dtos.Add(MapToDto(entity));
            }
            return dtos;
        }
    }
}