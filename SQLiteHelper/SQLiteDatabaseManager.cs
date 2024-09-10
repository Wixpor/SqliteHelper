using System;
using System.Data;
using System.Data.SQLite;

namespace SQLiteHelper
{
    public class SQLiteDatabaseManager
    {
        private string _connectionString;

        // Constructor que recibe el nombre de la base de datos
        public SQLiteDatabaseManager(string databaseName)
        {
            _connectionString = $"Data Source={databaseName};Version=3;";
        }

        // Método para crear una nueva base de datos
        public void CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Base de datos creada o abierta exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Método para crear una tabla
        public void CreateTable(string tableName, string tableDefinition)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string createTableQuery = $"CREATE TABLE IF NOT EXISTS {tableName} ({tableDefinition})";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Tabla '{tableName}' creada exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Método para insertar datos en la tabla
        public bool InsertData(string tableName, string columns, string values)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string insertQuery = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Datos insertados exitosamente.");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
                return false;
            }
        }

        // Método para realizar una consulta SELECT
        public DataTable SelectData(string query)
        {
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Cargar los datos del reader en el DataTable
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message );
            }

            return dataTable;
        }

        // Método para ejecutar una consulta genérica (UPDATE, DELETE)
        public void ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Operación ejecutada exitosamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
