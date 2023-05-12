using AddressBook.Domain;
using Microsoft.Extensions.Configuration;

namespace AddressBook.BL.Services
{
    public class UserService : CRUDService<ADBD06>, IADBD06Service
    {
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "ADBD06", "D06F01")
        {
            _configuration = configuration;
        }
    }
}
