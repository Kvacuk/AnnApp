namespace AnnApp.DataProvider.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAnnouncementRepository AnnouncementRepository { get; }

        Task SaveAsync();
    }
}
