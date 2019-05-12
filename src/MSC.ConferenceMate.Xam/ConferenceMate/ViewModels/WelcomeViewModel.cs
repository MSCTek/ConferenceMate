using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Ninject;
using ConferenceMate.Interfaces;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ConferenceMate.ViewModels
{
	public class WelcomeViewModel : ObservableObject
	{
		protected IDataLoadService _dataLoadService;
		protected INavigationService _navService;

		//protected IDataRetrievalService _dataService;
		private string _displayMessage;

		private bool _isBusy = false;
		private bool _showTryAgainButton;

		public WelcomeViewModel()
		{
			DisplayMessage = string.Empty;
			ShowTryAgainButton = false;
			IsBusy = false;
		}

		public string DisplayMessage
		{
			get { return _displayMessage; }
			set { Set(nameof(DisplayMessage), ref _displayMessage, value); }
		}

		public bool IsBusy
		{
			get { return _isBusy; }
			set { Set(ref _isBusy, value); }
		}

		public bool ShowTryAgainButton
		{
			get { return _showTryAgainButton; }
			set { Set(nameof(ShowTryAgainButton), ref _showTryAgainButton, value); }
		}

		public RelayCommand TryAgainCommand
		{
			get
			{
				return new RelayCommand(async () =>
				{
					await Init();
				});
			}
		}

		public async Task Init()
		{
			DisplayMessage = string.Empty;
			ShowTryAgainButton = false;
			IsBusy = true;

			if (SetUp())
			{
				if (Connectivity.NetworkAccess == NetworkAccess.Internet)
				{
					if (await _dataLoadService.HeartbeatCheck())
					{
						DisplayMessage = $"Loading.";

						DisplayMessage = $"Loading Lookup Lists...";
						var numLoadLookupLists = await _dataLoadService.LoadLookupLists();
						await Task.Delay(500);

						DisplayMessage = $"Loading Type Data...";
						var numFeedbackTypes = await _dataLoadService.LoadFeedbackTypes();
						var numLanguageTypes = await _dataLoadService.LoadLanguageTypes();
						await Task.Delay(500);

						//we would probably not do this in real life...
						var numUsers = await _dataLoadService.LoadUsers();
						DisplayMessage = $"Loading User Data...";
						await Task.Delay(500);

						DisplayMessage = $"All Done - Data Loaded";
						IsBusy = false;
						await Task.Delay(500);
						await _navService.StartNavStack(typeof(HomeViewModel));
					}
					else
					{
						//No API
						DisplayMessage = $"Our services are down. Please try again later.";
						IsBusy = false;
						ShowTryAgainButton = true;
					}
				}
				else
				{
					//no connectivity
					DisplayMessage = $"Limited or no internet connectivity. Please try again!";
					IsBusy = false;
					ShowTryAgainButton = true;
				}
			}
		}

		private bool SetUp()
		{
			//TODO: move this to the constructors...but hey, so convienient just like this...maybe leave it as is...
			var ker = ((ConferenceMate.App)Xamarin.Forms.Application.Current).Kernel;
			//_dataService = ker.Get<IDataRetrievalService>();
			_navService = ker.Get<INavigationService>();
			_dataLoadService = ker.Get<IDataLoadService>();
			return true;
		}
	}
}