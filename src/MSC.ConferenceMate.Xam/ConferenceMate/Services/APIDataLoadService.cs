using CGH.QuikRide.API.Client;
using CGH.QuikRide.API.Client.Interface;
using CGH.QuikRide.Service.DataService.Models;
using CGH.QuikRide.Xam;
using CGH.QuikRide.Xam.ModelData.QR;
using CodeGenHero.DataService;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CGH.QuikRide.Service.DataService.Constants.Enums;

namespace QuikRide.Services
{
    public class APIDataLoadService : IDataLoadService
    {
        private IDatabase _db;
        private IWebApiDataServiceQR _webAPIDataService;

        public APIDataLoadService(IDatabase database)
        {
            _db = database;
            var webApiExecutionContextType = new QRWebApiExecutionContextType();
            webApiExecutionContextType.Current = (int)ExecutionContextTypes.Base;

            WebApiExecutionContext context = new WebApiExecutionContext(
                executionContextType: webApiExecutionContextType,
                baseWebApiUrl: Config.BaseWebApiUrl,
                baseFileUrl: string.Empty,
                connectionIdentifier: null);

            _webAPIDataService = new WebApiDataServiceQR(null, context);
        }

        public async Task<bool> HeartbeatCheck()
        {
            try
            {
                return await _webAPIDataService.IsServiceOnlineAsync();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public async Task<int> LoadBarcodes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Barcode>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<Barcode>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBarcodesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadBarcodeTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BarcodeType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<BarcodeType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBarcodeTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadBarcodeTypeTranslations()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BarcodeTypeTranslation>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<BarcodeTypeTranslation>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBarcodeTypeTranslationsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadBusRoutes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRoute>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<BusRoute>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBusRoutesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadBusRouteStops()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRouteStop>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<BusRouteStop>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBusRouteStopsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadBusRouteTranslations()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRouteTranslation>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<BusRouteTranslation>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesBusRouteTranslationsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadFeedbackTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<FeedbackType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<FeedbackType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesFeedbackTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadFeedbackTypeTranslations()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<FeedbackTypeTranslation>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<FeedbackTypeTranslation>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesFeedbackTypeTranslationsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadLanguageTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<LanguageType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<LanguageType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesLanguageTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadLocations()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Location>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<Location>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesLocationsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadReservationRequests()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<ReservationRequest>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<ReservationRequest>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesReservationRequestsAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadUser(int userId)
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<User>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<User>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dto = await _webAPIDataService.GetUserAsync(userId, 0);
                int count = 0;
                if (dto != null)
                {
                    count += await _db.GetAsyncConnection().InsertOrReplaceAsync(dto.Data.ToModelData());
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadUsers()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<User>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<User>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesUsersAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleBusRoutes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleBusRoute>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleBusRoute>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleBusRoutesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleFeatureTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleFeatureType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleFeatureType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleFeatureTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicles()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Vehicle>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<Vehicle>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehiclesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleStatusTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleStatusType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleStatusType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleStatusTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleTypeVehicleFeatureTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleTypeVehicleFeatureType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleTypeVehicleFeatureType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleTypeVehicleFeatureTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadVehicleVehicleFeatureTypes()
        {
            try
            {
                DateTime? lastUpdatedDate = null;
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleVehicleFeatureType>().CountAsync() > 0)
                {
                    var lastUpdated = await _db.GetAsyncConnection().Table<VehicleVehicleFeatureType>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
                    lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
                }

                var dtos = await _webAPIDataService.GetAllPagesVehicleVehicleFeatureTypesAsync(lastUpdatedDate);
                int count = 0;
                if (dtos.Any())
                {
                    foreach (var r in dtos)
                    {
                        count += await _db.GetAsyncConnection().InsertOrReplaceAsync(r.ToModelData());
                    }
                    return count;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }
    }
}