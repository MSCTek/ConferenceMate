using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeGenHero.DataService;
using MSC.ConferenceMate.DataService.Models;
using xDTO = MSC.ConferenceMate.DTO.CM;

namespace MSC.ConferenceMate.API.Client.Interface
{
	public partial interface IWebApiDataServiceCM : IWebApiDataServiceBase
	{
		Task<UserProfilePhoto> GetUserProfileThumbnailAsync(int userProfileId);

		Task<bool> SaveUserProfileImageAsync(UserProfilePhoto userProfilePhoto);
	}
}