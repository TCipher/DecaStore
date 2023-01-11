using DecaStore.Models;

namespace DecaStore.Data.IServices
{
    public interface IGenreService
    {
        Task<List<Genre>> GetAllGenreAsnyc();
        Task<Genre> GetByNameAsync(string name);
        //Task<IEnumerable<Genre>> GetByNameAsync(params Expression<Func<Genre, object>>[] includeProperties);
    }
}
