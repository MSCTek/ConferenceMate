using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSC.CM.XaSh.Services
{
    public interface IDataLoader
    {
        Task<bool> HeartbeatCheck();

        Task<int> LoadAnnouncementsAsync(bool forceRefresh = false);

        Task<int> LoadFeedbackInitiatorTypesAsync(bool forceRefresh = false);

        Task<int> LoadFeedbackTypesAsync(bool forceRefresh = false);

        Task<int> LoadRoomsAsync(bool forceRefresh = false);

        Task<int> LoadSessionsAsync(bool forceRefresh = false);

        Task<int> LoadSessionSpeakersAsync(bool forceRefresh = false);

        Task<int> LoadUsersAsync(bool forceRefresh = false);
    }
}