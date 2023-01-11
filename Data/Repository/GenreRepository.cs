using DecaPlayStore.Data;
using DecaStore.Data.IRepository;
using DecaStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DecaStore.Data.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /*Getting a single object of type T from the databse, by applying a specific condition(predicate) to filter the result
      The method also includes an include statement to include the "Albums" navigation property when
      querying the database.*/
        public async Task<Genre> GetSingleAsync(Expression<Func<Genre, bool>> predicate)
        {
            try
            {
                var result = await _dbSet.Include("Albums").SingleAsync(predicate);
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

}
