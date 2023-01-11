using System;

namespace DecaStore.Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenreRepository genreRepository { get; }
        IAlbumRepository albumRepository { get; }

        void SaveChanges();

        void BeginTransaction();


        void Rollback();
    }
}
