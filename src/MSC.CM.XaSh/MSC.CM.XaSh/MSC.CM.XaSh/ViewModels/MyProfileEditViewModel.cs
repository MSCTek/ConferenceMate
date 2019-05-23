using MSC.CM.Xam.ModelObj.CM;
using MSC.CM.XaSh.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class MyProfileEditViewModel : BaseViewModel
    {
        private string _biography;
        private string _companyName;
        private User _currentUser;
        private string _email;
        private string _firstName;
        private string _jobTitle;
        private string _lastName;
        private string _twitterUrl;

        public MyProfileEditViewModel(IDataStore store = null, IDataLoader loader = null)
        {
            DataStore = store;
            DataLoader = loader;
            Title = "Edit My Profile";
        }

        public string Biography
        {
            get { return _biography; }
            set { Set(ref _biography, value); }
        }

        public ICommand ChangeProfileImageCommand => new Command(() => DoWhateverWeNeedToDoToCaptureAnImage());

        public string CompanyName
        {
            get { return _companyName; }
            set { Set(ref _companyName, value); }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { Set(ref _currentUser, value); }
        }

        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { Set(ref _firstName, value); }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { Set(ref _jobTitle, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        }

        public string TwitterUrl
        {
            get { return _twitterUrl; }
            set { Set(ref _twitterUrl, value); }
        }

        public async Task LoadVM()
        {
            //see if there is a user 'logged in'
            int currentUserId = Preferences.Get(App.CURRENT_USER_ID, 0);
            if (currentUserId != 0)
            {
                CurrentUser = await DataStore.GetUserByIdAsync(currentUserId);

                Biography = CurrentUser.Biography;
                CompanyName = CurrentUser.CompanyName;
                Email = CurrentUser.Email;
                FirstName = CurrentUser.FirstName;
                LastName = CurrentUser.LastName;
                JobTitle = CurrentUser.JobTitle;
                TwitterUrl = CurrentUser.TwitterUrl;

                //IsUserLoggedIn = CurrentUser != null ? true : false;
            }
        }

        private void DoWhateverWeNeedToDoToCaptureAnImage()
        {
            //do something here
            Debug.WriteLine("Do Whatever We Need To Do To Capture An Image");
        }

        //public ICommand SaveCommand => new Command(() => Device.OpenUri(new Uri(CurrentUser.TwitterUrl)));
    }
}