using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectDemo.Api.Infrastructure.Persistence;
using ProjectDemo.Api.Infrastructure.Repositories;


namespace ProjectDemo.Test.Mocks
{
    public static class MockUnitOfWork
    {


        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: $"ApiContext-{dbContextId}")
                .Options;

            var apiDbContextFake = new ApiContext(options);
            apiDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(apiDbContextFake);


            return mockUnitOfWork;
        }

    }
}
