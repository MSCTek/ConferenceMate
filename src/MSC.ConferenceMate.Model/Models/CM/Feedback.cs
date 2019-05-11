// <auto-generated> - Template:ModelsBackedByDto, Version:1.1, Id:f1539c0d-024f-4b1f-b346-132cdd9dd31f
using CodeGenHero.Logging;
using CodeGenHero.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using MSC.ConferenceMate.API.Client.Interface;
using MSC.ConferenceMate.Model.CM.Interface;
using xDTO = MSC.ConferenceMate.DTO.CM;

namespace MSC.ConferenceMate.Model.CM
{

	public class LoadRequestFeedback : EventArgs
	{
		public LoadRequestFeedback(string propertyNameRequestingLoad)
		{
			PropertyNameRequestingLoad = propertyNameRequestingLoad;
		}

		public string PropertyNameRequestingLoad { get; set; }
	}


	public partial class Feedback : BaseModel<IWebApiDataServiceCM>, IFeedback
	{
		public event EventHandler<LoadRequestFeedback> OnLazyLoadRequest = delegate { }; // Empty delegate. Thus we are sure that value is always != null because no one outside of the class can change it.
		private xDTO.Feedback _dto = null;

		public Feedback(ILoggingService log, IDataService<IWebApiDataServiceCM> dataService) : base(log, dataService)
		{
			_dto = new xDTO.Feedback();
			OnLazyLoadRequest += HandleLazyLoadRequest;
		}

		public Feedback(ILoggingService log, IDataService<IWebApiDataServiceCM> dataService, xDTO.Feedback dto) : this(log, dataService)
		{
			_dto = dto;
		}


		public virtual string CreatedBy { get { return _dto.CreatedBy; } }
		public virtual System.DateTime CreatedUtcDate { get { return _dto.CreatedUtcDate; } }
		public virtual int DataVersion { get { return _dto.DataVersion; } }
		public virtual string Description { get { return _dto.Description; } }
		public virtual bool Dispositioned { get { return _dto.Dispositioned; } }
		public virtual int? FeaturedEventId { get { return _dto.FeaturedEventId; } }
		public virtual System.Guid FeedbackId { get { return _dto.FeedbackId; } }
		public virtual int FeedbackInitiatorTypeId { get { return _dto.FeedbackInitiatorTypeId; } }
		public virtual int FeedbackTypeId { get { return _dto.FeedbackTypeId; } }
		public virtual bool? IsChat { get { return _dto.IsChat; } }
		public virtual bool IsDeleted { get { return _dto.IsDeleted; } }
		public virtual bool IsPublic { get { return _dto.IsPublic; } }
		public virtual double Latitude { get { return _dto.Latitude; } }
		public virtual double Longitude { get { return _dto.Longitude; } }
		public virtual string ModifiedBy { get { return _dto.ModifiedBy; } }
		public virtual System.DateTime ModifiedUtcDate { get { return _dto.ModifiedUtcDate; } }
		public virtual string RatingValue { get { return _dto.RatingValue; } }
		public virtual int? SessionId { get { return _dto.SessionId; } }
		public virtual string Source { get { return _dto.Source; } }
		public virtual string Title { get { return _dto.Title; } }
		public virtual int? UserId { get { return _dto.UserId; } }

		private IFeaturedEvent _featuredEvent = null; // Foreign Key
		private IFeedbackInitiatorType _feedbackInitiatorType = null; // Foreign Key
		private IFeedbackType _feedbackType = null; // Foreign Key
		private ISession _session = null; // Foreign Key
		private IUser _user = null; // Foreign Key


		public virtual IFeaturedEvent FeaturedEvent
		{
			get
			{
				if (_featuredEvent == null)
				{
					OnLazyLoadRequest(this, new LoadRequestFeedback(nameof(FeaturedEvent)));
				}

				return _featuredEvent;
			}
		}

		public virtual IFeedbackInitiatorType FeedbackInitiatorType
		{
			get
			{
				if (_feedbackInitiatorType == null && _dto != null && _dto.FeedbackInitiatorType != null)
				{
					_feedbackInitiatorType = new FeedbackInitiatorType(Log, DataService, _dto.FeedbackInitiatorType);
				}

				return _feedbackInitiatorType;
			}
		}

		public virtual IFeedbackType FeedbackType
		{
			get
			{
				if (_feedbackType == null && _dto != null && _dto.FeedbackType != null)
				{
					_feedbackType = new FeedbackType(Log, DataService, _dto.FeedbackType);
				}

				return _feedbackType;
			}
		}

		public virtual ISession Session
		{
			get
			{
				if (_session == null)
				{
					OnLazyLoadRequest(this, new LoadRequestFeedback(nameof(Session)));
				}

				return _session;
			}
		}

		public virtual IUser User
		{
			get
			{
				if (_user == null && _dto != null && _dto.User != null)
				{
					_user = new User(Log, DataService, _dto.User);
				}

				return _user;
			}
		}



	}
}
