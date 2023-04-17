using MediatR;
using ProjectDemo.Api.BL.Models;

namespace ProjectDemo.Api.BL.Queries
{
    public class GetClientByCountryQuery: IRequest<Client>
    {
        public string Country { get; set; }
    }
}
