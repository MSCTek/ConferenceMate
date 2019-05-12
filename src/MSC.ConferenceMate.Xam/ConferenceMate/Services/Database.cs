//using ConferenceMate.ModelsData;
using MSC.CM.Xam.ModelData.CM;
using Microsoft.AppCenter.Crashes;
using ConferenceMate.Interfaces;
using ConferenceMate.ModelsData;
using SQLite;
using System;
using System.Threading.Tasks;

namespace ConferenceMate.Services
{
    public sealed class Database : IDatabase
    {
        public Database()
        {
        }

        public SQLiteAsyncConnection AsyncConnection { get; private set; }

        public SQLiteConnection Connection { get; private set; }

        public void CreateTables()
        {
            try
            {
                if (Connection != null)
                {
                    Connection.CreateTable<LanguageType>();
                    Connection.CreateTable<FeedbackType>();
                    Connection.CreateTable<LookupList>();
                    Connection.CreateTable<Feedback>();
                    Connection.CreateTable<User>();
                    Connection.CreateTable<Queue>();
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                throw new InvalidOperationException($"Error creating sqlite database tables. {ex.Message}");
            }
        }

        public async Task DropTablesAsync()
        {
            try
            {
                if (AsyncConnection != null)
                {
                    await AsyncConnection.DropTableAsync<LanguageType>();
                    await AsyncConnection.DropTableAsync<FeedbackType>();
                    await AsyncConnection.DropTableAsync<LookupList>();
                    await AsyncConnection.DropTableAsync<Feedback>();
                    await AsyncConnection.DropTableAsync<User>();
                    await AsyncConnection.DropTableAsync<Queue>();
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                throw new InvalidOperationException($"Error creating sqlite database tables. {ex.Message}");
            }
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return AsyncConnection;
        }

        public SQLiteConnection GetConnection()
        {
            return Connection;
        }

        public async Task RestoreCurrentUserDatabaseAsync()
        {
            await DropTablesAsync();
            CreateTables();
        }

        public void SetConnection(SQLiteConnection conn, SQLiteAsyncConnection asyncConn)
        {
            Connection = conn;
            AsyncConnection = asyncConn;
        }
    }
}