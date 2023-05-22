using BookAPI.Domain;
using Microsoft.Extensions.Configuration;

namespace BookAPI.DAL.Services
{
    /// <summary>
    /// It contains data access logic for author crud operation 
    /// </summary>
    public class DALAuthor : DALGeneric<BOSD01>, IDALAuthor
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public DALAuthor(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "BOSD01", "D01F01", "D01F03")
        {
            _configuration = configuration;
        }
        #endregion
    }
}
