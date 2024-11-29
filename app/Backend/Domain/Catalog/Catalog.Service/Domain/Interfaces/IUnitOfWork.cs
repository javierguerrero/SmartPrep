namespace Catalog.Service.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        Task<bool> SaveAsync();
    }
}