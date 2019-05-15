using MSC.CM.Xam.ModelObj.CM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSC.CM.XaSh.Services
{
    public interface IDataStore
    {
        Task<IEnumerable<Announcement>> GetAnnouncementsAsync();

        Task<IEnumerable<Session>> GetSessionsAsync();

        Task<IEnumerable<SessionSpeaker>> GetSpeakersAsync();
    }
}