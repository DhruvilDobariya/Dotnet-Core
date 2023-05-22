using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace BookAPI.DAL.Services
{
    /// <summary>
    /// It contains data access logic for book crud operation 
    /// </summary>
    public class DALBook : DALGeneric<BOSD03>, IDALBook
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public DALBook(IConfiguration configuration) : base(configuration.GetConnectionString("DefaultConnection"), "BOSD03", "D03F01", "D03F07")
        {
            _configuration = configuration;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get list of books with author name 
        /// </summary>
        /// <param name="userId">userId is reference key to user table</param>
        /// <returns>List of books with author name</returns>
        public async Task<List<BookWithAuthor>> GetBooksWithAuthorAsync(int userId)
        {
            try
            {
                using (var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var command = new MySqlCommand("sp_GetBooks", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_UserId", userId);
                    await connection.OpenAsync();
                    var reader = await command.ExecuteReaderAsync();
                    var books = new List<BookWithAuthor>();
                    while (reader.Read())
                    {
                        var book = new BookWithAuthor();
                        foreach (var properties in typeof(BookWithAuthor).GetProperties())
                        {
                            if (reader[properties.Name] != null)
                            {
                                properties.SetValue(book, reader[properties.Name]);
                            }
                        }
                        books.Add(book);
                    }
                    return books;
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
