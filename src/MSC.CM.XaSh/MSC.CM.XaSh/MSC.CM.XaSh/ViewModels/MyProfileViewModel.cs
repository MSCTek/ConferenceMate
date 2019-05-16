using MSC.CM.Xam.ModelObj.CM;
using MSC.CM.XaSh.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        private User _currentUser;
        private bool _isUserLoggedIn;

        public MyProfileViewModel(IDataStore store = null, IDataLoader loader = null)
        {
            DataStore = store;
            DataLoader = loader;
            Title = "My Profile";
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { Set(ref _currentUser, value); }
        }

        public bool IsUserLoggedIn
        {
            get { return _isUserLoggedIn; }
            set { Set(ref _isUserLoggedIn, value); }
        }

        public async Task LoadVM()
        {
            //see if there is a user 'logged in'
            int currentUserId = Preferences.Get(App.CURRENT_USER_ID, 0);
            if (currentUserId != 0)
            {
                CurrentUser = await DataStore.GetUserByIdAsync(currentUserId);
                IsUserLoggedIn = CurrentUser != null ? true : false;
            }
        }

        public async Task LoginWithUserId(int userId)
        {
            if (userId != 0)
            {
                CurrentUser = await DataStore.GetUserByIdAsync(userId);
                if (CurrentUser != null)
                {
                    IsUserLoggedIn = true;
                    Preferences.Set(App.CURRENT_USER_ID, userId);
                }
            }
        }

        public void Logout()
        {
            CurrentUser = null;
            IsUserLoggedIn = false;
            Preferences.Remove(App.CURRENT_USER_ID);
        }
    }
}