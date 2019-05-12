using MSC.ConferenceMate.API.Client;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.DataService.Models;
using MSC.CM.Xam;
using MSC.CM.Xam.ModelData.CM;
using CodeGenHero.DataService;
using Microsoft.AppCenter.Crashes;
using ConferenceMate.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using static MSC.ConferenceMate.DataService.Constants.Enums;

namespace ConferenceMate.Services
{
    public class APIDataLoadService : IDataLoadService
    {
        private IDatabase _db;
        private IWebApiDataServiceCM _webAPIDataService;

        public APIDataLoadService(IDatabase database)
        {
            _db = database;
            var webApiExecutionContextType = new CMWebApiExecutionContextType();
            webApiExecutionContextType.Current = (int)ExecutionContextTypes.Base;

            WebApiExecutionContext context = new WebApiExecutionContext(
                executionContextType: webApiExecutionContextType,
                baseWebApiUrl: Config.BaseWebApiUrl,
                baseFileUrl: string.Empty,
                connectionIdentifier: null);

            _webAPIDataService = new WebApiDataServiceCM(null, context);
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

        public async Task<int> LoadLookupLists()
        {
            try
            {
                DateTime? lastUpdatedDate = null;

				// If the table has records in it, drop and create a new one.
				if (await _db.GetAsyncConnection().Table<LookupList>().CountAsync() > 0)
				{
					var lastUpdated = await _db.GetAsyncConnection().Table<LookupList>().OrderByDescending(x => x.ModifiedUtcDate).FirstAsync();
					lastUpdatedDate = lastUpdated != null ? lastUpdated?.ModifiedUtcDate : null;
				}

				var dtos = await _webAPIDataService.GetAllPagesLookupListsAsync(lastUpdatedDate);
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

    }
}