using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using MSC.CM.Xam.ModelData.CM;
using SQLite;

namespace MSC.CM.XaSh.Database
{
    public class ConferenceMateDatabase
    {
        public readonly SQLiteAsyncConnection conn;

        public ConferenceMateDatabase(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            if (conn != null)
            {
                CreateTables();
            }
        }

        private void CreateTables()
        {
            try
            {
                conn.CreateTableAsync<Announcement>().Wait();
                conn.CreateTableAsync<FeaturedEvent>().Wait();
                conn.CreateTableAsync<Feedback>().Wait();
                conn.CreateTableAsync<FeedbackInitiatorType>().Wait();
                conn.CreateTableAsync<FeedbackType>().Wait();
                conn.CreateTableAsync<GenderType>().Wait();
                conn.CreateTableAsync<LanguageType>().Wait();
                conn.CreateTableAsync<LookupList>().Wait();
                conn.CreateTableAsync<Room>().Wait();
                conn.CreateTableAsync<Session>().Wait();
                conn.CreateTableAsync<SessionCategoryType>().Wait();
                conn.CreateTableAsync<SessionLike>().Wait();
                conn.CreateTableAsync<SessionSessionCategoryType>().Wait();
                conn.CreateTableAsync<SessionSpeaker>().Wait();
                conn.CreateTableAsync<Sponsor>().Wait();
                conn.CreateTableAsync<SponsorFeaturedEvent>().Wait();
                conn.CreateTableAsync<SponsorType>().Wait();
                conn.CreateTableAsync<User>().Wait();

                conn.CreateTableAsync<MobileModelData.UploadQueue>().Wait();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Crashes.TrackError(ex);
            }
        }
    }
}