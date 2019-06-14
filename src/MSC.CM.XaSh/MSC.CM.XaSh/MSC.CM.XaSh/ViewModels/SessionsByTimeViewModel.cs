using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MSC.CM.Xam.ModelObj.CM;
using Xamarin.Forms;
using MSC.CM.Xam;
using MSC.CM.XaSh.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Diagnostics;
using Microsoft.AppCenter.Crashes;
using GalaSoft.MvvmLight.Command;
using MSC.CM.XaSh.Helpers;

namespace MSC.CM.XaSh.ViewModels
{
	public class SessionsByTimeViewModel : BaseViewModel
	{
		private ObservableCollection<Session> _sessions;

		public SessionsByTimeViewModel(IDataStore store = null, IDataLoader loader = null)
		{
			DataStore = store;
			DataLoader = loader;
			Title = "Sessions By Time";
			Sessions = new ObservableCollection<Session>();
		}

		public RelayCommand<int> LikeCommand
		{
			get
			{
				return new RelayCommand<int>(async (sessionId) =>
				{
					try
					{
						if (await DataStore.ToggleSessionLikeAsync(sessionId))
						{
							//re populate local list from sqlite
							Sessions = (await DataStore.GetSessionsAsync()).ToObservableCollection();
						}
					}
					catch (Exception ex)
					{
						Crashes.TrackError(ex);
					}
				});
			}
		}

		public ObservableCollection<Session> Sessions
		{
			get { return _sessions; }
			set { Set(nameof(Sessions), ref _sessions, value); }
		}

		public async Task RefreshListViewData()
		{
			if (IsBusy) { return; }

			IsBusy = true;

			try
			{
				if ((Connectivity.NetworkAccess == NetworkAccess.Internet && await DataLoader.HeartbeatCheck()) || App.UseSampleDataStore)
				{
					//load SQLite from API or sample data
					var ctUsers = await DataLoader.LoadUsersAsync();
					Debug.WriteLine($"Loaded {ctUsers} Users.");
					var ctRooms = await DataLoader.LoadRoomsAsync();
					Debug.WriteLine($"Loaded {ctRooms} Rooms.");
					var ctSessions = await DataLoader.LoadSessionsAsync();
					Debug.WriteLine($"Loaded {ctSessions} Sessions.");
					var ctSessionSpeakers = await DataLoader.LoadSessionSpeakersAsync();
					Debug.WriteLine($"Loaded {ctSessionSpeakers} SessionSpeakers.");
				}

				//clear local list
				Sessions.Clear();

				//populate local list
				var items = await DataStore.GetSessionsAsync();
				foreach (var item in items)
				{
					Sessions.Add(item);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.StackTrace);
				Crashes.TrackError(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}

		internal async Task SetSessionLike(int sessionId, bool value)
		{
			await DataStore.SetSessionLikeAsync(sessionId, value);
			//DataUploader.QueueAsync()
		}
	}
}