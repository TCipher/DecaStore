using DecaPlayStore.Data;
using DecaStore.Data.IRepository;
using DecaStore.Data.IServices;
using DecaStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DecaStore.Data.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<Album> _dbSet;
        private readonly IUnitOfWork _unitOfWork;
        public AlbumService(ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<Album>();
            _unitOfWork = unitOfWork;
        }

        public async Task<Album> GetByAlbumIDAsync(Guid id)
        {
            var album = await _unitOfWork.albumRepository.GetByIdAsync(id);
            return album;
        }

        public async Task<IEnumerable<Album>>StoreMangerAsync()
        {
            var SM = await _unitOfWork.albumRepository.GetAllAsync(a => a.Artist, a => a.Genre);
            return SM.ToList();
           
        }

       
    }
}
