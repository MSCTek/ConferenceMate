using QuikRide.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using datamod = CGH.QuikRide.Xam.ModelData.QR;

namespace QuikRide.ViewModels
{
    public class LoyaltyScannerViewModel : CustomViewModelBase
    {
        public LoyaltyScannerViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        private Xamarin.Essentials.Location location { get; set; }

        public override async Task Init()
        {
            //use this opportunity to grab the long/lat.
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var locationRealtime = await Geolocation.GetLocationAsync(request);
            location = (locationRealtime == null) ? await Geolocation.GetLastKnownLocationAsync() : locationRealtime;
        }

        internal async Task RecordScanAsync(Guid id)
        {
            var logRecord = BuildLogRecord(id);
            if (1 == await DataRetrievalService.WriteBarcodeScanRecord(logRecord))
            {
                //Queue up the record for upload to the Azure Database
                await DataRetrievalService.QueueAsync(logRecord.BarcodeScanLogId, QueueableObjects.BarcodeScanLog);
                //See if right now is a good time to upload the data - 10 records at a time
                DataRetrievalService.StartSafeQueuedUpdates();
                //navigate
                await NavService.NavigateTo<LoyaltyBonusViewModel>();
            }
            else
            {
                //TODO: rts - everything did not work out very well - write code here
            }
        }

        private datamod.BarcodeScanLog BuildLogRecord(Guid barcodeGuid)
        {
            var barcodeScanLog = new datamod.BarcodeScanLog()
            {
                BarcodeId = barcodeGuid,
                BarcodeScanLogId = Guid.NewGuid(),
                CreatedBy = DataRetrievalService.GetCurrentUserId().ToString(), //TODO: rts - convert to username
                CreatedUtcDate = DateTime.UtcNow,
                DeviceOperatingSystem = Device.RuntimePlatform,
                DeviceOperatingSystemVersion = DeviceInfo.VersionString,
                //Latitude = location != null ? (Double?)location.Latitude : null,
                IsDeleted = false,
                ModifiedBy = DataRetrievalService.GetCurrentUserId().ToString(), //TODO: rts - convert to username
                ModifiedUtcDate = DateTime.UtcNow,
                UserId = DataRetrievalService.GetCurrentUserId()
            };

            if (location != null)
            {
                barcodeScanLog.Latitude = location.Latitude;
                barcodeScanLog.Longitude = location.Longitude;
            }

            return barcodeScanLog;
        }
    }
}