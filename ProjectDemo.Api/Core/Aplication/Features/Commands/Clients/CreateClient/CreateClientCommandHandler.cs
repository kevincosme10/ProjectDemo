using MediatR;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Core.Domain.Entities;
using System.IO;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient
{
 
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
    {
  
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ILogger<CreateClientCommandHandler> _logger;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateClientCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
           
            _logger = logger;
        }

        public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client();
     
            client.Name = request.Name; 
            client.LastName= request.LastName;
            client.Age = request.Age;
            client.Phone = request.Phone;   
            client.Direction = request.Direction;  
            client.Country = request.Country;
            
            _unitOfWork.ClientRepository.Add(client);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el cliente");
            }

            _logger.LogInformation($"Client {client.Id} fue creado existosamente");

            return new Response<int>(client.Id);

            
        }

        

    }
}
