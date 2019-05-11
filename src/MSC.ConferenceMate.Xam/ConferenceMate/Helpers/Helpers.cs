using Microsoft.AppCenter.Crashes;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuikRide.Helpers
{
    public static class Helpers
    {
        public static async Task<bool> CheckCameraPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        await Application.Current.MainPage.DisplayAlert("Need camera", "Gunna need that camera", "OK");
                    }

                    await Task.Delay(1000); //not sure this is even really needed.

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);

                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Camera))
                        status = results[Permission.Camera];

                    if (status == PermissionStatus.Granted)
                    {
                        return true;
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        await Application.Current.MainPage.DisplayAlert("Camera Permissions Denied", "Can not continue, try again.", "OK");
                    }
                }

                //check one more time, now that we have asked them.
                status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                switch (status)
                {
                    case PermissionStatus.Granted:
                        return true;

                    case PermissionStatus.Denied:
                        await Application.Current.MainPage.DisplayAlert("Camera Permissions Denied", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Disabled:
                        await Application.Current.MainPage.DisplayAlert("Camera Disabled", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Restricted:
                        await Application.Current.MainPage.DisplayAlert("Camera Permissions Restricted", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Unknown:
                        await Application.Current.MainPage.DisplayAlert("Camera Permissions Unknown", "Can not continue, try again.", "OK");
                        return false;

                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        //best to actually call this from a code behind.
        public static async Task<bool> CheckLocationPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationAlways))
                    {
                        await Application.Current.MainPage.DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    await Task.Delay(1000); //not sure this is even really needed.

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationAlways);

                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.LocationAlways))
                        status = results[Permission.LocationAlways];

                    if (status == PermissionStatus.Granted)
                    {
                        return true;
                    }
                    else if (status != PermissionStatus.Unknown)
                    {
                        await Application.Current.MainPage.DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                    }
                }

                //check one more time, now that we have asked them.
                status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
                switch (status)
                {
                    case PermissionStatus.Granted:
                        return true;

                    case PermissionStatus.Denied:
                        await Application.Current.MainPage.DisplayAlert("Location Permissions Denied", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Disabled:
                        await Application.Current.MainPage.DisplayAlert("Location Disabled", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Restricted:
                        await Application.Current.MainPage.DisplayAlert("Location Permissions Restricted", "Can not continue, try again.", "OK");
                        return false;

                    case PermissionStatus.Unknown:
                        await Application.Current.MainPage.DisplayAlert("Location Permissions Unknown", "Can not continue, try again.", "OK");
                        return false;

                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        }

        public static async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
                Application.Current.MainPage.DisplayAlert("Error", "Sorry, email is not supported on this device.", "OK");
                /*Analytics.TrackError(fbsEx, new Dictionary<string, string> {
                { "Where", "AboutUsPage-Email-Tap" },
                { "Error", "Email was not supported on device."}
                });*/
            }
            catch (Exception ex)
            {
                // Some other exception occurred
                /*Analytics.TrackError(ex, new Dictionary<string, string> {
                { "Where", "AboutUsPage-Email-Tap" },
                { "Error", ex.Message}
                });*/
            }
        }
    }
}