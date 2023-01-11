
using DecaStore.Models;
using System.Linq.Expressions;

namespace DecaStore.Data.IRepository
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<IEnumerable<Album>> GetAllAsync(params Expression<Func<Album, object>>[] includeProperties);
    }
}
