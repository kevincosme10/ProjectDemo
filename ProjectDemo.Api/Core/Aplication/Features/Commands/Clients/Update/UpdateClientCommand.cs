using MediatR;
using ProjectDemo.Api.Core.Aplication.Wrappers;

namespace ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.Update
{
    
    public class UpdateClientCommand : IRequest<Response<int>>
    {
        private int Id { get; set; }

        public string Name { get; set; } 
        public string LastName { get; set; } 
        public int Age { get; set; } = 0;
        public string Phone { get; set; }
        public string Direction { get; set; } 
        public string Country { get; set; }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
