using CodeGenHero.Logging;
using CodeGenHero.WebApi;
using MSC.ConferenceMate.Domain;
using MSC.ConferenceMate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using iDom = MSC.ConferenceMate.Domain.Interface;

namespace MSC.ConferenceMate.API.Controllers.CM
{
	public partial class CMUserProfileImagesController : CMBaseApiControllerAuthorized
	{
		private readonly iDom.IUser _domUser = null;

		public CMUserProfileImagesController() : base()
		{
			var azureStorageConfig = new AzureStorageConfig()
			{
				AccountKey = "<your account key>",
				AccountName = "conferencemate",
				ImageContainer = "images",
				QueueName = "",
				ThumbnailContainer = "thumbnails"
			};

			iDom.IAzureStorageManager azureStorageManager = new AzureStorageManager(Log, Repo, azureStorageConfig);
			_domUser = new MSC.ConferenceMate.Domain.User(Log, Repo, azureStorageManager);
		}

		public CMUserProfileImagesController(ILoggingService log, ICMRepository repository, iDom.IUser domUser)
			: base(log, repository)
		{
			_domUser = domUser;
		}

		[HttpPost]
		[VersionedRoute(template: "UserProfileImages", allowedVersion: 1, Name = "CMImageUpload")]
		public async Task<HttpResponseMessage> Upload()
		{
			bool isUploaded = false;
			var updateTasks = new List<Task>();

			try
			{
				var httpRequest = HttpContext.Current.Request;
				if (httpRequest.Files.Count > 0)
				{
					var uploadedFiles = new List<string>();
					foreach (string file in httpRequest.Files)
					{
						var postedFile = httpRequest.Files[file];

						if (IsImage(postedFile.FileName))
						{
							if (postedFile.ContentLength > 0)
							{
								var claimsIdentity = RequestContext.Principal.Identity as ClaimsIdentity;
								var userProfileId = int.Parse(claimsIdentity.Claims.FirstOrDefault(x => x.Type == Consts.CLAIM_USERPROFILEID).Value);

								MemoryStream ms = new MemoryStream();
								postedFile.InputStream.CopyTo(ms);
								postedFile.InputStream.Position = ms.Position = 0;

								try
								{
									isUploaded = await _domUser.SetUserProfilePhotoAsync(userProfileId, postedFile.FileName, postedFile.ContentLength, userProfileId.ToString(), ms);
								}
								catch (Exception ex)
								{
									Log.Error(ex.Message, LogMessageType.Instance.Exception_WebApi, ex);
									return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
								}
							}
						}
						else
						{
							return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "This service only supports image files with an extension of '.jpg', '.png', '.gif', or '.jpeg'.");
						}

						uploadedFiles.Add(postedFile.FileName);
					}

					await Task.WhenAll(updateTasks.ToArray()); // Allow all our async operations to complete.
					return Request.CreateResponse(HttpStatusCode.Created, uploadedFiles);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "No files received in the upload.");
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, LogMessageType.Instance.Exception_WebApiClient, ex);
				return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
			}
		}

		private bool IsImage(string fileName)
		{
			string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
			return formats.Any(x => fileName.EndsWith(x, StringComparison.OrdinalIgnoreCase));
		}
	}
}