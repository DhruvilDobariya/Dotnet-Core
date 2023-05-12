using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class ContactCategoryService : CRUDService<ADBD04>, IADBD04Service
    {
        private readonly IConfiguration _configuration;
        public ContactCategoryService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD04", "D04F01")
        {
            _configuration = configuration;
        }
    }
}
