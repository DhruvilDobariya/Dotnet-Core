using MySqlConnector;

namespace AddressBook.BL.Services
{
    public class BLGeneric<T> : IBLGeneric<T> where T : class
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _id;

        public BLGeneric(string connectionString, string tableName, string id)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _id = id;
        }

        #region GetAllAsync
        /// <summary>
        /// Get list of recored of T type object
        /// </summary>
        /// <returns> List of T type object</returns>
        public virtual async Task<List<T>> GetAllAsync()
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var query = $"Select {properties} from {_tableName}";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
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
        /// <returns>T type object</returns>
        public virtual async Task<T> GetBuIdAsync(int id)
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var query = $"Select {properties} from {_tableName} where {_id} = @{_id}";
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue($"@{_id}", id);
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
        /// <param name="id">id represent a primary key of recored which we want to update</param>
        /// <param name="entity">entity represent a T type object which we want to update</param>
        /// <returns>if recored updated successfully then it return true else it return false</returns>
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            var propertiesWithValue = string.Join(",", typeof(T).GetProperties().Select(p => $"{p.Name} = @{p.Name}"));
            var query = $"Update {_tableName} Set {propertiesWithValue} where {_id} = @{_id}";
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
        /// <returns>if recored delete successfully then it return true else it return false</returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var query = $"Delete from {_tableName} where {_id} = @{_id}";
                using (var connections = new MySqlConnection(_connectionString))
                {
                    var command = new MySqlCommand(query, connections);
                    command.Parameters.AddWithValue($"@{_id}", id);
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
    }
}
