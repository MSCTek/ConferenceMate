using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MSC.ConferenceMate.API.Utils
{
	public class Configuration
	{
		public static int RefreshTokenExpireTimeMinutes => Convert.ToInt32(ConfigurationManager.AppSettings["Token:RefreshTokenExpireTimeMinutes"]);
		public static string TokenAudienceId => ConfigurationManager.AppSettings["Token:AudienceId"];
		public static string TokenAudienceSecret => ConfigurationManager.AppSettings["Token:AudienceSecret"];
		public static int TokenExpireTimeMinutes => Convert.ToInt32(ConfigurationManager.AppSettings["Token:TokenExpireTimeMinutes"]);
		public static string TokenIssuer => ConfigurationManager.AppSettings["Token:Issuer"];
	}
}