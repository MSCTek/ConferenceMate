using CGH.QuikRide.Xam;
using CGH.QuikRide.Xam.ModelData.QR;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuikRide.Services
{
    public class SampleDataLoadService : IDataLoadService
    {
        private IDatabase _db;

        public SampleDataLoadService(IDatabase database)
        {
            _db = database;
        }

        public async Task<bool> HeartbeatCheck()
        {
            //we always return true for sample data
            return true;
        }

        public async Task<int> LoadBarcodes()
        {
            try
            {
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Barcode>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<Barcode>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<Barcode>();
                    await Task.Delay(500);
                }

                var barcodes = new List<Barcode>()
                {
                        CGH.QuikRide.DTO.QR.DemoBarcode.SampleBarcode00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBarcode.SampleBarcode01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(barcodes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BarcodeType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<BarcodeType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<BarcodeType>();
                    await Task.Delay(500);
                }

                var barcodeTypes = new List<BarcodeType>()
                {
                        CGH.QuikRide.DTO.QR.DemoBarcodeType.SampleBarcodeType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBarcodeType.SampleBarcodeType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(barcodeTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BarcodeTypeTranslation>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<BarcodeTypeTranslation>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<BarcodeTypeTranslation>();
                    await Task.Delay(500);
                }

                var barcodeTypeTranslations = new List<BarcodeTypeTranslation>()
                {
                        CGH.QuikRide.DTO.QR.DemoBarcodeTypeTranslation.SampleBarcodeTypeTranslation00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBarcodeTypeTranslation.SampleBarcodeTypeTranslation01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(barcodeTypeTranslations);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRoute>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<BusRoute>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<BusRoute>();
                    await Task.Delay(500);
                }

                var busRoutes = new List<BusRoute>()
                {
                        CGH.QuikRide.DTO.QR.DemoBusRoute.SampleBusRoute00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBusRoute.SampleBusRoute01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(busRoutes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRouteStop>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<BusRouteStop>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<BusRouteStop>();
                    await Task.Delay(500);
                }

                var busRouteStops = new List<BusRouteStop>()
                {
                        CGH.QuikRide.DTO.QR.DemoBusRouteStop.SampleBusRouteStop00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBusRouteStop.SampleBusRouteStop01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(busRouteStops);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<BusRouteTranslation>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<BusRouteTranslation>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<BusRouteTranslation>();
                    await Task.Delay(500);
                }

                var busRouteTranslations = new List<BusRouteTranslation>()
                {
                        CGH.QuikRide.DTO.QR.DemoBusRouteTranslation.SampleBusRouteTranslation00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoBusRouteTranslation.SampleBusRouteTranslation01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(busRouteTranslations);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<FeedbackType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<FeedbackType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<FeedbackType>();
                    await Task.Delay(500);
                }

                var feedbackTypes = new List<FeedbackType>()
                {
                        CGH.QuikRide.DTO.QR.DemoFeedbackType.SampleFeedbackType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoFeedbackType.SampleFeedbackType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(feedbackTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<FeedbackTypeTranslation>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<FeedbackTypeTranslation>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<FeedbackTypeTranslation>();
                    await Task.Delay(500);
                }

                var feedbackTypeTranslations = new List<FeedbackTypeTranslation>()
                {
                        CGH.QuikRide.DTO.QR.DemoFeedbackTypeTranslation.SampleFeedbackTypeTranslation00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoFeedbackTypeTranslation.SampleFeedbackTypeTranslation01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(feedbackTypeTranslations);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<LanguageType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<LanguageType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<LanguageType>();
                    await Task.Delay(500);
                }

                var languageTypes = new List<LanguageType>()
                {
                        CGH.QuikRide.DTO.QR.DemoLanguageType.SampleLanguageType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoLanguageType.SampleLanguageType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(languageTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Location>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<Location>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<Location>();
                    await Task.Delay(500);
                }

                var locations = new List<Location>()
                {
                        SampleDataModels.SampleLocation.SampleArtInstituteChicago,
                        SampleDataModels.SampleLocation.SampleFabyanVillaMuseum
                };

                return await _db.GetAsyncConnection().InsertAllAsync(locations);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<ReservationRequest>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<ReservationRequest>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<ReservationRequest>();
                    await Task.Delay(500);
                }

                var reservationRequests = new List<ReservationRequest>()
                {
                        SampleDataModels.SampleReservationRequest.SampleFabyanToArtInstitute
                };

                return await _db.GetAsyncConnection().InsertAllAsync(reservationRequests);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<User>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<User>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<User>();
                    await Task.Delay(500);
                }

                var users = new List<User>()
                {
                        CGH.QuikRide.DTO.QR.DemoUser.SampleUser00.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(users);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<User>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<User>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<User>();
                    await Task.Delay(500);
                }

                var users = new List<User>()
                {
                        CGH.QuikRide.DTO.QR.DemoUser.SampleUser00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoUser.SampleUser01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(users);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleBusRoute>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleBusRoute>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleBusRoute>();
                    await Task.Delay(500);
                }

                var vehicleBusRoutes = new List<VehicleBusRoute>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleBusRoute.SampleVehicleBusRoute00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleBusRoute.SampleVehicleBusRoute01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(vehicleBusRoutes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleFeatureType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleFeatureType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleFeatureType>();
                    await Task.Delay(500);
                }

                var vehicleFeatureTypes = new List<VehicleFeatureType>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleFeatureType.SampleVehicleFeatureType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleFeatureType.SampleVehicleFeatureType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(vehicleFeatureTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<Vehicle>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<Vehicle>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<Vehicle>();
                    await Task.Delay(500);
                }

                var vehicles = new List<Vehicle>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicle.SampleVehicle00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicle.SampleVehicle01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(vehicles);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleStatusType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleStatusType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleStatusType>();
                    await Task.Delay(500);
                }

                var vehicleStatusTypes = new List<VehicleStatusType>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleStatusType.SampleVehicleStatusType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleStatusType.SampleVehicleStatusType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(vehicleStatusTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleType>();
                    await Task.Delay(500);
                }

                var vehicleTypes = new List<VehicleType>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleType.SampleVehicleType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleType.SampleVehicleType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(vehicleTypes);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleTypeVehicleFeatureType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleTypeVehicleFeatureType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleTypeVehicleFeatureType>();
                    await Task.Delay(500);
                }

                var recs = new List<VehicleTypeVehicleFeatureType>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleTypeVehicleFeatureType.SampleVehicleTypeVehicleFeatureType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleTypeVehicleFeatureType.SampleVehicleTypeVehicleFeatureType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(recs);
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
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<VehicleVehicleFeatureType>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<VehicleVehicleFeatureType>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<VehicleVehicleFeatureType>();
                    await Task.Delay(500);
                }

                var recs = new List<VehicleVehicleFeatureType>()
                {
                        CGH.QuikRide.DTO.QR.DemoVehicleVehicleFeatureType.SampleVehicleVehicleFeatureType00.ToModelData(),
                        CGH.QuikRide.DTO.QR.DemoVehicleVehicleFeatureType.SampleVehicleVehicleFeatureType01.ToModelData()
                };

                return await _db.GetAsyncConnection().InsertAllAsync(recs);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }
    }
}