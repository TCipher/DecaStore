using DecaPlayStore.Data;
using DecaStore.Data.IRepository;
using DecaStore.Data.Repository;
using System;

namespace DecaStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        private IGenreRepository _genreRepository;
        private IAlbumRepository _albumRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
          
        }
        //performing a null check
        public IGenreRepository genreRepository =>
            _genreRepository ??= new GenreRepository(_context);

        public IAlbumRepository albumRepository =>
         _albumRepository ??= new AlbumRepository(_context);


        public void BeginTransaction()
        {
            _disposed = false;
        }
        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
