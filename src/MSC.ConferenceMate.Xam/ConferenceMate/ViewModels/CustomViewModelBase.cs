using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace QuikRide.ViewModels
{
    public abstract class CustomViewModelBase<TParameter> : CustomViewModelBase, IViewModelBaseWithParam<TParameter>
    {
        //https://developer.xamarin.com/api/type/System.IDisposable/
        //http://stackoverflow.com/questions/538060/proper-use-of-the-idisposable-interface

        public CustomViewModelBase(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
        {
            if (navService == null)
                throw new ArgumentException("Invalid navService");

            NavService = navService;
            DataLoadService = dataLoadService;
            DataRetrievalService = dataRetrievalService;
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }

    public abstract class CustomViewModelBase
        : ViewModelBase, IViewModelBase, IDisposable
    {
        private double _currentViewPortHeight;
        private double _currentViewPortWidth;
        private bool _disposed;
        private bool _isBusy;
        private bool _isDev;

        public CustomViewModelBase(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
        {
            if (navService == null)
                throw new ArgumentException("Invalid navService");

            NavService = navService;
            DataLoadService = dataLoadService;
            DataRetrievalService = dataRetrievalService;

            IsDev = false;
#if DEBUG
            IsDev = true;
#endif
        }

        protected CustomViewModelBase()
        {
        }

        //finalizers are expensive and should only used in debug mode... says Xamarin.
        ~CustomViewModelBase()
        {
            Debug.WriteLine("MMSViewModelBase Finalizer Running");
            Dispose(false);
        }

        public RelayCommand BackCommand { get { return new RelayCommand(async () => await NavService.GoBack()); } }

        public bool IsDev
        {
            get { return _isDev; }
            set { Set(ref _isDev, value); }
        }

        public double CurrentViewPortHeight
        {
            get { return _currentViewPortHeight; }
            set
            {
                _currentViewPortHeight = value;
                RaisePropertyChanged();
            }
        }

        public async Task CheckBadQueuedRecords()
        {
            //this checks to see if we have any records that have attemped upload numerous times and sends an app center message, if needed.
            int count = await DataRetrievalService.GetCountQueuedRecordsWAttemptsAsync();
            Debug.WriteLine($"Number of Queued Records with too many Failed Attempts? {count}");
        }

        public async Task CheckAppCenter()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    Debug.WriteLine($"Analytics are Enabled? {await Analytics.IsEnabledAsync()}");
                    Debug.WriteLine($"Crash Reporting is Enabled? {await Crashes.IsEnabledAsync()}");
                    //Debug.WriteLine($"Distribution Notices are Enabled? {await Distribute.IsEnabledAsync()}");
                    //Debug.WriteLine($"Push Notifications are Enabled? {await Push.IsEnabledAsync()}");
                }
                catch (Exception ex)
                {
                    //ha ha - this probably won't work right away...but what the heck?
                    Crashes.TrackError(ex);
                    Debug.WriteLine("App Center enable check is Failing!");
                }
            }
        }

        public double CurrentViewPortWidth
        {
            get { return _currentViewPortWidth; }
            set
            {
                _currentViewPortWidth = value;
                RaisePropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
                OnIsBusyChanged();
            }
        }

        protected static INavigationService NavService { get; set; }
        protected static IDataLoadService DataLoadService { get; set; }
        protected static IDataRetrievalService DataRetrievalService { get; set; }

        public override void Cleanup()
        {
            base.Cleanup();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            //Debug.WriteLine("Running CG from MMSViewModelBase");
            //GC.Collect();
            //GC.SuppressFinalize(this);
        }

        public abstract Task Init();

        /*public bool SetUp()
        {
            //TODO: move this to the constructors...but hey, so convienient just like this...maybe leave it as is...
            var ker = ((QuikRide.App)Xamarin.Forms.Application.Current).Kernel;
            //_dataService = ker.Get<IDataRetrievalService>();
            DataLoadService = ker.Get<IDataLoadService>();
            return true;
        }*/

        public void SetViewPort(double width, double height)
        {
            // Set ViewPort height and width
            if (CurrentViewPortWidth != width || CurrentViewPortHeight != height)
            {
                CurrentViewPortWidth = width;
                CurrentViewPortHeight = height;
                // Set ViewPort Background Image
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        protected virtual void OnIsBusyChanged()
        {
        }
    }
}