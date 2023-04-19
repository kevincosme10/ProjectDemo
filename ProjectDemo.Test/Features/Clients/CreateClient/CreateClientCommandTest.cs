using Microsoft.Extensions.Logging;
using Moq;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient;
using ProjectDemo.Api.Core.Aplication.Wrappers;
using ProjectDemo.Api.Infrastructure.Repositories;
using ProjectDemo.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Test.Features.Clients.CreateClient
{
  
    public class CreateClientCommandTest
    {
       
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateClientCommandHandler>> _logger;

        public CreateClientCommandTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
          
      
            _logger = new Mock<ILogger<CreateClientCommandHandler>>();


            MockClientRepository.AddDataClientRepository(_unitOfWork.Object.ApiContext);
        }

        [Fact]
        public async Task CreateClientCommand_ReturnsNumber()
        {
            var clientInput = new CreateClientCommand()
            {
                Name = "Gustavo",
                LastName = "Rodriguez",
                Age = 30,
                Phone  = "123456789",
                Direction ="test addres",
                Country = "managua"
            };

            var handler = new CreateClientCommandHandler(_unitOfWork.Object,  _logger.Object);

            var result = await handler.Handle(clientInput, CancellationToken.None);

            result.ShouldBeOfType<Response<int>>();
        }


    }
}
