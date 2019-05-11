using QuikRide.Interfaces;
using SQLite;
using System.IO;
using Windows.Storage;

namespace QuikRide.UWP.Services
{
    public class UWPSQLite : ISQLite
    {
        private string DBName = $"QuikRide.db3";

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, DBName);
            var conn = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            return conn;
        }

        public SQLiteConnection GetConnection()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, DBName);
            var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            return conn;
        }
    }
}