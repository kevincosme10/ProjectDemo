using MediatR;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients.DTOs;
using ProjectDemo.Api.Core.Aplication.Wrappers;

namespace ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients
{
    
    public class GetAllClientsQuery : IRequest<Response<List<ClientDto>>>
    {
  
        public GetAllClientsQuery()
        {
           
        }

    }
}
