using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class CityService : CRUDService<ADBD03>, IADBD03Service
    {
        private readonly IConfiguration _configuration;
        public CityService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD03", "D03F01")
        {
            _configuration = configuration;
        }
    }
}
