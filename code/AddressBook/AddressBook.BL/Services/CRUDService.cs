using MySqlConnector;

namespace AddressBook.BL.Services
{
    public class CRUDService<T> : ICRUDService<T> where T : class
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _id;

        public CRUDService(string connectionString, string tableName, string id)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _id = id;
        }

        public async Task<List<T>> GetAllAsync()
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

        public async Task<T> GetBuIdAsync(int id)
        {
            try
            {
                var properties = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
                var query = $"Select {properties} form {_tableName} where {_id} = @{_id}";
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

        public Task<bool> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
