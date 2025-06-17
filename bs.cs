using System;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

namespace _basedeDatos
{
    public class DataBaseManager
    {
        public void _dataBase(string nombre, string email,dynamic password)
        {
            string conectionString = "Data Source=usuarios.db;Version=3;";

    using (var connection = new SQLiteConnection(conectionString))
    {
        connection.Open();

        string createTable = @"
            CREATE TABLE IF NOT EXISTS Usuarios (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Email TEXT NOT NULL,
                PasswordHash TEXT NOT NULL
            );";

        using (var createCmd = new SQLiteCommand(createTable, connection))
        {
            createCmd.ExecuteNonQuery();
        }

        string passwordHash = CalcularHash(password);

        string insertUser = "INSERT INTO Usuarios (Nombre, Email, PasswordHash) VALUES (@nombre, @email, @hash);";

        using (var insertCmd = new SQLiteCommand(insertUser, connection))
        {
            insertCmd.Parameters.AddWithValue("@nombre", nombre);
            insertCmd.Parameters.AddWithValue("@email", email);
            insertCmd.Parameters.AddWithValue("@hash", passwordHash);
            insertCmd.ExecuteNonQuery();
        }

        Console.WriteLine("Usuario guardado exitosamente.");
    }
}

        private static string CalcularHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
