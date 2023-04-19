using ProjectDemo.Api.Core.Domain.Entities;

namespace ProjectDemo.Api.Core.Aplication.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<List<Client>> GetClientsByCountry(string country);
    }
}
