using MediatR;
using ProjectDemo.Api.Core.Aplication.Wrappers;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.DeleteClient
{
    public class DeleteClientCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
