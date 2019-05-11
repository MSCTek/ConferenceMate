using GalaSoft.MvvmLight.Command;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using QuikRide.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuikRide.ViewModels
{
    public class AboutViewModelMVVMDI : CustomViewModelBase
    {
        private string _aboutText1;
        private string _aboutText2;

        public AboutViewModelMVVMDI(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
            : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public string AboutText1
        {
            get { return _aboutText1; }
            set { Set(nameof(AboutText1), ref _aboutText1, value); }
        }

        public string AboutText2
        {
            get { return _aboutText2; }
            set { Set(nameof(AboutText2), ref _aboutText2, value); }
        }

        public RelayCommand CrashCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Crashes.GenerateTestCrash();
                });
            }
        }

        public RelayCommand EmailCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await Helpers.Helpers.SendEmail("Question about QuikTrip", "I was wondering...", new List<string>() { "info@quikride.com" });
                });
            }
        }

        public RelayCommand FacebookCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Device.OpenUri(new Uri("https://facebook.com"));
                });
            }
        }

        public RelayCommand PhoneCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        PhoneDialer.Open("14802275916");
                    }
                    catch (FeatureNotSupportedException)
                    {
                        Application.Current.MainPage.DisplayAlert("Error", "Sorry, the phone dialer is not supported on this device.", "OK");
                        //Analytics.TrackEvent("Phone Call Attempted");

                        Analytics.TrackEvent("Phone Call Attempted",
                            new Dictionary<string, string> {
                            { "Where", "AboutUsPage-PhoneNumber-Tap" },
                            { "Error", "Phone dialer was not supported on device."},
                            { "User", "Robin"}
                        });
                    }
                    catch (Exception ex)
                    {
                        Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                        Crashes.TrackError(ex,
                            new Dictionary<string, string>{
                                { "Where", "AboutUsPage-PhoneNumber-Tap" },
                                { "Error", ex.Message },
                                { "User", "Robin" }
                        });
                    }
                });
            }
        }

        public RelayCommand SlackCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Wait!", "You must be a member to join our Slack Channel!", "OK");
                });
            }
        }

        public RelayCommand TwitterCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Device.OpenUri(new Uri("https://twitter.com"));
                });
            }
        }

        public override async Task Init()
        {
            //do something async here
            AboutText1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur volutpat massa vitae turpis vestibulum, id ultrices ante suscipit. Morbi feugiat massa ut eros imperdiet luctus. Sed dapibus, magna sed varius accumsan, sem nibh elementum massa, vitae sodales libero erat eget purus. Maecenas nisl nibh, commodo quis tortor eu, semper facilisis erat. Maecenas at auctor risus, at pulvinar sem. Vestibulum elementum, purus venenatis laoreet ornare, magna metus condimentum quam, at varius lorem elit nec nisl. Donec nec rhoncus ipsum, a imperdiet erat.";
            AboutText2 = "Morbi a neque id diam pellentesque dictum vel eu justo.Fusce quis nisl sit amet turpis euismod pulvinar. Aliquam erat volutpat.Interdum et malesuada fames ac ante ipsum primis in faucibus.Suspendisse id nisi varius velit posuere egestas sit amet in felis.Sed facilisis nulla libero, ornare pharetra sapien tincidunt at. Pellentesque pellentesque leo id suscipit consectetur. Aliquam sed enim sit amet nulla facilisis semper. Fusce porttitor tristique ex, non egestas dolor euismod et. Sed arcu arcu, venenatis ac congue posuere, laoreet et urna. Nulla tristique ante sed enim laoreet, sed blandit nulla ullamcorper.Nunc elementum tincidunt turpis. Pellentesque laoreet ipsum quis venenatis maximus. Pellentesque et ligula sed sem porttitor scelerisque.";
        }
    }
}