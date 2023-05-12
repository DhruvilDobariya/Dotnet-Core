using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class CountryService : CRUDService<ADBD01>, IADBD01Service
    {
        private readonly IConfiguration _configuration;
        public CountryService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD01", "D01F01")
        {
            _configuration = configuration;
        }
    }
}
