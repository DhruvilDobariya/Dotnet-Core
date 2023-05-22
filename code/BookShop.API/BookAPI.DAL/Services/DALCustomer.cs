using BookAPI.Domain;
using Microsoft.Extensions.Configuration;

namespace BookAPI.DAL.Services
{
    /// <summary>
    /// It contains data access logic for customer crud operation 
    /// </summary>
    public class DALCustomer : DALGeneric<BOSD02>, IDALCustomer
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public DALCustomer(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "BOSD02", "D02F01", "D02F06")
        {
            _configuration = configuration;
        }
        #endregion
    }
}
