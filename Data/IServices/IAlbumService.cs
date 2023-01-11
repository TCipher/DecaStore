using DecaStore.Models;

namespace DecaStore.Data.IServices
{
    public interface IAlbumService
    {
        Task<Album> GetByAlbumIDAsync(Guid id);
        Task<IEnumerable<Album>>StoreMangerAsync();
    }
}
