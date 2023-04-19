using MediatR;
using ProjectDemo.Api.Core.Aplication.Exceptions;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Core.Domain.Entities;
using System.Diagnostics.Contracts;
using System.IO;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.Update
{
 
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateClientCommandHandler> _logger;

        public UpdateClientCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateClientCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {

            var clientToUpdate = await _unitOfWork.ClientRepository.GetByIdAsync(request.GetId());

            if (clientToUpdate is null)
            {
                _logger.LogError($"No se encontro el cliente id {request.GetId()}");
                throw new NotFoundException(nameof(Client), request.GetId());
            }
            else
            {
                clientToUpdate.Name = request.Name;
                clientToUpdate.LastName = request.LastName;
                clientToUpdate.Age = request.Age;
                clientToUpdate.Phone = request.Phone;
                clientToUpdate.Direction = request.Direction;
                clientToUpdate.Country = request.Country;
                _unitOfWork.ClientRepository.Update(clientToUpdate);

                await _unitOfWork.Complete();

                _logger.LogInformation($"La operacion fue exitosa actualizando el cliente {request.GetId()}");

                return new Response<int>(clientToUpdate.Id);
            }

         

            
        }
    }
}
