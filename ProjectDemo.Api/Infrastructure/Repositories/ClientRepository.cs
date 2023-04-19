using Microsoft.EntityFrameworkCore;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Domain.Entities;
using ProjectDemo.Api.Infrastructure.Persistence;

namespace ProjectDemo.Api.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApiContext context) : base(context)
        {
        }

        public async Task<List<Client>> GetClientsByCountry(string country)
        {
            var clients = await _context.Client.FromSqlInterpolated($"exec GetClientsByCountry @CountryName ={country}").ToListAsync();
            return clients;
        }
    }
}
