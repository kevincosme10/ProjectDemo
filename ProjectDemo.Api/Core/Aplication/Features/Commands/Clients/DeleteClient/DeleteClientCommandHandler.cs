using MediatR;
using ProjectDemo.Api.Core.Aplication.Exceptions;
using ProjectDemo.Api.Core.Aplication.Interfaces;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Core.Domain.Entities;
using System.IO;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.DeleteClient
{
 
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;


        private readonly ILogger<DeleteClientCommandHandler> _logger;

        public DeleteClientCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteClientCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var clientToDelete = await _unitOfWork.ClientRepository.GetByIdAsync(request.Id);
            if (clientToDelete is null)
            {
                _logger.LogError($"{request.Id} cliente no existe en el sistema");
                throw new KeyNotFoundException($"Registro no encontrado con le id{request.Id}");
            
            }
            _unitOfWork.ClientRepository.Remove(clientToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} cliente fue eliminado con exito");

            return new Response<int>(clientToDelete.Id);
        }
    }
}
