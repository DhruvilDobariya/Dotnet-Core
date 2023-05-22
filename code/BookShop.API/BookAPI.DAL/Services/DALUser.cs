using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace BookAPI.DAL.Services
{
    /// <summary>
    /// It contains data access logic for user crud operation 
    /// </summary>
    public class DALUser : IDALUser
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public DALUser(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        #region Public Methods

        #region Authenticate
        ///// <summary>
        ///// Validate user
        ///// </summary>
        ///// <param name = "login" > login object of Login class which contains email and password of user</param>
        ///// <returns>if user is valid then it return object of user else it return null</returns>
        public async Task<BOSD04> Authenticate(Login login)
        {
            try
            {
                var user = new BOSD04();
                var query = "Select D04F01, D04F02, D04F03, D04F04 from BOSD04 where D04F03 = @D04F03 and D04F04 = @D04F04";
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@D04F03", login.Email);
                    command.Parameters.AddWithValue($"@D04F04", login.Password);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();

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
                }
                return user;
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
        /// <returns>return affected rows in user table</returns>
        public async Task<int> AddAsync(BOSD04 user)
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
                    return await command.ExecuteNonQueryAsync();
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
        /// <returns>return affected rows in user table</returns>
        public async Task<int> UpdateAsync(BOSD04 user)
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
                    return await command.ExecuteNonQueryAsync();
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
        /// <returns>return affected rows in user table</returns>
        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var query = $"Delete from BOSD04 where D04F01 = @D04F01";
                using (var connections = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand(query, connections);
                    command.Parameters.AddWithValue($"@D04F01", id);
                    await connections.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
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
