using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Domain.Entities;
using ProjectDemo.Api.Infrastructure.Persistence;
using System.Collections;

namespace ProjectDemo.Api.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly ApiContext _context;

        private IClientRepository _clientRepository;



        public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);

      

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }

        public ApiContext ApiContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }


    }
}
