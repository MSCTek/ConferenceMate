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

        public async Task<IEnumerable<Announcement>> GetAnnouncementsAsync(bool forceRefresh = false)
        {
            var returnMe = new List<Announcement>();

            returnMe.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement00.ToModelObj());
            returnMe.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement01.ToModelObj());

            return returnMe;
        }
    }
}