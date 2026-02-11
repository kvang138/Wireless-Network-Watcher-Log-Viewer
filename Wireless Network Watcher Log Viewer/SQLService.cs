/***
 * 
 *  This class is used for interacting with the SQL Server.
 * 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessNetWatcherLogViewer
{
    public class SQLService : IDisposable
    {
        private SqlConnection _connection;

        // Log in to the SQL server.
        public async Task<bool> logIn(Dictionary<string, string> connectionInfo)
        {
            _connection = new SqlConnection($"Server={connectionInfo["serverAndInstance"]};Database={connectionInfo["database"]};"
                                                 + $"User Id={connectionInfo["username"]};Password={connectionInfo["password"]};"
                                                 + $"Encrypt={bool.Parse(connectionInfo["encrypt"])};"
                                                 + $"TrustServerCertificate={bool.Parse(connectionInfo["trustServerCertificate"])};");

            try
            {
                await _connection.OpenAsync();

                return true;
            }
            catch (Exception ex)
            {
                _connection.Dispose();
                _connection.Close();

                return false;
            }
        }

        // Load the logs from the SQL server into a datable.
        public async Task<DataTable> getDataTableWithReaderAsync(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, _connection))
                {
                    // Wait asynchronously for all the logs to load before continuing
                    using (SqlDataReader sqlReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        dataTable.Load(sqlReader);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dataTable;
        }

        // Dispose the connection.
        public void Dispose()
        {
            _connection?.Dispose();
        }

        // Close the connection with the SQL server.
        public void Close()
        {
            _connection?.Dispose();
            _connection?.Close();
        }

        // The deconstructor for disposing and closing the connection with the SQL server.
        ~SQLService()
        {
            try
            {
                _connection?.Dispose();
                _connection?.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
