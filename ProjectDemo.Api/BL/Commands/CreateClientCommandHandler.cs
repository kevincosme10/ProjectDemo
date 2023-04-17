using MediatR;
using ProjectDemo.Api.BL.Models;

namespace ProjectDemo.Api.BL.Commands
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
    {
        public Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
