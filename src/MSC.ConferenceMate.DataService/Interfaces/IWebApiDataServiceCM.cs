// <auto-generated> - Template:WebApiDataServiceInterface, Version:1.1, Id:1ea810ed-61a7-443b-97f2-da5b30311e75
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeGenHero.DataService;
using xDTO = MSC.ConferenceMate.DTO.CM;

namespace MSC.ConferenceMate.API.Client.Interface
{
	public partial interface IWebApiDataServiceCM : IWebApiDataServiceBase
	{
		#region GetAllPages

		Task<IList<xDTO.Announcement>> GetAllPagesAnnouncementsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.FeaturedEvent>> GetAllPagesFeaturedEventsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.Feedback>> GetAllPagesFeedbacksAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.FeedbackInitiatorType>> GetAllPagesFeedbackInitiatorTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.FeedbackType>> GetAllPagesFeedbackTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.GenderType>> GetAllPagesGenderTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.LanguageType>> GetAllPagesLanguageTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.Log>> GetAllPagesLogsAsync(string sort = null);

		Task<IList<xDTO.LogType>> GetAllPagesLogTypesAsync(string sort = null);

		Task<IList<xDTO.LookupList>> GetAllPagesLookupListsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.Room>> GetAllPagesRoomsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.Session>> GetAllPagesSessionsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SessionCategoryType>> GetAllPagesSessionCategoryTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SessionLike>> GetAllPagesSessionLikesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SessionSessionCategoryType>> GetAllPagesSessionSessionCategoryTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SessionSpeaker>> GetAllPagesSessionSpeakersAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.Sponsor>> GetAllPagesSponsorsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SponsorFeaturedEvent>> GetAllPagesSponsorFeaturedEventsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.SponsorType>> GetAllPagesSponsorTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);

		Task<IList<xDTO.UserProfile>> GetAllPagesUserProfilesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null);


		#endregion GetAllPages


		#region GetPageData

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Announcement>>>> GetAnnouncementsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Announcement>>>> GetAnnouncementsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeaturedEvent>>>> GetFeaturedEventsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeaturedEvent>>>> GetFeaturedEventsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Feedback>>>> GetFeedbacksAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Feedback>>>> GetFeedbacksAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeedbackInitiatorType>>>> GetFeedbackInitiatorTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeedbackInitiatorType>>>> GetFeedbackInitiatorTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeedbackType>>>> GetFeedbackTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.FeedbackType>>>> GetFeedbackTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.GenderType>>>> GetGenderTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.GenderType>>>> GetGenderTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LanguageType>>>> GetLanguageTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LanguageType>>>> GetLanguageTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Log>>>> GetLogsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Log>>>> GetLogsAsync(string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LogType>>>> GetLogTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LogType>>>> GetLogTypesAsync(string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LookupList>>>> GetLookupListsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.LookupList>>>> GetLookupListsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Room>>>> GetRoomsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Room>>>> GetRoomsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Session>>>> GetSessionsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Session>>>> GetSessionsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionCategoryType>>>> GetSessionCategoryTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionCategoryType>>>> GetSessionCategoryTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionLike>>>> GetSessionLikesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionLike>>>> GetSessionLikesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionSessionCategoryType>>>> GetSessionSessionCategoryTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionSessionCategoryType>>>> GetSessionSessionCategoryTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionSpeaker>>>> GetSessionSpeakersAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SessionSpeaker>>>> GetSessionSpeakersAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Sponsor>>>> GetSponsorsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.Sponsor>>>> GetSponsorsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SponsorFeaturedEvent>>>> GetSponsorFeaturedEventsAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SponsorFeaturedEvent>>>> GetSponsorFeaturedEventsAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SponsorType>>>> GetSponsorTypesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.SponsorType>>>> GetSponsorTypesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.UserProfile>>>> GetUserProfilesAsync(IPageDataRequest pageDataRequest);

		Task<IHttpCallResultCGHT<IPageDataT<IList<xDTO.UserProfile>>>> GetUserProfilesAsync(DateTime? minModifiedUtcDate = null, bool? isDeleted = null, string sort = null, int page = 1, int pageSize = 100);


		#endregion GetPageData


		#region Get By PK

		Task<IHttpCallResultCGHT<xDTO.Announcement>> GetAnnouncementAsync(int announcementId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.FeaturedEvent>> GetFeaturedEventAsync(int featuredEventId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.Feedback>> GetFeedbackAsync(System.Guid feedbackId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.FeedbackInitiatorType>> GetFeedbackInitiatorTypeAsync(int feedbackInitiatorTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.FeedbackType>> GetFeedbackTypeAsync(int feedbackTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.GenderType>> GetGenderTypeAsync(int genderTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.LanguageType>> GetLanguageTypeAsync(int languageTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.Log>> GetLogAsync(int id, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.LogType>> GetLogTypeAsync(int id, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.LookupList>> GetLookupListAsync(int lookupListId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.Room>> GetRoomAsync(int roomId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.Session>> GetSessionAsync(int sessionId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SessionCategoryType>> GetSessionCategoryTypeAsync(int sessionCategoryTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SessionLike>> GetSessionLikeAsync(int sessionId, int userProfileId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SessionSessionCategoryType>> GetSessionSessionCategoryTypeAsync(int sessionId, int sessionCategoryTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SessionSpeaker>> GetSessionSpeakerAsync(int sessionId, int userProfileId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.Sponsor>> GetSponsorAsync(int sponsorId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SponsorFeaturedEvent>> GetSponsorFeaturedEventAsync(int sponsorId, int featuredEventId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.SponsorType>> GetSponsorTypeAsync(int sponsorTypeId, int numChildLevels);

		Task<IHttpCallResultCGHT<xDTO.UserProfile>> GetUserProfileAsync(int userProfileId, int numChildLevels);


		#endregion Get By PK


		#region Create

		Task<IHttpCallResultCGHT<xDTO.Announcement>> CreateAnnouncementAsync(xDTO.Announcement item);

		Task<IHttpCallResultCGHT<xDTO.FeaturedEvent>> CreateFeaturedEventAsync(xDTO.FeaturedEvent item);

		Task<IHttpCallResultCGHT<xDTO.Feedback>> CreateFeedbackAsync(xDTO.Feedback item);

		Task<IHttpCallResultCGHT<xDTO.FeedbackInitiatorType>> CreateFeedbackInitiatorTypeAsync(xDTO.FeedbackInitiatorType item);

		Task<IHttpCallResultCGHT<xDTO.FeedbackType>> CreateFeedbackTypeAsync(xDTO.FeedbackType item);

		Task<IHttpCallResultCGHT<xDTO.GenderType>> CreateGenderTypeAsync(xDTO.GenderType item);

		Task<IHttpCallResultCGHT<xDTO.LanguageType>> CreateLanguageTypeAsync(xDTO.LanguageType item);

		Task<IHttpCallResultCGHT<xDTO.Log>> CreateLogAsync(xDTO.Log item);

		Task<IHttpCallResultCGHT<xDTO.LogType>> CreateLogTypeAsync(xDTO.LogType item);

		Task<IHttpCallResultCGHT<xDTO.LookupList>> CreateLookupListAsync(xDTO.LookupList item);

		Task<IHttpCallResultCGHT<xDTO.Room>> CreateRoomAsync(xDTO.Room item);

		Task<IHttpCallResultCGHT<xDTO.Session>> CreateSessionAsync(xDTO.Session item);

		Task<IHttpCallResultCGHT<xDTO.SessionCategoryType>> CreateSessionCategoryTypeAsync(xDTO.SessionCategoryType item);

		Task<IHttpCallResultCGHT<xDTO.SessionLike>> CreateSessionLikeAsync(xDTO.SessionLike item);

		Task<IHttpCallResultCGHT<xDTO.SessionSessionCategoryType>> CreateSessionSessionCategoryTypeAsync(xDTO.SessionSessionCategoryType item);

		Task<IHttpCallResultCGHT<xDTO.SessionSpeaker>> CreateSessionSpeakerAsync(xDTO.SessionSpeaker item);

		Task<IHttpCallResultCGHT<xDTO.Sponsor>> CreateSponsorAsync(xDTO.Sponsor item);

		Task<IHttpCallResultCGHT<xDTO.SponsorFeaturedEvent>> CreateSponsorFeaturedEventAsync(xDTO.SponsorFeaturedEvent item);

		Task<IHttpCallResultCGHT<xDTO.SponsorType>> CreateSponsorTypeAsync(xDTO.SponsorType item);

		Task<IHttpCallResultCGHT<xDTO.UserProfile>> CreateUserProfileAsync(xDTO.UserProfile item);


		#endregion Create


		#region Update

		Task<IHttpCallResultCGHT<xDTO.Announcement>> UpdateAnnouncementAsync(xDTO.Announcement item);

		Task<IHttpCallResultCGHT<xDTO.FeaturedEvent>> UpdateFeaturedEventAsync(xDTO.FeaturedEvent item);

		Task<IHttpCallResultCGHT<xDTO.Feedback>> UpdateFeedbackAsync(xDTO.Feedback item);

		Task<IHttpCallResultCGHT<xDTO.FeedbackInitiatorType>> UpdateFeedbackInitiatorTypeAsync(xDTO.FeedbackInitiatorType item);

		Task<IHttpCallResultCGHT<xDTO.FeedbackType>> UpdateFeedbackTypeAsync(xDTO.FeedbackType item);

		Task<IHttpCallResultCGHT<xDTO.GenderType>> UpdateGenderTypeAsync(xDTO.GenderType item);

		Task<IHttpCallResultCGHT<xDTO.LanguageType>> UpdateLanguageTypeAsync(xDTO.LanguageType item);

		Task<IHttpCallResultCGHT<xDTO.Log>> UpdateLogAsync(xDTO.Log item);

		Task<IHttpCallResultCGHT<xDTO.LogType>> UpdateLogTypeAsync(xDTO.LogType item);

		Task<IHttpCallResultCGHT<xDTO.LookupList>> UpdateLookupListAsync(xDTO.LookupList item);

		Task<IHttpCallResultCGHT<xDTO.Room>> UpdateRoomAsync(xDTO.Room item);

		Task<IHttpCallResultCGHT<xDTO.Session>> UpdateSessionAsync(xDTO.Session item);

		Task<IHttpCallResultCGHT<xDTO.SessionCategoryType>> UpdateSessionCategoryTypeAsync(xDTO.SessionCategoryType item);

		Task<IHttpCallResultCGHT<xDTO.SessionLike>> UpdateSessionLikeAsync(xDTO.SessionLike item);

		Task<IHttpCallResultCGHT<xDTO.SessionSessionCategoryType>> UpdateSessionSessionCategoryTypeAsync(xDTO.SessionSessionCategoryType item);

		Task<IHttpCallResultCGHT<xDTO.SessionSpeaker>> UpdateSessionSpeakerAsync(xDTO.SessionSpeaker item);

		Task<IHttpCallResultCGHT<xDTO.Sponsor>> UpdateSponsorAsync(xDTO.Sponsor item);

		Task<IHttpCallResultCGHT<xDTO.SponsorFeaturedEvent>> UpdateSponsorFeaturedEventAsync(xDTO.SponsorFeaturedEvent item);

		Task<IHttpCallResultCGHT<xDTO.SponsorType>> UpdateSponsorTypeAsync(xDTO.SponsorType item);

		Task<IHttpCallResultCGHT<xDTO.UserProfile>> UpdateUserProfileAsync(xDTO.UserProfile item);


		#endregion Update


		#region Delete

		Task<IHttpCallResultCGHT<xDTO.Announcement>> DeleteAnnouncementAsync(int announcementId);

		Task<IHttpCallResultCGHT<xDTO.FeaturedEvent>> DeleteFeaturedEventAsync(int featuredEventId);

		Task<IHttpCallResultCGHT<xDTO.Feedback>> DeleteFeedbackAsync(System.Guid feedbackId);

		Task<IHttpCallResultCGHT<xDTO.FeedbackInitiatorType>> DeleteFeedbackInitiatorTypeAsync(int feedbackInitiatorTypeId);

		Task<IHttpCallResultCGHT<xDTO.FeedbackType>> DeleteFeedbackTypeAsync(int feedbackTypeId);

		Task<IHttpCallResultCGHT<xDTO.GenderType>> DeleteGenderTypeAsync(int genderTypeId);

		Task<IHttpCallResultCGHT<xDTO.LanguageType>> DeleteLanguageTypeAsync(int languageTypeId);

		Task<IHttpCallResultCGHT<xDTO.Log>> DeleteLogAsync(int id);

		Task<IHttpCallResultCGHT<xDTO.LogType>> DeleteLogTypeAsync(int id);

		Task<IHttpCallResultCGHT<xDTO.LookupList>> DeleteLookupListAsync(int lookupListId);

		Task<IHttpCallResultCGHT<xDTO.Room>> DeleteRoomAsync(int roomId);

		Task<IHttpCallResultCGHT<xDTO.Session>> DeleteSessionAsync(int sessionId);

		Task<IHttpCallResultCGHT<xDTO.SessionCategoryType>> DeleteSessionCategoryTypeAsync(int sessionCategoryTypeId);

		Task<IHttpCallResultCGHT<xDTO.SessionLike>> DeleteSessionLikeAsync(int sessionId, int userProfileId);

		Task<IHttpCallResultCGHT<xDTO.SessionSessionCategoryType>> DeleteSessionSessionCategoryTypeAsync(int sessionId, int sessionCategoryTypeId);

		Task<IHttpCallResultCGHT<xDTO.SessionSpeaker>> DeleteSessionSpeakerAsync(int sessionId, int userProfileId);

		Task<IHttpCallResultCGHT<xDTO.Sponsor>> DeleteSponsorAsync(int sponsorId);

		Task<IHttpCallResultCGHT<xDTO.SponsorFeaturedEvent>> DeleteSponsorFeaturedEventAsync(int sponsorId, int featuredEventId);

		Task<IHttpCallResultCGHT<xDTO.SponsorType>> DeleteSponsorTypeAsync(int sponsorTypeId);

		Task<IHttpCallResultCGHT<xDTO.UserProfile>> DeleteUserProfileAsync(int userProfileId);


		#endregion Delete


	}
}
