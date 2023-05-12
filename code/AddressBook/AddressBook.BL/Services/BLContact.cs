using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLContact : BLGeneric<ADBD05>, IBLContact
    {
        private readonly IConfiguration _configuration;
        public BLContact(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD05", "D05F01")
        {
            _configuration = configuration;
        }
    }
}
