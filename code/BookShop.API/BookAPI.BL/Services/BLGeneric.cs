using MySqlConnector;

namespace BookAPI.BL.Services
{
    /// <summary>
    /// It contains business logic and data access logic for generic crud operation
    /// </summary>
    /// <typeparam name="T">T is a class which we want to generate business logic and data access logic for CRUD operation</typeparam>
    public class BLGeneric<T> : IBLGeneric<T> where T : class
    {
        #region Private Properties
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _id;
        private readonly string _userId;
        #endregion

        #region Constructor
        public BLGeneric(string connectionString, string tableName, string id, string userId)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _id = id;
            _userId = userId;
        }
        #endregion

        #region Public Methods

        #region GetAllAsync
        /// <summary>
        /// Get list of recored of T type object
        /// </summary>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns> List of T type object</returns>
        public virtual async Task<List<T>> GetAllAsync(int userId)
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var query = $"Select {properties} from {_tableName} where {_userId} = @{_userId}";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@{_userId}", userId);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    var entities = new List<T>();
                    while (reader.Read())
                    {
                        var entity = Activator.CreateInstance<T>();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (reader[property.Name] != DBNull.Value)
                            {
                                property.SetValue(entity, reader[property.Name]);
                            }
                        }
                        entities.Add(entity);
                    }
                    return entities;
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
        /// Get T type object by primary key
        /// </summary>
        /// <param name="id"> id represent a primary key of T type object</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>T type object</returns>
        public virtual async Task<T> GetByIdAsync(int id, int userId)
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var query = $"Select {properties} from {_tableName} where {_id} = @{_id} and {_userId} = @{_userId}";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@{_id}", id);
                    command.Parameters.AddWithValue($"@{_userId}", userId);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        var entity = Activator.CreateInstance<T>();
                        foreach (var property in typeof(T).GetProperties())
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
        /// Add T type object in table which contains T type object recored
        /// </summary>
        /// <param name="entity">entity represent a T type object which we want to add</param>
        /// <returns>if recored added successfully then it return true else it return false</returns>
        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var value = string.Join(",", typeof(T).GetProperties().Select(p => $"@{p.Name}"));
                var query = $"Insert into {_tableName} ({properties}) values ({value})";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
                    foreach (var property in typeof(T).GetProperties())
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                    }
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
        /// Update T type object in table which contains T type object recored
        /// </summary>
        /// <param name="entity">entity represent a T type object which we want to update</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored updated successfully then it return true else it return false</returns>
        public virtual async Task<bool> UpdateAsync(T entity, int userId)
        {
            var propertiesWithValue = string.Join(",", typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}"));
            var query = $"Update {_tableName} Set {propertiesWithValue} where {_id} = @{_id} and {_userId} = @{_userId}";
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
                    foreach (var property in typeof(T).GetProperties())
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(entity) ?? DBNull.Value);
                    }
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
        /// delete recored from table which contains T type recored
        /// </summary>
        /// <param name="id">id represent a primary key of recored which we want to delete</param>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>if recored delete successfully then it return true else it return false</returns>
        public virtual async Task<bool> DeleteAsync(int id, int userId)
        {
            try
            {
                var query = $"Delete from {_tableName} where {_id} = @{_id} and {_userId} = @{_userId}";
                using (var connections = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connections);
                    command.Parameters.AddWithValue($"@{_id}", id);
                    command.Parameters.AddWithValue($"@{_userId}", userId);
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
