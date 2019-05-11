//using QuikRide.ModelsData;
using CGH.QuikRide.Xam.ModelData.QR;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using QuikRide.ModelsData;
using SQLite;
using System;
using System.Threading.Tasks;

namespace QuikRide.Services
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
                    Connection.CreateTable<Vehicle>();
                    Connection.CreateTable<VehicleBusRoute>();
                    Connection.CreateTable<VehicleFeatureType>();
                    Connection.CreateTable<VehicleStatusType>();
                    Connection.CreateTable<VehicleType>();
                    Connection.CreateTable<VehicleTypeVehicleFeatureType>();
                    Connection.CreateTable<VehicleVehicleFeatureType>();

                    Connection.CreateTable<LanguageType>();
                    Connection.CreateTable<FeedbackType>();
                    Connection.CreateTable<FeedbackTypeTranslation>();
                    Connection.CreateTable<Feedback>();

                    Connection.CreateTable<User>();

                    Connection.CreateTable<Location>();
                    Connection.CreateTable<ReservationRequest>();

                    Connection.CreateTable<Barcode>();
                    Connection.CreateTable<BarcodeScanLog>();
                    Connection.CreateTable<BarcodeType>();
                    Connection.CreateTable<BarcodeTypeTranslation>();

                    Connection.CreateTable<BusRoute>();
                    Connection.CreateTable<BusRouteStop>();
                    Connection.CreateTable<BusRouteTranslation>();

                    Connection.CreateTable<GeofenceActivity>();

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
                    await AsyncConnection.DropTableAsync<Vehicle>();
                    await AsyncConnection.DropTableAsync<VehicleBusRoute>();
                    await AsyncConnection.DropTableAsync<VehicleFeatureType>();
                    await AsyncConnection.DropTableAsync<VehicleStatusType>();
                    await AsyncConnection.DropTableAsync<VehicleType>();
                    await AsyncConnection.DropTableAsync<VehicleTypeVehicleFeatureType>();
                    await AsyncConnection.DropTableAsync<VehicleVehicleFeatureType>();

                    await AsyncConnection.DropTableAsync<LanguageType>();
                    await AsyncConnection.DropTableAsync<FeedbackType>();
                    await AsyncConnection.DropTableAsync<FeedbackTypeTranslation>();
                    await AsyncConnection.DropTableAsync<Feedback>();

                    await AsyncConnection.DropTableAsync<User>();

                    await AsyncConnection.DropTableAsync<Location>();
                    await AsyncConnection.DropTableAsync<ReservationRequest>();

                    await AsyncConnection.DropTableAsync<Barcode>();
                    await AsyncConnection.DropTableAsync<BarcodeScanLog>();
                    await AsyncConnection.DropTableAsync<BarcodeType>();
                    await AsyncConnection.DropTableAsync<BarcodeTypeTranslation>();

                    await AsyncConnection.DropTableAsync<BusRoute>();
                    await AsyncConnection.DropTableAsync<BusRouteStop>();
                    await AsyncConnection.DropTableAsync<BusRouteTranslation>();

                    await AsyncConnection.DropTableAsync<GeofenceActivity>();

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