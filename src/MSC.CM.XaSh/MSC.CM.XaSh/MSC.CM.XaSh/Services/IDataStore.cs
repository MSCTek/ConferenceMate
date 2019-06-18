using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using modelObj = MSC.CM.Xam.ModelObj.CM;
using modelData = MSC.CM.Xam.ModelData.CM;

namespace MSC.CM.XaSh.Services
{
    public interface IDataStore
    {
        Task<IEnumerable<modelObj.Announcement>> GetAnnouncementsAsync();

        Task<IEnumerable<modelObj.Session>> GetFavoriteSessionsAsync();

        Task<IEnumerable<modelObj.FeedbackType>> GetFeedbackTypesAsync();

        Task<modelObj.Room> GetRoomById(int roomId);

        Task<IEnumerable<modelObj.Session>> GetSessionsAsync();

        Task<IEnumerable<modelObj.Session>> GetSessionsWithRoomsAsync();

        Task<IEnumerable<modelObj.User>> GetSpeakersAsync();

        Task<modelObj.User> GetUserByIdAsync(int userId);

        Task<bool> ToggleSessionLikeAsync(int sessionId);

        Task<int> UpdateUserRecord(modelData.User editedCurrentUser);

        Task<int> WriteFeedbackRecord(modelData.Feedback feedbackData);
    }
}