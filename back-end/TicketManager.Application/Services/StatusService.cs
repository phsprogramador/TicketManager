using Application.Services;
using TicketManager.Application.DTOs;
using TicketManager.Application.Interfaces;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;

namespace TicketManager.Application.Services
{   
    public class StatusService(IStatusRepository repository) : BaseService<Status, StatusDto>(repository), IStatusService
    {
        protected override Status MapToEntity(StatusDto dto)
        {
            return new Status
            {
                Name = dto.Name,
                Description = dto.Description,
                DtInsert = DateTime.UtcNow
            };
        }

        protected override void MapToEntity(StatusDto dto, Status entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
        }

        protected override StatusDto MapToDto(Status entity)
        {
            return new StatusDto
            {
                Name = entity.Name,
                Description = entity.Description
            };
        }

        protected override IEnumerable<StatusDto> MapToDtoList(IEnumerable<Status> entities)
        {
            List<StatusDto> dtos = [];

            foreach (var entity in entities)
            {
                dtos.Add(MapToDto(entity));
            }
            return dtos;
        }
    }
}