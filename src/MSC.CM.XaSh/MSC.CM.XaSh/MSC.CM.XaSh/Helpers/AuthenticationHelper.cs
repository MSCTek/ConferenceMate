using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MSC.CM.XaSh.Helpers
{
    public static class AuthenticationHelper
    {
    }

    public class AuthenticationResult
    {
        public string access_token { get; set; }
        public string expires { get; set; }
        public int expires_in { get; set; }
        public string issued { get; set; }
        public string refresh_token { get; set; }
        public string roles { get; set; }
        public string token_type { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
    }
}