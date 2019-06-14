﻿using MSC.CM.XaSh.Services;
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
        public GeneralInfoViewModel(IDataStore store = null, IDataLoader loader = null)
        {
            DataStore = store;
            DataLoader = loader;
            Title = "GeneralInfo";

            var currentUser = Preferences.Get(App.CURRENT_USER_ID, 0);
            //if no one is logged in, default it at 1
            CurrentUserId = currentUser == 0 ? 1 : currentUser;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            base.CheckAppCenter();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private int _currentUserId;

        public int CurrentUserId
        {
            get { return _currentUserId; }
            set
            {
                if (Set(ref _currentUserId, value))
                {
                    Preferences.Set(App.CURRENT_USER_ID, CurrentUserId);
                }
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
    }
}