using MediatR;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients.DTOs;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Aplication.Wrappers;

namespace ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients
{
  
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Response<List<ClientDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetAllClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Response<List<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            List<ClientDto> clientsDto = new List<ClientDto>();
            var clients = await _unitOfWork.ClientRepository.GetAllAsync();

            foreach (var item in clients)
            {
                ClientDto clientDto = new ClientDto();
                clientDto.Name = item.Name;
                clientDto.LastName = item.LastName;
                clientDto.Age = item.Age;
                clientDto.Phone = item.Phone;

                clientsDto.Add(clientDto);

            }
            return new Response<List<ClientDto>>(clientsDto);
        }
    }
}
