using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class BLContactCategory : BLGeneric<ADBD04>, IBLContactCategory
    {
        private readonly IConfiguration _configuration;
        public BLContactCategory(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD04", "D04F01")
        {
            _configuration = configuration;
        }
    }
}
