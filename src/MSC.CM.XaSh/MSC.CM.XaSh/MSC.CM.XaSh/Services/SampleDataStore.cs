using MSC.CM.Xam;
using modelObj = MSC.CM.Xam.ModelObj.CM;
using modelData = MSC.CM.Xam.ModelData.CM;
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

        public async Task<IEnumerable<modelObj.Announcement>> GetAnnouncementsAsync()
        {
            var returnMe = new List<modelObj.Announcement>();

            returnMe.Add(modelData.DemoAnnouncement.SampleAnnouncement00.ToModelObj());
            returnMe.Add(modelData.DemoAnnouncement.SampleAnnouncement01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<modelObj.Session>> GetFavoriteSessionsAsync()
        {
            var returnMe = new List<modelObj.Session>();

            returnMe.Add(modelData.DemoSession.SampleSession00.ToModelObj());
            returnMe.Add(modelData.DemoSession.SampleSession01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<modelObj.FeedbackType>> GetFeedbackTypesAsync()
        {
            var returnMe = new List<modelObj.FeedbackType>();

            returnMe.Add(modelData.DemoFeedbackType.SampleFeedbackType00.ToModelObj());
            returnMe.Add(modelData.DemoFeedbackType.SampleFeedbackType01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<modelObj.Session>> GetSessionsAsync()
        {
            var returnMe = new List<modelObj.Session>();

            returnMe.Add(modelData.DemoSession.SampleSession00.ToModelObj());
            returnMe.Add(modelData.DemoSession.SampleSession01.ToModelObj());

            return returnMe;
        }

        public async Task<IEnumerable<modelObj.User>> GetSpeakersAsync()
        {
            var returnMe = new List<modelObj.User>();

            returnMe.Add(modelData.DemoUser.SampleUser00.ToModelObj());
            returnMe.Add(modelData.DemoUser.SampleUser01.ToModelObj());

            return returnMe;
        }

        public Task<modelObj.User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task SetSessionLikeAsync(int sessionId, bool value)
        {
            return;
        }

        public async Task<int> WriteFeedbackRecord(modelData.Feedback feedbackData)
        {
            return 0;
        }
    }
}