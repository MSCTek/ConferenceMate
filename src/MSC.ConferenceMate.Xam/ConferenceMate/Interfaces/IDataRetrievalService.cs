using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dataModel = MSC.CM.Xam.ModelData.CM;
using objModel = MSC.CM.Xam.ModelObj.CM;

namespace ConferenceMate.Interfaces
{
    public interface IDataRetrievalService
    {
        Task<IList<objModel.FeedbackType>> GetAllFeedbackTypes();

        Task<List<objModel.User>> GetAllUsers();

        Task<int> GetCountQueuedRecordsWAttemptsAsync();

        int GetCurrentUserId();

        Task QueueAsync(Guid recordId, QueueableObjects objName);

        Task RunQueuedUpdatesAsync(CancellationToken cts);

        void SetCurrentUserId(int id);

        void StartSafeQueuedUpdates();

        Task<int> WriteFeedbackRecord(dataModel.Feedback feedback);

    }
}