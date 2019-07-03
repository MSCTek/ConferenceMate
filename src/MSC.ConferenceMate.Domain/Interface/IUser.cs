using System.IO;
using System.Threading.Tasks;

namespace MSC.ConferenceMate.Domain.Interface
{
	public interface IUser
	{
		Task<bool> SetUserProfilePhotoAsync(int userProfileId, string fileName, long? SizeInBytes, string createdByOrModifiedByUser, Stream ms);
	}
}