using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLCountry : BLGeneric<ADBD01>, IBLCountry
    {
        private readonly IConfiguration _configuration;
        public BLCountry(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD01", "D01F01")
        {
            _configuration = configuration;
        }
    }
}
