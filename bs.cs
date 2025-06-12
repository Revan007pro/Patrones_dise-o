using System;
using System.Data.SQLite;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography; 
using System.Text;
using GLib;

namespace _basedeDatos
{
    class Programa
    {

        static void _dataBase()
        {
            string conectionString = "Data Source=usuarios.db;Verion=3;";
            using (var connetion = new SQLiteConnection(conectionString))
            {
                connetion.Open();
                string createTable = @"
                CREATE IF NOT EXIST Usuarios(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    PasswordHash TEXT NOT NULL
                ;)";
                using (var cmd = new SQLiteCommand(createTable, connetion))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Email:");
                string email = Console.ReadLine();
                Console.WriteLine("Contraseña:");
                string password = Console.ReadLine();

                string PasswordHash = CalcularHash(password);


                string inserUser = "INSERT INTO Usuarios (Nombre, Email, Rol, PasswordHash) VALUES (@nombre, @email, @rol, @hash);";
                using (var cmd = new SQLiteCommand(inserUser, connetion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@hash", PasswordHash);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Usuario guardado exitsamente");
                }

                static string CalcularHash(string input)
                {
                    using (SHA256 sHA256 = SHA256.Create())
                    {
                        var bytes = Encoding.UTF32.GetBytes(input);
                        var hash = sHA256.ComputeHash(bytes);
                        return BitConverter.ToString(hash).Replace("-", "").ToLower();

                    }
                }
            }
        
    }
        
    }
}