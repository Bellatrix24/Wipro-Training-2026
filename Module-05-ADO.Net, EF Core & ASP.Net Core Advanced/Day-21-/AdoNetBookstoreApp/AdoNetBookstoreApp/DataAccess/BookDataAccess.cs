using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AdoNetBookstoreApp.Models;

namespace AdoNetBookstoreApp.DataAccess
{
    public class BookDataAccess
    {
        private readonly string _connectionString;
        private static bool _useFallbackMode = false;

        // Static in-memory database to simulate data when SQL Server is offline
        private static readonly List<Book> _inMemoryBooks = new List<Book>
        {
            new Book { BookId = 1, Title = "ADO.NET Fundamentals (Offline Simulation)", Author = "Elisabeth Freeman", ISBN = "978-0-596-00712-6", Price = 45.99m },
            new Book { BookId = 2, Title = "SQL Server Architecture (Offline Simulation)", Author = "Robert C. Martin", ISBN = "978-0-13-449416-6", Price = 55.00m },
            new Book { BookId = 3, Title = "Disconnected Data Patterns (Offline Simulation)", Author = "Mark Seemann", ISBN = "978-1-935182-47-4", Price = 39.99m }
        };

        public BookDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=(localdb)\\MSSQLLocalDB;Database=BookstoreAdoDb;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        // Method demonstrating SqlDataReader (forward-only, read-only retrieval)
        public IEnumerable<Book> GetAllBooks()
        {
            var books = new List<Book>();

            if (_useFallbackMode)
            {
                return _inMemoryBooks;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT BookId, Title, Author, ISBN, Price FROM Books";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                books.Add(new Book
                                {
                                    BookId = Convert.ToInt32(reader["BookId"]),
                                    Title = reader["Title"].ToString() ?? string.Empty,
                                    Author = reader["Author"].ToString() ?? string.Empty,
                                    ISBN = reader["ISBN"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"])
                                });
                            }
                        }
                    }
                }
                return books;
            }
            catch (SqlException)
            {
                // SQL Server is offline, fallback to in-memory list
                _useFallbackMode = true;
                return _inMemoryBooks;
            }
        }

        // Method demonstrating parameterized query (protects against SQL Injection)
        public Book? GetBookById(int id)
        {
            if (_useFallbackMode)
            {
                return _inMemoryBooks.Find(b => b.BookId == id);
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT BookId, Title, Author, ISBN, Price FROM Books WHERE BookId = @BookId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Safely adding parameter to prevent SQL Injection
                        command.Parameters.Add("@BookId", SqlDbType.Int).Value = id;

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Book
                                {
                                    BookId = Convert.ToInt32(reader["BookId"]),
                                    Title = reader["Title"].ToString() ?? string.Empty,
                                    Author = reader["Author"].ToString() ?? string.Empty,
                                    ISBN = reader["ISBN"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
                return _inMemoryBooks.Find(b => b.BookId == id);
            }
        }

        // Method demonstrating Stored Procedure call with output parameters
        public void AddBook(Book book)
        {
            if (_useFallbackMode)
            {
                book.BookId = _inMemoryBooks.Count > 0 ? _inMemoryBooks[_inMemoryBooks.Count - 1].BookId + 1 : 1;
                _inMemoryBooks.Add(book);
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("AddBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Price", book.Price);

                        // Output parameter to capture identity column
                        var outputParam = new SqlParameter("@BookId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        book.BookId = Convert.ToInt32(outputParam.Value);
                    }
                }
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
                book.BookId = _inMemoryBooks.Count > 0 ? _inMemoryBooks[_inMemoryBooks.Count - 1].BookId + 1 : 1;
                _inMemoryBooks.Add(book);
            }
        }

        // Method demonstrating Stored Procedure call for UPDATE
        public void UpdateBook(Book book)
        {
            if (_useFallbackMode)
            {
                var existing = _inMemoryBooks.Find(b => b.BookId == book.BookId);
                if (existing != null)
                {
                    existing.Title = book.Title;
                    existing.Author = book.Author;
                    existing.ISBN = book.ISBN;
                    existing.Price = book.Price;
                }
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("UpdateBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", book.BookId);
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Price", book.Price);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
                var existing = _inMemoryBooks.Find(b => b.BookId == book.BookId);
                if (existing != null)
                {
                    existing.Title = book.Title;
                    existing.Author = book.Author;
                    existing.ISBN = book.ISBN;
                    existing.Price = book.Price;
                }
            }
        }

        // Method demonstrating Stored Procedure call for DELETE
        public void DeleteBook(int id)
        {
            if (_useFallbackMode)
            {
                var existing = _inMemoryBooks.Find(b => b.BookId == id);
                if (existing != null)
                {
                    _inMemoryBooks.Remove(existing);
                }
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("DeleteBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookId", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
                var existing = _inMemoryBooks.Find(b => b.BookId == id);
                if (existing != null)
                {
                    _inMemoryBooks.Remove(existing);
                }
            }
        }

        // Method demonstrating SqlDataAdapter & Disconnected DataSet retrieval
        public DataSet GetBooksDataSet()
        {
            var dataSet = new DataSet();

            if (_useFallbackMode)
            {
                // Create a simulated DataTable inside DataSet for offline disconnected data demo
                var table = new DataTable("Books");
                table.Columns.Add("BookId", typeof(int));
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Author", typeof(string));
                table.Columns.Add("ISBN", typeof(string));
                table.Columns.Add("Price", typeof(decimal));

                foreach (var b in _inMemoryBooks)
                {
                    table.Rows.Add(b.BookId, b.Title, b.Author, b.ISBN, b.Price);
                }
                dataSet.Tables.Add(table);
                return dataSet;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT BookId, Title, Author, ISBN, Price FROM Books";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Books");
                    }
                }
                return dataSet;
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
                
                var table = new DataTable("Books");
                table.Columns.Add("BookId", typeof(int));
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Author", typeof(string));
                table.Columns.Add("ISBN", typeof(string));
                table.Columns.Add("Price", typeof(decimal));

                foreach (var b in _inMemoryBooks)
                {
                    table.Rows.Add(b.BookId, b.Title, b.Author, b.ISBN, b.Price);
                }
                dataSet.Tables.Add(table);
                return dataSet;
            }
        }

        // Method demonstrating updating database disconnectedly using SqlDataAdapter
        public void UpdateBooksDisconnected(DataSet dataSet)
        {
            if (_useFallbackMode)
            {
                // Sync the offline list with the disconnected DataSet DataTable changes
                var table = dataSet.Tables["Books"];
                if (table != null)
                {
                    _inMemoryBooks.Clear();
                    foreach (DataRow row in table.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            _inMemoryBooks.Add(new Book
                            {
                                BookId = Convert.ToInt32(row["BookId"]),
                                Title = row["Title"].ToString() ?? string.Empty,
                                Author = row["Author"].ToString() ?? string.Empty,
                                ISBN = row["ISBN"].ToString() ?? string.Empty,
                                Price = Convert.ToDecimal(row["Price"])
                            });
                        }
                    }
                }
                return;
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "SELECT BookId, Title, Author, ISBN, Price FROM Books";
                    using (var adapter = new SqlDataAdapter(query, connection))
                    {
                        using (var builder = new SqlCommandBuilder(adapter))
                        {
                            connection.Open();
                            adapter.Update(dataSet, "Books");
                        }
                    }
                }
            }
            catch (SqlException)
            {
                _useFallbackMode = true;
            }
        }
    }
}
