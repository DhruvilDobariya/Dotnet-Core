using BookAPI.Domain;
using Microsoft.Extensions.Configuration;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic and data access logic for author crud operation 
    /// </summary>
    public class BLAuthor : BLGeneric<BOSD01>, IBLAuthor
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public BLAuthor(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "BOSD01", "D01F01", "D01F03")
        {
            _configuration = configuration;
        }
        #endregion
    }
}
