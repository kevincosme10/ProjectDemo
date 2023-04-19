using MediatR;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry.DTOs;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Core.Domain.Entities;

namespace ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry
{
   
    public class GetClientsByCountryQuery : IRequest<Response<List<ClientDto>>>
    {
        public string Country { get; set; }
        public GetClientsByCountryQuery(string country)
        {
            Country = country;
        }

    }
}
