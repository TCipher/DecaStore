using DecaPlayStore.Data;
using DecaStore.Data.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DecaStore.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //Adding tothe database
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);


        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        //Fetching all from the database
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        /* database query which loads an Album whose
        ID matches the parameter value. */
        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);


      

        public async Task UpdateAsync(Guid id, T entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
