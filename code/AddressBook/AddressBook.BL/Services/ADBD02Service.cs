using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class StateService : CRUDService<ADBD02>, IADBD02Service
    {
        private readonly IConfiguration _configuration;
        public StateService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD02", "D02F01")
        {
            _configuration = configuration;
        }
    }
}
