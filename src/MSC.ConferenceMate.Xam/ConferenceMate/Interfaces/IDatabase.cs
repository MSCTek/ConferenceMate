using SQLite;
using System.Threading.Tasks;

namespace QuikRide.Interfaces
{
    public interface IDatabase
    {
        void CreateTables();

        Task DropTablesAsync();

        SQLiteAsyncConnection GetAsyncConnection();

        SQLiteConnection GetConnection();

        Task RestoreCurrentUserDatabaseAsync();

        void SetConnection(SQLiteConnection conn, SQLiteAsyncConnection asyncConn);
    }
}