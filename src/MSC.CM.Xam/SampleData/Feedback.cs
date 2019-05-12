// <auto-generated> - Template:XamSample, Version:1.1, Id:9131a0a2-7ceb-4f4c-b8a9-6740ac19f66c
using System;

namespace MSC.CM.Xam.ModelData.CM
{
	public static class DemoFeedback
	{
		public static System.Guid SampleFeedbackId0000 = Guid.Parse("f427ac34-92b9-4f7f-a1e9-07dc4cab8a99");
		public static System.Guid SampleFeedbackId0100 = Guid.Parse("fbbcb3d1-123d-4ce1-acae-bbc2db465415");

		public static Feedback SampleFeedback00
		{
			get
			{
				return new Feedback()
				{
					FeedbackId = SampleFeedbackId0000,
					Title = "SampleTitle",
					Description = "SampleDescription",
					FeedbackTypeId = 0,
					FeedbackInitiatorTypeId = 0,
					Source = "SampleSource",
					RatingValue = "SampleRatingValue",
					Latitude = 0,
					Longitude = 0,
					Dispositioned = false,
					UserId = 0,
					SessionId = 0,
					FeaturedEventId = 0,
					IsPublic = false,
					IsChat = false,
					DataVersion = 0,
					CreatedUtcDate = DateTime.Now,
					CreatedBy = "SampleCreatedBy",
					ModifiedUtcDate = DateTime.Now,
					ModifiedBy = "SampleModifiedBy",
					IsDeleted = false,
				};
			}
		}
		public static Feedback SampleFeedback01
		{
			get
			{
				return new Feedback()
				{
					FeedbackId = SampleFeedbackId0100,
					Title = "SampleTitle",
					Description = "SampleDescription",
					FeedbackTypeId = 0,
					FeedbackInitiatorTypeId = 0,
					Source = "SampleSource",
					RatingValue = "SampleRatingValue",
					Latitude = 0,
					Longitude = 0,
					Dispositioned = false,
					UserId = 0,
					SessionId = 0,
					FeaturedEventId = 0,
					IsPublic = false,
					IsChat = false,
					DataVersion = 0,
					CreatedUtcDate = DateTime.Now,
					CreatedBy = "SampleCreatedBy",
					ModifiedUtcDate = DateTime.Now,
					ModifiedBy = "SampleModifiedBy",
					IsDeleted = false,
				};
			}
		}

	}
}