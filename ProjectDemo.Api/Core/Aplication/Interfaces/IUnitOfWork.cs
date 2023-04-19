using ProjectDemo.Api.Core.Domain.Entities;

namespace ProjectDemo.Api.Core.Aplication.Interfaces
{
   
    public interface IUnitOfWork : IDisposable
    {

        IClientRepository ClientRepository { get; }
     

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();
    }
}
