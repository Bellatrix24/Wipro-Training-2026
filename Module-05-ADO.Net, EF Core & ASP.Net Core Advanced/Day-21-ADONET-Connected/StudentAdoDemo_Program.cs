using System;
using Microsoft.Data.SqlClient;

namespace Day21ADONETConnected
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Day 21 ADO.NET Connected Architecture Lab ===");

            // Hey diary! This is our connection string. It tells our program exactly where the SQL server
            // is located, what database we want to use, and how to verify our identity (using Windows auth).
            string conString = "Server=(localdb)\\MSSQLLocalDB;Database=WiproStudentDb;Trusted_Connection=True;TrustServerCertificate=True;";

            // Let's set up our connection object using our connection string.
            // Think of this like a telephone line that we are laying down between C# and SQL Server.
            SqlConnection connection = new SqlConnection(conString);

            try
            {
                // Here we open the pipe! This establishes the live, active connection to the database.
                // Keep in mind: We must open it as late as possible and close it as early as possible.
                connection.Open();
                Console.WriteLine("\n[Success] Connection opened! The direct line is live.");

                // ----------------------------------------------------
                // 1. Data Insertion Block (Standard Raw Query)
                // ----------------------------------------------------
                Console.WriteLine("\n--- Running Raw Insertion Lab ---");
                
                // Let's draft the raw SQL command to insert a student.
                string insertQuery = "INSERT INTO Students (Name, Age) VALUES ('Amit', 21);";
                
                // SqlCommand is our courier. It takes our query text and carries it down the connection pipe.
                SqlCommand insertCmd = new SqlCommand(insertQuery, connection);

                // ExecuteNonQuery is specifically used for queries that don't return data rows 
                // (like INSERT, UPDATE, DELETE). It returns the count of affected rows.
                int rowsAffected = insertCmd.ExecuteNonQuery();
                Console.WriteLine($"Raw Insert Result: Success! {rowsAffected} student record added directly.");


                // ----------------------------------------------------
                // 2. Parameterized Insertion Block (Secure Way)
                // ----------------------------------------------------
                Console.WriteLine("\n--- Running Parameterized Insertion Lab (Secure Way) ---");

                // Stitching plain strings together in queries is dangerous because of SQL Injection!
                // Using parameter placeholders like @name and @age is our ultimate shield.
                string paramInsertQuery = "INSERT INTO Students (Name, Age) VALUES (@name, @age);";
                SqlCommand paramCmd = new SqlCommand(paramInsertQuery, connection);

                // We add the values safely here. The SQL driver guarantees these inputs are treated 
                // strictly as plain data values, not executable SQL statements.
                paramCmd.Parameters.AddWithValue("@name", "Parth");
                paramCmd.Parameters.AddWithValue("@age", 22);

                int paramRowsAffected = paramCmd.ExecuteNonQuery();
                Console.WriteLine($"Parameterized Insert Result: Success! {paramRowsAffected} student record added safely.");


                // ----------------------------------------------------
                // 3. Data Reading Block (Connected Data Reader)
                // ----------------------------------------------------
                Console.WriteLine("\n--- Fetching Records with SqlDataReader ---");

                // Let's run a standard SELECT query to view all students currently in the table.
                string selectQuery = "SELECT * FROM Students;";
                SqlCommand selectCmd = new SqlCommand(selectQuery, connection);

                // SqlDataReader acts like a forward-only flashlight. 
                // It lets us stream rows one-by-one directly from the server.
                // It holds the connection open until we close the reader!
                SqlDataReader dr = selectCmd.ExecuteReader();

                Console.WriteLine("\nList of Students currently in DB:");
                
                // The Read() method moves to the next record and returns true if there is a row.
                // If it hits the end, it returns false and stops the loop.
                while (dr.Read())
                {
                    // Accessing columns using the indexer of the data reader
                    object id = dr[0];
                    object name = dr[1];
                    object age = dr[2];

                    Console.WriteLine($" -> ID: {id} | Student Name: {name} | Student Age: {age}");
                }

                // Crucial step! Always close the reader when you're done with it 
                // so that the connection is free to perform other database tasks.
                dr.Close();
                Console.WriteLine("SqlDataReader closed successfully.");
            }
            catch (SqlException ex)
            {
                // This catches database-specific problems, like a misspelled table name or server outage.
                Console.WriteLine($"\n[Database Error] SQL Server didn't like that: {ex.Message}");
            }
            catch (Exception ex)
            {
                // This catches other general issues (like parsing errors, null references).
                Console.WriteLine($"\n[Application Error] Something went wrong: {ex.Message}");
            }
            finally
            {
                // Don't forget to close the connection so the server doesn't run out of memory!
                // The 'finally' block runs no matter what, making sure we clean up database resources safely.
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("\n[Cleanup] SqlConnection is closed. Resources are freed up!");
                }
            }
        }
    }
}
