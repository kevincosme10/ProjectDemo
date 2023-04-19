using MediatR;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry.DTOs;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Core.Domain.Entities;
using System.IO;

namespace ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry
{

    public class GetClientsByCountryQueryHandler : IRequestHandler<GetClientsByCountryQuery, Response<List<ClientDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;


        public GetClientsByCountryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Response<List<ClientDto>>> Handle(GetClientsByCountryQuery request, CancellationToken cancellationToken)
        {
            List<ClientDto> clientsDto = new List<ClientDto>();
            var clients = await _unitOfWork.ClientRepository.GetClientsByCountry(request.Country);

            foreach (var item in clients)
            {
                ClientDto clientDto = new ClientDto();
                clientDto.Name = item.Name; 
                clientDto.Country = item.Country;
                clientDto.LastName = item.LastName;
                clientDto.Age = item.Age;
                clientDto.Direction = item.Direction;
                clientDto.Phone = item.Phone;

                clientsDto.Add(clientDto);  

            }
           return new Response<List<ClientDto>>(clientsDto);
        }
    }
}
