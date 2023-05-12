using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLUser : BLGeneric<ADBD06>, IBLUser
    {
        private readonly IConfiguration _configuration;
        public BLUser(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD06", "D06F01")
        {
            _configuration = configuration;
        }
    }
}
