using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class ContactService : CRUDService<ADBD05>, IADBD05Service
    {
        private readonly IConfiguration _configuration;
        public ContactService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD05", "D05F01")
        {
            _configuration = configuration;
        }
    }
}
