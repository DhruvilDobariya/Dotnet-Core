using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic and data access logic for user crud operation 
    /// </summary>
    public class BLUser : IBLUser
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public BLUser(IConfiguration configuration)
        {
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
                var query = "Select D04F01, D04F02, D04F03, D04F04 from BOSD04 where D04F03 = @D04F03 and D04F04 = @D04F04";
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@D04F03", login.Email);
                    command.Parameters.AddWithValue($"@D04F04", login.Password);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    var user = new BOSD04();
                    while (reader.Read())
                    {
                        foreach (var property in typeof(BOSD04).GetProperties())
                        {
                            if (reader[property.Name] != null)
                            {
                                property.SetValue(user, reader[property.Name]);
                            }
                        }
                        break;
                    }

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
                        return new Tokens { Token = tockenHandler.WriteToken(tocken) };
                    }
                    return null;
                }
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
                var query = "Select D04F01, D04F02, D04F03, D04F04 from BOSD04 where D04F01 = @D04F01";
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@D04F01", id);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var entity = new BOSD04();
                        foreach (var property in typeof(BOSD04).GetProperties())
                        {
                            if (reader[property.Name] != null)
                            {
                                property.SetValue(entity, reader[property.Name]);
                            }
                        }
                        return entity;
                    }
                    return null;
                }
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
                var query = $"Insert into BOSD04 (D04F02, D04F03, D04F04) values (@D04F02, @D04F03, @D04F04)";
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@D04F02", user.D04F02);
                    command.Parameters.AddWithValue("@D04F03", user.D04F03);
                    command.Parameters.AddWithValue("@D04F04", user.D04F04);
                    await connection.OpenAsync();
                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
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
                var query = $"Update BOSD04 set D04F02 = @D04F02, D04F03 = @D04F03, D04F04 = @D04F04 where D04F01 = @D04F01";
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@D04F01", user.D04F01);
                    command.Parameters.AddWithValue("@D04F02", user.D04F02);
                    command.Parameters.AddWithValue("@D04F03", user.D04F03);
                    command.Parameters.AddWithValue("@D04F04", user.D04F04);
                    await connection.OpenAsync();
                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
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
                var query = $"Delete from BOSD04 where D04F01 = @D04F01";
                using (var connections = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connections);
                    command.Parameters.AddWithValue($"@D04F01", id);
                    await connections.OpenAsync();
                    int result = await command.ExecuteNonQueryAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
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
