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

namespace MSC.CM.XaSh.ViewModels
{
    public class AnnouncementsViewModel : BaseViewModel
    {
        public ObservableCollection<Announcement> Announcements { get; private set; }
        public Command LoadItemsCommand { get; set; }

        private IDataStore<Announcement> _dataStore;
        public IDataStore<Announcement> DataStore
        {
            get
            {
                if (_dataStore != null)
                    return _dataStore;
                //_dataStore = DependencyService.Get<IDataStore<Announcement>>();
                return _dataStore;
            }
            set => _dataStore = value;
        }

        public AnnouncementsViewModel(IDataStore<Announcement> store = null)
        {
            DataStore = store;
            Title = "Announcements";
            Announcements = new ObservableCollection<Announcement>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Announcements.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Announcements.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
