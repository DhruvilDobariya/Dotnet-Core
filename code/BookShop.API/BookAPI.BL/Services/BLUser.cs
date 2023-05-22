using BookAPI.DAL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic for user crud operation 
    /// </summary>
    public class BLUser : IBLUser
    {
        #region Private Properties
        private readonly IDALUser _userDAL;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public BLUser(IDALUser userDAL, IConfiguration configuration)
        {
            _userDAL = userDAL;
            _configuration = configuration;
        }
        #endregion

        #region Public Methods

        #region Authenticate
        ///// <summary>
        ///// Get Jwt token
        ///// </summary>
        ///// <param name = "login" > login object of Login class which contains email and password of user</param>
        ///// <returns>It gives JWT token</returns>
        public async Task<Tokens> Authenticate(Login login)
        {
            try
            {
                var user = await _userDAL.Authenticate(login);
                if (user.D04F01 != 0)
                {
                    var tockenHandler = new JwtSecurityTokenHandler();
                    var tockenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

                    var tockenDescriptior = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                                    new Claim("UserId", user.D04F01.ToString())
                            }
                        ),
                        //Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tockenKey), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tocken = tockenHandler.CreateToken(tockenDescriptior);
                    return new Tokens { Token = tockenHandler.WriteToken(tocken), D04F01 = user.D04F01, D04F02 = user.D04F02, D04F03 = user.D04F03 };
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GetByIdAsync
        /// <summary>
        /// Get user by primary key
        /// </summary>
        /// <param name="id"> id represent a primary key of user</param>
        /// <returns>user</returns>
        public async Task<BOSD04> GetByIdAsync(int id)
        {
            try
            {
                return await _userDAL.GetByIdAsync(id);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region AddAsync
        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user">user contains value which we want to add</param>
        /// <returns>if user added successfully then it return true else it return false</returns>
        public async Task<bool> AddAsync(BOSD04 user)
        {
            try
            {
                if (await _userDAL.AddAsync(user) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region UpdateAsync
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">user contains value which we want to update</param>
        /// <returns>if user updated successfully then it return true else it return false</returns>
        public async Task<bool> UpdateAsync(BOSD04 user)
        {
            try
            {
                if (await _userDAL.UpdateAsync(user) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region DeleteAsync
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">id represent a primary key of user which we want to delete</param>
        /// <returns>if user delete successfully then it return true else it return false</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (await _userDAL.DeleteAsync(id) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #endregion 
    }
}
