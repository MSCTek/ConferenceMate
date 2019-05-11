using QuikRide.Interfaces;
using SQLite;
using System.IO;

namespace QuikRide.Android.Services
{
    public class DroidSQLite : ISQLite
    {
        private string DBName = $"QickRide.db3";

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, DBName);
            // Create the connection
            var conn = new SQLite.SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            // Return the database connection
            return conn;
        }

        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, DBName);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            // Return the database connection
            return conn;
        }
    }
}