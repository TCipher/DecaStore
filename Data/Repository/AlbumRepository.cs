using DecaPlayStore.Data;
using DecaStore.Data.IRepository;
using DecaStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DecaStore.Data.Repository
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAllAsync(params Expression<Func<Album, object>>[] includeProperties)
        {
            IQueryable<Album> query = _context.Set<Album>().Include(a => a.Artist).Include(a => a.Genre);
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

    }
}
