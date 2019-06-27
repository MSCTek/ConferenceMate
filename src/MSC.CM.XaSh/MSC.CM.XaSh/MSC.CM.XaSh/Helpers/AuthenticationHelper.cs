using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MSC.CM.XaSh.Helpers
{
    public static class AuthenticationHelper
    {
        public static void ClearSecureStorageAuthValues()
        {
            SecureStorage.Remove(Consts.AUTH_TOKEN);
            SecureStorage.Remove(Consts.REFRESH_TOKEN);
            SecureStorage.Remove(Consts.TOKEN_EXPIRATION);
        }

        public static string GetToken()
        {
            return AsyncHelper.RunSync(() => SecureStorage.GetAsync(Consts.AUTH_TOKEN));
        }

        public static void SetTokens(string authToken, string refreshToken, string expiration)
        {
            AsyncHelper.RunSync(async () =>
            {
                SecureStorage.SetAsync(Consts.AUTH_TOKEN, authToken);
                SecureStorage.SetAsync(Consts.AUTH_TOKEN, refreshToken);
                SecureStorage.SetAsync(Consts.AUTH_TOKEN, expiration);
            });
        }
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