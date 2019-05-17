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

        public async Task<int> LoadAnnouncementsAsync(bool forceRefresh = false)
        {
            if (await conn.Table<Announcement>().CountAsync() > 0)
            {
                await conn.Table<Announcement>().Where(x => x.AnnouncementId != 0).DeleteAsync();
            }

            var myList = new List<Announcement>() {
                DemoAnnouncement.SampleAnnouncement00,
                DemoAnnouncement.SampleAnnouncement01
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadFeedbackInitiatorTypesAsync(bool forceRefresh = false)
        {
            if (await conn.Table<FeedbackInitiatorType>().CountAsync() > 0)
            {
                await conn.Table<FeedbackInitiatorType>().Where(x => x.FeedbackInitiatorTypeId != 0).DeleteAsync();
            }

            var myList = new List<FeedbackInitiatorType>() {
                DemoFeedbackInitiatorType.SampleFeedbackInitiatorType00,
                DemoFeedbackInitiatorType.SampleFeedbackInitiatorType01
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadFeedbackTypesAsync(bool forceRefresh = false)
        {
            if (await conn.Table<FeedbackType>().CountAsync() > 0)
            {
                await conn.Table<FeedbackType>().Where(x => x.FeedbackTypeId != 0).DeleteAsync();
            }

            var myList = new List<FeedbackType>() {
                DemoFeedbackType.SampleFeedbackType00,
                DemoFeedbackType.SampleFeedbackType01
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadRoomsAsync(bool forceRefresh = false)
        {
            if (await conn.Table<Room>().CountAsync() > 0)
            {
                await conn.Table<Room>().Where(x => x.RoomId != 0).DeleteAsync();
            }

            var myList = new List<Room>() {
                DemoRoom.SampleRoom00,
                DemoRoom.SampleRoom01
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadSessionsAsync(bool forceRefresh = false)
        {
            if (await conn.Table<Session>().CountAsync() > 0)
            {
                await conn.Table<Session>().Where(x => x.SessionId != 0).DeleteAsync();
            }

            var myList = new List<Session>() {
                DemoSession.SampleSession00,
                DemoSession.SampleSession01,
                DemoSession.SampleSession02,
                DemoSession.SampleSession03,
                DemoSession.SampleSession04,
                DemoSession.SampleSession05
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadSessionSpeakersAsync(bool forceRefresh = false)
        {
            if (await conn.Table<SessionSpeaker>().CountAsync() > 0)
            {
                await conn.Table<SessionSpeaker>().Where(x => x.SessionId != 0).DeleteAsync();
            }

            var myList = new List<SessionSpeaker>() {
                DemoSessionSpeaker.SampleSessionSpeaker00,
                DemoSessionSpeaker.SampleSessionSpeaker01
            };

            return await conn.InsertAllAsync(myList);
        }

        public async Task<int> LoadUsersAsync(bool forceRefresh = false)
        {
            if (await conn.Table<User>().CountAsync() > 0)
            {
                await conn.Table<User>().Where(x => x.UserId != 0).DeleteAsync();
            }

            var myList = new List<User>() {
                DemoUser.SampleUser00,
                DemoUser.SampleUser01
            };

            return await conn.InsertAllAsync(myList);
        }
    }
}