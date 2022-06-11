using AnnApp.DataProvider.Context;
using AnnApp.DataProvider.Interfaces;

namespace AnnApp.DataProvider.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnnContext db;
        private IAnnouncementRepository _announcementRepository;
        private bool _disposed;

        public UnitOfWork(AnnContext context)
        {
            db = context;
        }

        public IAnnouncementRepository AnnouncementRepository
        {
            get
            {
                if (_announcementRepository == null)
                {
                    _announcementRepository = new AnnouncementRepository(db);
                }
                return _announcementRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    db.Dispose();

                _disposed = true;
            }
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
