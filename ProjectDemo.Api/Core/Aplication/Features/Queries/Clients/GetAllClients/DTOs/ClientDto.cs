namespace ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients.DTOs
{
    
        public class ClientDto
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; } = 0;
            public string Phone { get; set; }
      
        }
    
}
