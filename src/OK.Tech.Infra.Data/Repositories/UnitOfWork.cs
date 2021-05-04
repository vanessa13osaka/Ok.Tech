using System.Threading.Tasks;
using Ok.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;

namespace OK.Tech.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;
        
        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
