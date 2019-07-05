using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using CodeGenHero.DataService;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.DataService.Models;
using MSC.ConferenceMate.DataService.Extensions;
using System.Linq;
using System.Net.Mime;

namespace MSC.ConferenceMate.API.Client
{
	public partial class WebApiDataServiceCM : WebApiDataServiceBase, IWebApiDataServiceCM
	{
		public async Task<UserProfilePhoto> GetUserProfileThumbnailAsync(int userProfileId)
		{
			UserProfilePhoto retVal = new UserProfilePhoto();
			HttpClient client = this.HttpClient;

			using (HttpResponseMessage response = await client.GetAsync($"CM/UserProfileThumbnail/{userProfileId}", HttpCompletionOption.ResponseHeadersRead))
			{
				if (response.IsSuccessStatusCode)
				{
					retVal.Data = await response.Content.ReadAsByteArrayAsync();
					string contentDispositionString = response.Content.Headers.GetValues("Content-Disposition").FirstOrDefault();
					ContentDisposition contentDisposition = new ContentDisposition(contentDispositionString);
					string filename = contentDisposition.FileName;
					retVal.FileName = filename;
				}
			}

			return retVal;
		}
	}
}