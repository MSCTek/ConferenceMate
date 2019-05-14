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

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            RefreshCommand = new Command(async () => await RefreshDataCommand());
        }

        public ObservableCollection<Announcement> Announcements { get; private set; }

        public IDataLoader DataLoader { get; set; }

        public IDataStore DataStore { get; set; }

        public Command LoadItemsCommand { get; set; }

        public Command RefreshCommand { get; set; }

        private async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
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

        private async Task RefreshDataCommand()
        {
            //why is this already true???
            //if (IsBusy)
            //    return;

            IsBusy = true;

            try
            {
                if (await DataLoader.HeartbeatCheck())
                {
                    //load SQLite from API or sample data
                    await DataLoader.LoadAnnouncementsAsync();
                }

                await Task.Delay(500);

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