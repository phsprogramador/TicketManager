using System.Threading.Tasks;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;
using TicketManager.Infrastructure.Data;

namespace TicketManager.Infrastructure.Repositories
{
    public class TicketRepository(AppDbContext context) : BaseRepository<Ticket>(context), ITicketRepository
    {
        public override async Task DeleteAsync(int id)
        {
            Ticket entity = await _context.Tickets.FindAsync(id);

            if (entity != null)
            {
                entity.Active = false;
                _context.Tickets.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}