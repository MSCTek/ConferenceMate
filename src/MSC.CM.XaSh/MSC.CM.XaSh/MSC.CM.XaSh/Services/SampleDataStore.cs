using MSC.CM.Xam;
using MSC.CM.Xam.ModelObj.CM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSC.CM.XaSh.Services
{
    public class SampleDataStore : IDataStore
    {
        public SampleDataStore()
        {
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync()
        {
            var returnMe = new List<Announcement>();

            returnMe.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement00.ToModelObj());
            returnMe.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            var returnMe = new List<Session>();

            returnMe.Add(Xam.ModelData.CM.DemoSession.SampleSession00.ToModelObj());
            returnMe.Add(Xam.ModelData.CM.DemoSession.SampleSession01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<User>> GetSpeakersAsync()
        {
            var returnMe = new List<User>();

            returnMe.Add(Xam.ModelData.CM.DemoUser.SampleUser00.ToModelObj());
            returnMe.Add(Xam.ModelData.CM.DemoUser.SampleUser01.ToModelObj());

            return returnMe;
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}