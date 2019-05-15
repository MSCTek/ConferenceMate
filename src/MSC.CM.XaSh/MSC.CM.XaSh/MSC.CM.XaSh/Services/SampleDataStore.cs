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

        public async Task<IEnumerable<SessionSpeaker>> GetSpeakersAsync()
        {
            var returnMe = new List<SessionSpeaker>();

            returnMe.Add(Xam.ModelData.CM.DemoSessionSpeaker.SampleSessionSpeaker00.ToModelObj());
            returnMe.Add(Xam.ModelData.CM.DemoSessionSpeaker.SampleSessionSpeaker01.ToModelObj());

            return returnMe;
        }
    }
}