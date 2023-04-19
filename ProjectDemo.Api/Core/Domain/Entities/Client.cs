namespace ProjectDemo.Api.Core.Domain.Entities
{
      public class Client : BaseEntity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public string Country { get; set; }
    }
}
