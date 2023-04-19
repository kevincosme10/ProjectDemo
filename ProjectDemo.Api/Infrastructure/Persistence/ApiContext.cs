using Microsoft.EntityFrameworkCore;
using ProjectDemo.Api.Core.Domain.Entities;
using System.ComponentModel;
using System.Reflection;

namespace ProjectDemo.Api.Infrastructure.Persistence
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; } = null!;
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
