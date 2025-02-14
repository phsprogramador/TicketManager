using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;
using TicketManager.Infrastructure.Data;

namespace TicketManager.Infrastructure.Repositories
{
    public class StatusRepository(AppDbContext context) : BaseRepository<Status>(context), IStatusRepository
    {
    }
}