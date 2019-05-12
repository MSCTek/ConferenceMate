using System.Threading.Tasks;

namespace ConferenceMate.Interfaces
{
	public interface IDataLoadService
	{
		Task<bool> HeartbeatCheck();

		Task<int> LoadFeedbackTypes();

		Task<int> LoadLanguageTypes();

		Task<int> LoadLookupLists();

		Task<int> LoadUser(int userId);

		Task<int> LoadUsers();
	}
}