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
        private UserProfile _currentUser;
        private string _email;
        private string _firstName;
        private string _jobTitle;
        private string _lastName;
        private string _twitterUrl;

        public MyProfileEditViewModel(IDataStore store = null, IDataLoader loader = null, IDataUploader uploader = null)
        {
            DataStore = store;
            DataLoader = loader;
            DataUploader = uploader;
            Title = "Edit My Profile";
        }

        public string Biography
        {
            get { return _biography; }
            set { Set(ref _biography, value); }
        }

        public ICommand CancelCommand => new Command(() => ExecuteCancelCommand());

        public ICommand ChangeProfileImageCommand => new Command(() => DoWhateverWeNeedToDoToCaptureAnImage());

        public string CompanyName
        {
            get { return _companyName; }
            set { Set(ref _companyName, value); }
        }

        public UserProfile CurrentUser
        {
            get { return _currentUser; }
            set { Set(ref _currentUser, value); }
        }

        //public string Email
        //{
        //    get { return _email; }
        //    set { Set(ref _email, value); }
        //}

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

        public ICommand SaveCommand => new Command(() => ExecuteSaveCommand());

        public string TwitterUrl
        {
            get { return _twitterUrl; }
            set { Set(ref _twitterUrl, value); }
        }

        public async Task LoadVM()
        {
            //see if there is a user 'logged in'
            int currentUserId = Preferences.Get(Consts.CURRENT_USER_PROFILE_ID, 0);
            if (currentUserId != 0)
            {
                CurrentUser = await DataStore.GetUserByUserProfileIdAsync(currentUserId);

                Biography = CurrentUser.Biography;
                CompanyName = CurrentUser.CompanyName;
                FirstName = CurrentUser.FirstName;
                LastName = CurrentUser.LastName;
                JobTitle = CurrentUser.JobTitle;
                TwitterUrl = CurrentUser.TwitterUrl;
            }
        }

        private void DoWhateverWeNeedToDoToCaptureAnImage()
        {
            //do something here
            Debug.WriteLine("Do Whatever We Need To Do To Capture An Image");
        }

        private void ExecuteCancelCommand()
        {
            Biography = CurrentUser.Biography;
            CompanyName = CurrentUser.CompanyName;
            //Email = CurrentUser.Email;
            FirstName = CurrentUser.FirstName;
            LastName = CurrentUser.LastName;
            JobTitle = CurrentUser.JobTitle;
            TwitterUrl = CurrentUser.TwitterUrl;
        }

        private async void ExecuteSaveCommand()
        {
            if (ValidateProfile())
            {
                var editedCurrentUser = new Xam.ModelData.CM.UserProfile()
                {
                    AvatarUrl = CurrentUser.AvatarUrl,
                    Biography = Biography,
                    BirthDate = CurrentUser.BirthDate,
                    BlogUrl = CurrentUser.BlogUrl,
                    CompanyName = CompanyName,
                    CompanyWebsiteUrl = CurrentUser.CompanyWebsiteUrl,
                    CreatedBy = CurrentUser.CreatedBy,
                    CreatedUtcDate = CurrentUser.CreatedUtcDate,
                    //Email = Email,
                    FirstName = FirstName,
                    GenderTypeId = CurrentUser.GenderTypeId,
                    IsDeleted = false,
                    JobTitle = JobTitle,
                    LastLogin = CurrentUser.LastLogin,
                    LastName = LastName,
                    LinkedInUrl = CurrentUser.LinkedInUrl,
                    ModifiedBy = CurrentUser.UserProfileId.ToString(),
                    ModifiedUtcDate = DateTime.UtcNow,
                    //PhotoUrl  <= //TODO
                    PreferredLanguageId = CurrentUser.PreferredLanguageId,
                    TwitterUrl = TwitterUrl,
                    UserProfileId = CurrentUser.UserProfileId,
                    DataVersion = CurrentUser.DataVersion
                };
                if (await DataStore.UpdateUserRecord(editedCurrentUser) == 1)
                {
                    await DataUploader.QueueAsync(CurrentUser.UserProfileId, QueueableObjects.UserProfileUpdate);
                    DataUploader.StartSafeQueuedUpdates();
                }
            }
        }

        private bool ValidateProfile()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                AppShell.Current.DisplayAlert("Error", "First Name is Required", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(LastName))
            {
                AppShell.Current.DisplayAlert("Error", "Last Name is Required", "OK");
                return false;
            }

            //if (string.IsNullOrEmpty(Email))
            //{
            //    AppShell.Current.DisplayAlert("Error", "Email is Required", "OK");
            //    return false;
            //}
            //if (!Helpers.RegexUtilities.IsValidEmail(Email))
            //{
            //    AppShell.Current.DisplayAlert("Error", "Email is Not Valid", "OK");
            //    return false;
            //}

            return true;
        }

        //public ICommand SaveCommand => new Command(() => Device.OpenUri(new Uri(CurrentUser.TwitterUrl)));
    }
}