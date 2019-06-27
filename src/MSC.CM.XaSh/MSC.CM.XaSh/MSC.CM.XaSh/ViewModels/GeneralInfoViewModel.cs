using GalaSoft.MvvmLight.Command;
using MSC.CM.XaSh.Helpers;
using MSC.CM.XaSh.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class GeneralInfoViewModel : BaseViewModel
    {
        private string _currentUserEmail;
        private int _currentUserId;
        private string _currentUserPassword;

        public GeneralInfoViewModel(IDataStore store = null, IDataLoader loader = null)
        {
            DataStore = store;
            DataLoader = loader;
            Title = "GeneralInfo";

            IsUserLoggedIn();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            base.CheckAppCenter();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public string CurrentUserEmail
        {
            get { return _currentUserEmail; }
            set { Set(ref _currentUserEmail, value); }
        }

        public int CurrentUserId
        {
            get { return _currentUserId; }
            set { Set(ref _currentUserId, value); }
        }

        public string CurrentUserPassword
        {
            get { return _currentUserPassword; }
            set { Set(ref _currentUserPassword, value); }
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await DataLoader.GetAuthToken(CurrentUserEmail, CurrentUserPassword);
                });
            }
        }

        internal async Task RefreshUserData()
        {
            if ((Connectivity.NetworkAccess == NetworkAccess.Internet && await DataLoader.HeartbeatCheck()) || App.UseSampleDataStore)
            {
                //load SQLite from API or sample data
                var countUsers = await DataLoader.LoadUsersAsync();
                Debug.WriteLine($"Loaded {countUsers} Users.");
                var countFeedbackInitTypes = await DataLoader.LoadFeedbackInitiatorTypesAsync();
                Debug.WriteLine($"Loaded {countFeedbackInitTypes} Feedback Initiator Types.");
                var countFeedbackTypes = await DataLoader.LoadFeedbackTypesAsync();
                Debug.WriteLine($"Loaded {countFeedbackTypes} Feedback Types.");
            }
        }

        private void AutoLogin(int currentUser)
        {
            //set the userprofileid in the preferences
            Preferences.Set(App.CURRENT_USER_ID, CurrentUserId);

            //we are hot wiring a car here... until we build proper authentication UI
            var email = string.Empty;
            switch (CurrentUserId)
            {
                case 1:
                    email = "David@example.com"; break;
                case 2:
                    email = "James@example.com"; break;
                case 3:
                    email = "Donovan@example.com"; break;
            }

            DataLoader.GetAuthToken(email, "test");
        }

        private bool IsUserLoggedIn()
        {
            var currentId = Preferences.Get(App.CURRENT_USER_ID, 0);
            if (currentId == 0)
            {
                //no user logged in yet
                Preferences.Set(App.CURRENT_USER_EMAIL, string.Empty);
                CurrentUserPassword = "test";
                return false;
            }
            else
            {
                //there is a user logged in
                CurrentUserEmail = Preferences.Get(App.CURRENT_USER_EMAIL, string.Empty);
                CurrentUserPassword = "test";
                return true;
            }
        }
    }
}