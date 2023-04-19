using MediatR;
using ProjectDemo.Api.Core.Aplication.Wrappers;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient
{
  
    public class CreateClientCommand : IRequest<Response<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Phone { get; set; } = string.Empty;
        public string Direction { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
       
    }
}
