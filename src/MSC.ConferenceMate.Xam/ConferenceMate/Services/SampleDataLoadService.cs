using Microsoft.AppCenter.Crashes;
using ConferenceMate.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MSC.CM.Xam.ModelData.CM;

namespace ConferenceMate.Services
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
                        MSC.CM.Xam.ModelData.CM.DemoFeedbackType.SampleFeedbackType00,
                        MSC.CM.Xam.ModelData.CM.DemoFeedbackType.SampleFeedbackType01
                };

                return await _db.GetAsyncConnection().InsertAllAsync(feedbackTypes);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }

        public async Task<int> LoadLookupLists()
        {
            try
            {
                //if the table has records in it, drop and create a new one.
                if (await _db.GetAsyncConnection().Table<LookupList>().CountAsync() > 0)
                {
                    await _db.GetAsyncConnection().DropTableAsync<LookupList>();
                    await Task.Delay(500);
                    await _db.GetAsyncConnection().CreateTableAsync<LookupList>();
                    await Task.Delay(500);
                }

                var lookupLists = new List<LookupList>()
                {
						MSC.CM.Xam.ModelData.CM.DemoLookupList.SampleLookupList00,
						MSC.CM.Xam.ModelData.CM.DemoLookupList.SampleLookupList01
                };

                return await _db.GetAsyncConnection().InsertAllAsync(lookupLists);
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
                        MSC.CM.Xam.ModelData.CM.DemoLanguageType.SampleLanguageType00,
                        MSC.CM.Xam.ModelData.CM.DemoLanguageType.SampleLanguageType01
                };

                return await _db.GetAsyncConnection().InsertAllAsync(languageTypes);
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
                        MSC.CM.Xam.ModelData.CM.DemoUser.SampleUser00
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
                        MSC.CM.Xam.ModelData.CM.DemoUser.SampleUser00,
                        MSC.CM.Xam.ModelData.CM.DemoUser.SampleUser01
                };

                return await _db.GetAsyncConnection().InsertAllAsync(users);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return 0;
            }
        }
    }
}