using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain.Manager
{
    public class MatrixDbManager
    {
        public string ConnectionString => ConfigurationManager.AppSettings["connectionString"];

        public void Connect()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            Console.WriteLine($"Connected...{connection.ServerVersion}");
        }
    }
}
