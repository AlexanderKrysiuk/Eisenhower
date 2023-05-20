using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace EisenhowerMain.Model
{
    public class MssqlItemsDao : IItemsDao
    {
        private readonly string _connectionString;

        public MssqlItemsDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(string title, DateTime deadline, bool importance)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string saveTodoItemSql = saveItemSql();
                command.CommandText = saveTodoItemSql;
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Deadline", deadline);
                command.Parameters.AddWithValue("@Importance", importance);
                using var reader = command.ExecuteReader();
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

        private string saveItemSql() {
            return @"
INSERT INTO items (title, deadline, isImportant)
VALUES (@Title, @Deadline, @Importance);
";
        }

        public void OverwriteDb()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string overwriteSql =
                    @"DELETE FROM items;";
                command.CommandText = overwriteSql;
                using var reader = command.ExecuteReader();
            }
                        
            catch (SqlException exception)
            {
                throw;
            }

        }

        public void Load(TodoMatrix todoMatrix, bool overwrite)
        {
            try
            {
                /*
                if (overwrite)
                {
                    todoMatrix.RemoveAll();
                }
                */
                var todoItems = new List<TodoItem>();

                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                string selectItemsSql =
                    @"
SELECT title, deadline, isImportant
FROM items;
";
                command.CommandText = selectItemsSql;

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string title = (string)reader["title"];
                    bool importance = (bool)reader["isImportant"];
                    DateTime deadline = Convert.ToDateTime(reader["deadline"]);

                    todoMatrix.AddItem(title, deadline, importance);
                }
            }
            catch (SqlException exception)
            {
                throw;
            }
        }

    }
}
