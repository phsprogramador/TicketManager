using System.Threading.Tasks;
using TicketManager.Domain.Entities;
using TicketManager.Domain.Interfaces;
using TicketManager.Infrastructure.Data;

namespace TicketManager.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public override async Task DeleteAsync(int id)
        {
            User entity = await _context.Users.FindAsync(id);

            if (entity != null)
            {
                entity.Active = false;
                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}