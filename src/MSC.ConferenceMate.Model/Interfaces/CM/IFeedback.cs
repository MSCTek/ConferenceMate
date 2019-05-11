// <auto-generated> - Template:ModelsBackedByDtoInterface, Version:1.1, Id:4d03f2c7-de27-4aae-a267-cad747c9606a
using System;
using System.Collections.Generic;

namespace MSC.ConferenceMate.Model.CM.Interface
{
	public partial interface IFeedback
	{
		string CreatedBy { get; }
		System.DateTime CreatedUtcDate { get; }
		int DataVersion { get; }
		string Description { get; }
		bool Dispositioned { get; }
		int? FeaturedEventId { get; }
		System.Guid FeedbackId { get; }
		int FeedbackInitiatorTypeId { get; }
		int FeedbackTypeId { get; }
		bool? IsChat { get; }
		bool IsDeleted { get; }
		bool IsPublic { get; }
		double Latitude { get; }
		double Longitude { get; }
		string ModifiedBy { get; }
		System.DateTime ModifiedUtcDate { get; }
		string RatingValue { get; }
		int? SessionId { get; }
		string Source { get; }
		string Title { get; }
		int? UserId { get; }

		IFeaturedEvent FeaturedEvent { get; }
		IFeedbackInitiatorType FeedbackInitiatorType { get; }
		IFeedbackType FeedbackType { get; }
		ISession Session { get; }
		IUser User { get; }


	}
}
