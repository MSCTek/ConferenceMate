using MSC.CM.Xam.ModelObj.CM;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using MSC.CM.Xam;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using MSC.CM.XaSh.Services;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AppCenter.Crashes;
using GalaSoft.MvvmLight.Command;
using Xamarin.Essentials;

namespace MSC.CM.XaSh.ViewModels
{
    public class AnnouncementsViewModel : BaseViewModel
    {
        public AnnouncementsViewModel(IDataStore store = null, IDataLoader loader = null)
        {
            DataStore = store;
            DataLoader = loader;
            Title = "Announcements";
            Announcements = new ObservableCollection<Announcement>();
        }

        public ObservableCollection<Announcement> Announcements { get; private set; }

        public IDataLoader DataLoader { get; set; }

        public IDataStore DataStore { get; set; }

        public async Task RefreshListViewData()
        {
            if (IsBusy) { return; }

            IsBusy = true;

            try
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet && await DataLoader.HeartbeatCheck())
                {
                    //load SQLite from API or sample data
                    await DataLoader.LoadAnnouncementsAsync();
                }

                //clear local list
                Announcements.Clear();

                //populate local list
                var items = await DataStore.GetAnnouncementsAsync(true);
                foreach (var item in items)
                {
                    Announcements.Add(item);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}