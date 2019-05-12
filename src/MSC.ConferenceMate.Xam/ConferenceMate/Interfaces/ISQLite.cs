using SQLite;

namespace ConferenceMate.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();

        SQLiteConnection GetConnection();
    }
}