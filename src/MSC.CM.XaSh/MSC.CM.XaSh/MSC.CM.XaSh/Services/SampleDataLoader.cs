using MSC.CM.Xam.ModelData.CM;
using MSC.CM.XaSh.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSC.CM.XaSh.Services
{
    public class SampleDataLoader : IDataLoader
    {
        private SQLiteAsyncConnection conn = App.Database.conn;

        public async Task<bool> HeartbeatCheck()
        {
            return true;
        }

        public async Task<int> LoadAnnouncementsAsync()
        {
            if (await conn.Table<Announcement>().CountAsync() > 0)
            {
                await conn.Table<Announcement>().DeleteAsync();
            }

            var myList = new List<Announcement>() {
                DemoAnnouncement.SampleAnnouncement00,
                DemoAnnouncement.SampleAnnouncement01
            };

            return await conn.InsertAllAsync(myList);
        }
    }
}