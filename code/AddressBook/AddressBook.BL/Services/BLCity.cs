using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLCity : BLGeneric<ADBD03>, IBLCity
    {
        private readonly IConfiguration _configuration;
        public BLCity(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD03", "D03F01")
        {
            _configuration = configuration;
        }
    }
}
