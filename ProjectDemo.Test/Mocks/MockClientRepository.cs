using AutoFixture;
using ProjectDemo.Api.Core.Domain.Entities;
using ProjectDemo.Api.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Test.Mocks
{
    public static class MockClientRepository
    {
        public static void AddDataClientRepository(ApiContext apiDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var clients = fixture.CreateMany<Client>().ToList();

            clients.Add(fixture.Build<Client>()
               .With(tr => tr.Name, "Gustavo")
               .With(tr => tr.LastName, "Rodriguez")
               .With(tr => tr.Age, 38)
               .With(tr => tr.Phone, "123456")
               .With(tr => tr.Direction, "Test address")
               .With(tr => tr.Country, "Nicaragua")
               .Create()
           );

            apiDbContextFake.Client!.AddRange(clients);
            apiDbContextFake.SaveChanges();

        }
    }
}
