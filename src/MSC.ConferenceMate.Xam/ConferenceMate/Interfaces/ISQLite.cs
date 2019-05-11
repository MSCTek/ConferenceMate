using SQLite;

namespace QuikRide.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();

        SQLiteConnection GetConnection();
    }
}