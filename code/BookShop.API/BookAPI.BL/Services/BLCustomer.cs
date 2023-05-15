using BookAPI.Domain;
using Microsoft.Extensions.Configuration;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic and data access logic for customer crud operation 
    /// </summary>
    public class BLCustomer : BLGeneric<BOSD02>, IBLCustomer
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public BLCustomer(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "BOSD02", "D02F01", "D02F06")
        {
            _configuration = configuration;
        }
        #endregion
    }
}
