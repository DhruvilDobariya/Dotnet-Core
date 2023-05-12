using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLState : BLGeneric<ADBD02>, IBLState
    {
        private readonly IConfiguration _configuration;
        public BLState(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD02", "D02F01")
        {
            _configuration = configuration;
        }
    }
}
