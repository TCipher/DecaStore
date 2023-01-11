using System.Linq.Expressions;

namespace DecaStore.Data.IRepository
{
    public interface IGenericRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);

        Task DeleteAsync(Guid id);
      


    }
}
