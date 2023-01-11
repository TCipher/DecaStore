using DecaStore.Models;
using System.Linq.Expressions;

namespace DecaStore.Data.IRepository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetSingleAsync(Expression<Func<Genre, bool>> predicate);
    }
}
