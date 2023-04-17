using MediatR;
using ProjectDemo.Api.BL.Models;

namespace ProjectDemo.Api.BL.Queries
{
    public class GetClientByCountryQueryHandler : IRequestHandler<GetClientByCountryQuery, Client>
    {
        public Task<Client> Handle(GetClientByCountryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
