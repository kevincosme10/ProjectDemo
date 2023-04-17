using MediatR;

namespace ProjectDemo.Api.BL.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientService _clientService;
        private readonly IMediator _mediator;

        public ClientService(IClientService clientService, IMediator mediator)
        {
            _clientService = clientService;
            _mediator = mediator;
        }
    }
}
