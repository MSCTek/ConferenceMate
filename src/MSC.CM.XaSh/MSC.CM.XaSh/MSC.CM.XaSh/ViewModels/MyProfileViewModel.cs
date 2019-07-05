using MSC.CM.Xam.ModelObj.CM;
using MSC.CM.XaSh.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
	public class MyProfileViewModel : BaseViewModel
	{
		private UserProfile _currentUser;
		private bool _isUserLoggedIn;

		private ImageSource _myProfileImage = null;

		public MyProfileViewModel(IDataStore store = null, IDataLoader loader = null)
		{
			DataStore = store;
			DataLoader = loader;
			Title = "My Profile";
		}

		public UserProfile CurrentUser
		{
			get { return _currentUser; }
			set { Set(ref _currentUser, value); }
		}

		public ICommand EditProfileCommand => new Command(() => Shell.Current.GoToAsync(new ShellNavigationState("profileedit")));

		public bool IsUserLoggedIn
		{
			get { return _isUserLoggedIn; }
			set { Set(ref _isUserLoggedIn, value); }
		}

		public ImageSource MyProfileImage
		{
			get { return _myProfileImage; }
			set { Set(ref _myProfileImage, value); }
		}

		public ICommand TwitterCommand => new Command(() => Device.OpenUri(new Uri("https://www.twitter.com"))); //if(CurrentUser != null) { Device.OpenUri(new Uri(CurrentUser.TwitterUrl)); });

		public async Task LoadVM()
		{
			//see if there is a user 'logged in'
			int currentUserProfileId = Preferences.Get(Consts.CURRENT_USER_PROFILE_ID, 0);
			if (currentUserProfileId != 0)
			{
				CurrentUser = await DataStore.GetUserByUserProfileIdAsync(currentUserProfileId);
				IsUserLoggedIn = CurrentUser != null ? true : false;

				if (IsUserLoggedIn)
				{
					ConferenceMate.DataService.Models.UserProfilePhoto userProfilePhoto = await DataLoader.GetUserProfileThumbnailAsync(currentUserProfileId);
					if (userProfilePhoto != null && userProfilePhoto.Data.Length > 0)
					{
						MyProfileImage = ImageSource.FromStream(() => new MemoryStream(userProfilePhoto.Data));
					}
					else
					{
						MyProfileImage = ImageSource.FromResource("xamarinstore.jpg");
					}
				}
			}
		}

		public async Task LoginWithUserId(int userProfileId)
		{
			if (userProfileId != 0)
			{
				CurrentUser = await DataStore.GetUserByUserProfileIdAsync(userProfileId);
				if (CurrentUser != null)
				{
					IsUserLoggedIn = true;
					Preferences.Set(Consts.CURRENT_USER_PROFILE_ID, userProfileId);
				}
			}
		}

		public void Logout()
		{
			CurrentUser = null;
			IsUserLoggedIn = false;
			Preferences.Remove(Consts.CURRENT_USER_PROFILE_ID);
		}
	}
}