using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dataModel = MSC.ConferenceMate.Xam.ModelData.QR;
using objModel = MSC.ConferenceMate.Xam.ModelObj.QR;

namespace ConferenceMate.Interfaces
{
    public interface IDataRetrievalService
    {
        Task<IList<objModel.FeedbackType>> GetAllFeedbackTypes();

        Task<List<ModelsObj.GeofenceActivity>> GetAllGeofenceActivity();

        Task<List<objModel.Location>> GetAllLocations();

        Task<List<objModel.User>> GetAllUsers();

        Task<IList<objModel.Vehicle>> GetAllVehicles();

        Task<int> GetCountQueuedRecordsWAttemptsAsync();

        int GetCurrentUserId();

        Task<List<ModelsObj.GeofenceActivity>> GetRecentGeofenceActivity(int numRecords);

        Task QueueAsync(Guid recordId, QueueableObjects objName);

        Task RunQueuedUpdatesAsync(CancellationToken cts);

        void SetCurrentUserId(int id);

        void StartSafeQueuedUpdates();

        Task<int> WriteBarcodeScanRecord(dataModel.BarcodeScanLog logRecord);

        Task<int> WriteFeedbackRecord(dataModel.Feedback feedback);

        Task<int> WriteGeofencingActivityRecord(ModelsData.GeofenceActivity geofenceActivity);
    }
}