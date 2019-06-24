// <auto-generated> - Template:RepositoryInterface, Version:1.1, Id:f766650e-5c46-4239-b6fd-0cfca2673207
using CodeGenHero.Repository;
using MSC.ConferenceMate.Repository.Entities.CM;
using System;
using System.Threading.Tasks;

namespace MSC.ConferenceMate.Repository.Interface
{
	public partial interface ICMRepository : ICMRepositoryCrud
	{

		ICMDataContext CMDataContext { get; }

		Task<IRepositoryActionResult<Announcement>> Delete_AnnouncementAsync(int announcementId);
		Task<Announcement> Get_AnnouncementAsync(int announcementId, int numChildLevels);

		Task<IRepositoryActionResult<FeaturedEvent>> Delete_FeaturedEventAsync(int featuredEventId);
		Task<FeaturedEvent> Get_FeaturedEventAsync(int featuredEventId, int numChildLevels);

		Task<IRepositoryActionResult<Feedback>> Delete_FeedbackAsync(System.Guid feedbackId);
		Task<Feedback> Get_FeedbackAsync(System.Guid feedbackId, int numChildLevels);

		Task<IRepositoryActionResult<FeedbackInitiatorType>> Delete_FeedbackInitiatorTypeAsync(int feedbackInitiatorTypeId);
		Task<FeedbackInitiatorType> Get_FeedbackInitiatorTypeAsync(int feedbackInitiatorTypeId, int numChildLevels);

		Task<IRepositoryActionResult<FeedbackType>> Delete_FeedbackTypeAsync(int feedbackTypeId);
		Task<FeedbackType> Get_FeedbackTypeAsync(int feedbackTypeId, int numChildLevels);

		Task<IRepositoryActionResult<GenderType>> Delete_GenderTypeAsync(int genderTypeId);
		Task<GenderType> Get_GenderTypeAsync(int genderTypeId, int numChildLevels);

		Task<IRepositoryActionResult<LanguageType>> Delete_LanguageTypeAsync(int languageTypeId);
		Task<LanguageType> Get_LanguageTypeAsync(int languageTypeId, int numChildLevels);

		Task<IRepositoryActionResult<Log>> Delete_LogAsync(int id);
		Task<Log> Get_LogAsync(int id, int numChildLevels);

		Task<IRepositoryActionResult<LogType>> Delete_LogTypeAsync(int id);
		Task<LogType> Get_LogTypeAsync(int id, int numChildLevels);

		Task<IRepositoryActionResult<LookupList>> Delete_LookupListAsync(int lookupListId);
		Task<LookupList> Get_LookupListAsync(int lookupListId, int numChildLevels);

		Task<IRepositoryActionResult<Room>> Delete_RoomAsync(int roomId);
		Task<Room> Get_RoomAsync(int roomId, int numChildLevels);

		Task<IRepositoryActionResult<Session>> Delete_SessionAsync(int sessionId);
		Task<Session> Get_SessionAsync(int sessionId, int numChildLevels);

		Task<IRepositoryActionResult<SessionCategoryType>> Delete_SessionCategoryTypeAsync(int sessionCategoryTypeId);
		Task<SessionCategoryType> Get_SessionCategoryTypeAsync(int sessionCategoryTypeId, int numChildLevels);

		Task<IRepositoryActionResult<SessionLike>> Delete_SessionLikeAsync(int sessionId, int userProfileId);
		Task<SessionLike> Get_SessionLikeAsync(int sessionId, int userProfileId, int numChildLevels);

		Task<IRepositoryActionResult<SessionSessionCategoryType>> Delete_SessionSessionCategoryTypeAsync(int sessionId, int sessionCategoryTypeId);
		Task<SessionSessionCategoryType> Get_SessionSessionCategoryTypeAsync(int sessionId, int sessionCategoryTypeId, int numChildLevels);

		Task<IRepositoryActionResult<SessionSpeaker>> Delete_SessionSpeakerAsync(int sessionId, int userProfileId);
		Task<SessionSpeaker> Get_SessionSpeakerAsync(int sessionId, int userProfileId, int numChildLevels);

		Task<IRepositoryActionResult<Sponsor>> Delete_SponsorAsync(int sponsorId);
		Task<Sponsor> Get_SponsorAsync(int sponsorId, int numChildLevels);

		Task<IRepositoryActionResult<SponsorFeaturedEvent>> Delete_SponsorFeaturedEventAsync(int sponsorId, int featuredEventId);
		Task<SponsorFeaturedEvent> Get_SponsorFeaturedEventAsync(int sponsorId, int featuredEventId, int numChildLevels);

		Task<IRepositoryActionResult<SponsorType>> Delete_SponsorTypeAsync(int sponsorTypeId);
		Task<SponsorType> Get_SponsorTypeAsync(int sponsorTypeId, int numChildLevels);

		Task<IRepositoryActionResult<UserProfile>> Delete_UserProfileAsync(int userProfileId);
		Task<UserProfile> Get_UserProfileAsync(int userProfileId, int numChildLevels);

	}
}
