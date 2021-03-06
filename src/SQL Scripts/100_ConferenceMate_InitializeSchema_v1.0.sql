USE [ConferenceMate]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 5/11/2019 4:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[AnnouncementId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ShortTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[AnnouncementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeaturedEvent]    Script Date: 5/11/2019 4:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeaturedEvent](
	[FeaturedEventId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ShortTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[Location] [nvarchar](1000) NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[IsAllDay] [bit] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_FeaturedEvent] PRIMARY KEY CLUSTERED 
(
	[FeaturedEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/11/2019 4:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](1024) NULL,
	[Description] [nvarchar](2048) NULL,
	[FeedbackTypeId] [int] NOT NULL,
	[FeedbackInitiatorTypeId] [int] NOT NULL,
	[Source] [varchar](50) NOT NULL,
	[RatingValue] [varchar](50) NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Dispositioned] [bit] NOT NULL,
	[UserId] [int] NULL,
	[SessionId] [int] NULL,
	[FeaturedEventId] [int] NULL,
	[IsPublic] [bit] NOT NULL,
	[IsChat] [bit] NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackInitiatorType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackInitiatorType](
	[FeedbackInitiatorTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_FeedbackInitiatorType] PRIMARY KEY CLUSTERED 
(
	[FeedbackInitiatorTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackType](
	[FeedbackTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_FeedbackType] PRIMARY KEY CLUSTERED 
(
	[FeedbackTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GenderType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GenderType](
	[GenderTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_GenderType] PRIMARY KEY CLUSTERED 
(
	[GenderTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanguageType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanguageType](
	[LanguageTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DisplayText] [nvarchar](128) NOT NULL,
	[DisplayPriority] [int] NOT NULL,
	[NativeName] [nvarchar](100) NOT NULL,
	[ThreeLetterISOLanguageName] [nchar](3) NOT NULL,
	[TwoLetterISOLanguageName] [nchar](2) NOT NULL,
	[LanguageCultureIdentifier] [int] NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LanguageType] PRIMARY KEY CLUSTERED 
(
	[LanguageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupList]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupList](
	[LookupListId] [int] IDENTITY(1,1) NOT NULL,
	[LanguageTypeId] [int] NOT NULL,
	[ForeignKeyTablePkId] [int] NOT NULL,
	[ForeignKeyTableName] [nvarchar](200) NOT NULL,
	[DisplayPriority] [int] NOT NULL,
	[DisplayText] [nvarchar](4000) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[CustomJson] [nvarchar](max) NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_LookupList] PRIMARY KEY CLUSTERED 
(
	[LookupListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ShortTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[SeatingCapacity] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[SessionId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ShortTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[RoomId] [int] NULL,
	[StartTime] [datetime2](7) NULL,
	[EndTime] [datetime2](7) NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session_Like]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session_Like](
	[SessionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Session_Like] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session_SessionCategoryType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session_SessionCategoryType](
	[SessionId] [int] NOT NULL,
	[SessionCategoryTypeId] [int] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Session_SessionCategoryType] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC,
	[SessionCategoryTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session_Speaker]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session_Speaker](
	[SessionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Session_Users] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionCategoryType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionCategoryType](
	[SessionCategoryTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SessionCategoryType] PRIMARY KEY CLUSTERED 
(
	[SessionCategoryTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsor]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsor](
	[SponsorId] [int] IDENTITY(1,1) NOT NULL,
	[SponsorTypeId] [int] NOT NULL,
	[Title] [nvarchar](1000) NOT NULL,
	[ShortTitle] [nvarchar](500) NULL,
	[Description] [nvarchar](4000) NULL,
	[ImageUrl] [nvarchar](1000) NULL,
	[WebsiteUrl] [nvarchar](1000) NULL,
	[TwitterUrl] [nvarchar](1000) NULL,
	[BoothLocation] [nvarchar](1000) NULL,
	[Rank] [int] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Sponsor] PRIMARY KEY CLUSTERED 
(
	[SponsorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sponsor_FeaturedEvent]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sponsor_FeaturedEvent](
	[SponsorId] [int] NOT NULL,
	[FeaturedEventId] [int] NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Sponsor_FeaturedEvent] PRIMARY KEY CLUSTERED 
(
	[SponsorId] ASC,
	[FeaturedEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SponsorType]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SponsorType](
	[SponsorTypeId] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_SponsorType] PRIMARY KEY CLUSTERED 
(
	[SponsorTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[BirthDate] [datetime2](7) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[GenderTypeId] [int] NOT NULL,
	[Password] [nvarchar](255) NULL,
	[Salt] [nvarchar](255) NULL,
	[LastLogin] [datetime2](7) NOT NULL,
	[PreferredLanguageId] [int] NOT NULL,
	[Biography] [nvarchar](4000) NULL,
	[PhotoUrl] [nvarchar](1000) NULL,
	[AvatarUrl] [nvarchar](1000) NULL,
	[CompanyName] [nvarchar](1000) NULL,
	[JobTitle] [nvarchar](1000) NULL,
	[CompanyWebsiteUrl] [nvarchar](1000) NULL,
	[BlogUrl] [nvarchar](1000) NULL,
	[TwitterUrl] [nvarchar](1000) NULL,
	[LinkedInUrl] [nvarchar](1000) NULL,
	[DataVersion] [int] NOT NULL,
	[CreatedUtcDate] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](200) NOT NULL,
	[ModifiedUtcDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](200) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FeedbackInitiatorType] ([FeedbackInitiatorTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1, N'ATTENDEE', 1, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackInitiatorType] ([FeedbackInitiatorTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2, N'CONFERENCE_ORGANIZER', 1, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackInitiatorType] ([FeedbackInitiatorTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (4, N'SPEAKER', 1, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1, N'SPEAKER', 3, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2, N'SESSION', 4, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (4, N'VENUE', 4, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (8, N'EVENT', 5, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (16, N'GENERAL', 4, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (32, N'LOGISTICS', 4, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (64, N'ATTENDEE', 4, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[FeedbackType] ([FeedbackTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (128, N'VENDOR_SPONSOR', 5, CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1, N'MALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2, N'FEMALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (4, N'AGENDER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (8, N'ANDROGYNE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (16, N'ANDROGYNOUS', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (32, N'BIGENDER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (64, N'CISGENDER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (128, N'FEMALE_TO_MALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (256, N'GENDER_FLUID', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (512, N'GENDER_NONCONFORMING', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1024, N'GENDER_QUESTIONING', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2048, N'GENDER_QUEER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (4096, N'INTERSEX', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (8192, N'MALE_TO_FEMALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (16384, N'NEITHER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (32768, N'NEUTROIS', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (65536, N'OTHER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (131072, N'PANGENDER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (262144, N'TRANS', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (524288, N'TRANS*', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1048576, N'TRANS_FEMALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2097152, N'TRANS_MALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (4194304, N'TRANS_PERSON', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (8388608, N'TRANSGENDER', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (16777216, N'TRANSMASCULINE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (33554432, N'TRANSSEXUAL', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (67108864, N'TRANSSEXUAL_FEMALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (134217728, N'TRANSSEXUAL_MALE', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[GenderType] ([GenderTypeId], [Code], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (268435456, N'TWO_SPIRIT', 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LanguageType] ([LanguageTypeId], [Code], [DisplayText], [DisplayPriority], [NativeName], [ThreeLetterISOLanguageName], [TwoLetterISOLanguageName], [LanguageCultureIdentifier], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1, N'en-US', N'English (United States)', 100, N'English (United States)', N'eng', N'en', 1033, 1, CAST(N'2019-02-21T04:37:59.4133333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:37:59.4133333' AS DateTime2), N'INITIAL LOAD', 0)
SET IDENTITY_INSERT [dbo].[LookupList] ON 

INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (5, 1, 1, N'FeedbackInitiatorType', 100, N'Attendee', NULL, NULL, 1, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (6, 1, 2, N'FeedbackInitiatorType', 100, N'Conference Organizer', NULL, NULL, 2, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (7, 1, 4, N'FeedbackInitiatorType', 100, N'Speaker', NULL, NULL, 1, CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-04T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (8, 1, 1, N'FeedbackType', 100, N'Speaker', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (9, 1, 2, N'FeedbackType', 100, N'Session', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (10, 1, 4, N'FeedbackType', 100, N'Venue', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (11, 1, 8, N'FeedbackType', 90, N'Event', NULL, NULL, 2, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (12, 1, 16, N'FeedbackType', 100, N'General', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (13, 1, 32, N'FeedbackType', 100, N'Logistics', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (14, 1, 64, N'FeedbackType', 100, N'Attendee', NULL, NULL, 1, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (15, 1, 128, N'FeedbackType', 100, N'Vendor Sponsor', NULL, NULL, 2, CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:03.8633333' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (23, 1, 1, N'GenderType', 2, N'Male', N'A male with a male gender identity.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (24, 1, 2, N'GenderType', 1, N'Female', N'A female with a female gender identity.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (25, 1, 4, N'GenderType', 100, N'Agender', N'People who lack a gender. Agender people may be of any physical sex, whether DFAB or DMAB (Female-bodied or Male-bodied), someone can still identify as Agender. Gender does not have anything to do with bodies. Think of it as SEX = BODY, GENDER = MINDSET.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (26, 1, 8, N'GenderType', 100, N'Androgyne', N'The combination of masculine and feminine characteristics. It can also refer to biological intersex physicality, especially with regard to plant and human sexuality.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (27, 1, 16, N'GenderType', 100, N'Androgynous', N'An androgynous person is a female or male who has a high degree of both feminine (expressive) and masculine (instrumental) traits. (same as the above definition)', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (28, 1, 32, N'GenderType', 100, N'Bigender', N'A person who feels they exhibit two genders. The two genders may include any particular gender on or outside of the gender spectrum.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (29, 1, 64, N'GenderType', 100, N'Cisgender', N'Related types of gender identity where an individual''s experience of their own gender matches the sex they were assigned at birth.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (30, 1, 128, N'GenderType', 100, N'Female to Male', N'A transgender man, assigned female at birth, but identifies as male.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (31, 1, 256, N'GenderType', 100, N'Gender Fluid', N'A gender identity best described as a dynamic mix of boy and girl. A person who is Gender Fluid may always feel like a mix of the two traditional genders, but may feel more boy some days, and more girl other days.
Being Gender Fluid has nothing to do with which set of genitalia one has, nor their sexual orientation.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (32, 1, 512, N'GenderType', 100, N'Gender Nonconforming', N'Behaviour or gender expression that does not conform to dominant gender norms of male and female. People who exhibit gender variance may be called gender variant, gender non-conforming, or gender atypical.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (33, 1, 1024, N'GenderType', 100, N'Gender Questioning', N'In the process of exploration by people who may be unsure, still exploring, and concerned about applying a social label to themselves for various reasons.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (34, 1, 2048, N'GenderType', 100, N'Gender Queer', N'Catch-all category for gender identities other than man and woman, thus outside of the gender binary and cisnormativity.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (35, 1, 4096, N'GenderType', 100, N'Intersex', N'A variation in sex characteristics including chromosomes, gonads, or genitals that do not allow an individual to be distinctly identified as male or female.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (36, 1, 8192, N'GenderType', 100, N'Male to Female', N'A transgender woman, assigned male at birth, but identifies as female.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (37, 1, 16384, N'GenderType', 100, N'Neither', N'No definition; assume the person does not want to be identified as Male or Female.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (38, 1, 32768, N'GenderType', 100, N'Neutrois', N'an identity used by individuals who feel they fall outside the gender binary. Many feel Neutrois is a gender, like a third gender while others feel agendered. What they have in common is that they wish to minimize their birth gender markers.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (39, 1, 65536, N'GenderType', 100, N'Other', N'No definition; something other than the options available.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (40, 1, 131072, N'GenderType', 100, N'Pangender', N'People who do not wish to be labeled as female or male in gender, as they feel that they do not fit into binary genders because they feel they are all genders. The term has a great deal of overlap with genderqueer and is used by those in the LGBTcommunity meaning "all genders."', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (41, 1, 262144, N'GenderType', 100, N'Trans', N'Encompassing a range of transgender identities.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (42, 1, 524288, N'GenderType', 100, N'Trans*', N'Umbrella term that refers to all of the identities within the gender identity spectrum. The asterisk makes special note in an effort to include all non-cisgender gender identities, including transgender, transsexual, transvestite, genderqueer, genderfluid, non-binary, genderfuck, genderless, agender, non-gendered, third gender, two-spirit, bigender, and trans man and trans woman. The origin behind the asterisk is a bit computer geeky.  When you add an asterisk to the end of a search term, you’re telling your computer to search for whatever you typed, plus any characters after (e.g., [search term*][extra letters], or trans*[-gender, -queer, -sexual, etc.]).  The idea was to include trans and other identities related to trans, in the most technical way.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (43, 1, 1048576, N'GenderType', 100, N'Trans Female', N'Transgender person with a female gender identity.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (44, 1, 2097152, N'GenderType', 100, N'Trans Male', N'Transgender person with a male gender identity.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (45, 1, 4194304, N'GenderType', 100, N'Trans Person', N'The state of one''s gender identity or gender expression not matching one''s assigned sex. Transgender is independent of sexual orientation; transgender people may identify as heterosexual, homosexual, bisexual, pansexual, polysexual, or asexual; some may consider conventional sexual orientation labels inadequate or inapplicable to them.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (46, 1, 8388608, N'GenderType', 100, N'Transgender', N'The state of one''s gender identity or gender expression not matching one''s assigned sex. Transgender is independent of sexual orientation; transgender people may identify as heterosexual, homosexual, bisexual, pansexual, polysexual, or asexual; some may consider conventional sexual orientation labels inadequate or inapplicable to them.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (47, 1, 16777216, N'GenderType', 100, N'Transmasculine', N'Those who were assigned female at birth, but identify as more male than female.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (48, 1, 33554432, N'GenderType', 100, N'Transsexual', N'Identifies with a gender inconsistent or not culturally associated with their assigned sex, i.e. in which a person''s assigned sex at birth conflicts with their psychological gender.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (49, 1, 67108864, N'GenderType', 100, N'Transsexual Female', N'Born a male who identifies as a female. Could have gender reassignment surgery to become a female.', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (50, 1, 134217728, N'GenderType', 100, N'Transsexual Male', N'Born a female who identifies as a male. Could have gender reassignment surgery to become a male', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[LookupList] ([LookupListId], [LanguageTypeId], [ForeignKeyTablePkId], [ForeignKeyTableName], [DisplayPriority], [DisplayText], [Description], [CustomJson], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (51, 1, 268435456, N'GenderType', 100, N'Two-Spirit', N'Umbrella term sometimes used for what was once commonly known as berdaches, indigenous North Americans who fulfill one of many mixed gender roles in First Nations and Native American tribes. Third gender roles historically embodied by two-spirit people include performing work and wearing clothing associated with both men and women. The presence of male two-spirits "was a fundamental institution among most tribal peoples."', NULL, 1, CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-02-21T04:38:23.1566667' AS DateTime2), N'INITIAL LOAD', 0)
SET IDENTITY_INSERT [dbo].[LookupList] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Email], [BirthDate], [FirstName], [LastName], [GenderTypeId], [Password], [Salt], [LastLogin], [PreferredLanguageId], [Biography], [PhotoUrl], [AvatarUrl], [CompanyName], [JobTitle], [CompanyWebsiteUrl], [BlogUrl], [TwitterUrl], [LinkedInUrl], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (1, N'Owen@example.com', N'Owen@example.com', CAST(N'1999-01-01T00:00:00.0000000' AS DateTime2), N'Owen', N'Organizer', 1, N'password', N'-1', CAST(N'2019-04-02T02:07:59.1200000' AS DateTime2), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2019-04-02T02:07:59.1200000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-04-02T02:07:59.1200000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [BirthDate], [FirstName], [LastName], [GenderTypeId], [Password], [Salt], [LastLogin], [PreferredLanguageId], [Biography], [PhotoUrl], [AvatarUrl], [CompanyName], [JobTitle], [CompanyWebsiteUrl], [BlogUrl], [TwitterUrl], [LinkedInUrl], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (2, N'Andy@example.com', N'Andy@example.com', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'Andy', N'Attendee', 1, N'', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [BirthDate], [FirstName], [LastName], [GenderTypeId], [Password], [Salt], [LastLogin], [PreferredLanguageId], [Biography], [PhotoUrl], [AvatarUrl], [CompanyName], [JobTitle], [CompanyWebsiteUrl], [BlogUrl], [TwitterUrl], [LinkedInUrl], [DataVersion], [CreatedUtcDate], [CreatedBy], [ModifiedUtcDate], [ModifiedBy], [IsDeleted]) VALUES (3, N'Sally@example.com', N'Sally@example.com', NULL, N'Jenny', N'Speaker', 2, N'', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'INITIAL LOAD', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_LanguageType_Code]    Script Date: 5/11/2019 4:03:57 PM ******/
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [UC_LanguageType_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Announcement] ADD  CONSTRAINT [DF_Announcement_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Announcement] ADD  CONSTRAINT [DF_Announcement_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Announcement] ADD  CONSTRAINT [DF_Announcement_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Announcement] ADD  CONSTRAINT [DF_Announcement_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FeaturedEvent] ADD  CONSTRAINT [DF_FeaturedEvent_IsAllDay]  DEFAULT ((0)) FOR [IsAllDay]
GO
ALTER TABLE [dbo].[FeaturedEvent] ADD  CONSTRAINT [DF_FeaturedEvent_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[FeaturedEvent] ADD  CONSTRAINT [DF_FeaturedEvent_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[FeaturedEvent] ADD  CONSTRAINT [DF_FeaturedEvent_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[FeaturedEvent] ADD  CONSTRAINT [DF_FeaturedEvent_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_IsPublic]  DEFAULT ((0)) FOR [IsPublic]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_IsChat]  DEFAULT ((0)) FOR [IsChat]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  CONSTRAINT [DF_Feedback_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FeedbackInitiatorType] ADD  CONSTRAINT [DF_FeedbackInitiatorType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[FeedbackInitiatorType] ADD  CONSTRAINT [DF_FeedbackInitiatorType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[FeedbackInitiatorType] ADD  CONSTRAINT [DF_FeedbackInitiatorType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[FeedbackInitiatorType] ADD  CONSTRAINT [DF_FeedbackInitiatorType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[FeedbackType] ADD  CONSTRAINT [DF_FeedbackType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[FeedbackType] ADD  CONSTRAINT [DF_FeedbackType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[FeedbackType] ADD  CONSTRAINT [DF_FeedbackType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[FeedbackType] ADD  CONSTRAINT [DF_FeedbackType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[GenderType] ADD  CONSTRAINT [DF_GenderType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[GenderType] ADD  CONSTRAINT [DF_GenderType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[GenderType] ADD  CONSTRAINT [DF_GenderType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[GenderType] ADD  CONSTRAINT [DF_GenderType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [DF_LanguageType_DisplayPriority]  DEFAULT ((100)) FOR [DisplayPriority]
GO
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [DF_LanguageType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [DF_LanguageType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [DF_LanguageType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[LanguageType] ADD  CONSTRAINT [DF_LanguageType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LookupList] ADD  CONSTRAINT [DF_LookupList_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[LookupList] ADD  CONSTRAINT [DF_LookupList_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[LookupList] ADD  CONSTRAINT [DF_LookupList_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[LookupList] ADD  CONSTRAINT [DF_LookupList_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [DF_Session_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [DF_Session_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [DF_Session_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Session] ADD  CONSTRAINT [DF_Session_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Session_Like] ADD  CONSTRAINT [DF_Session_Like_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Session_Like] ADD  CONSTRAINT [DF_Session_Like_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Session_Like] ADD  CONSTRAINT [DF_Session_Like_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Session_Like] ADD  CONSTRAINT [DF_Session_Like_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] ADD  CONSTRAINT [DF_Session_SessionCategoryType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] ADD  CONSTRAINT [DF_Session_SessionCategoryType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] ADD  CONSTRAINT [DF_Session_SessionCategoryType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] ADD  CONSTRAINT [DF_Session_SessionCategoryType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Session_Speaker] ADD  CONSTRAINT [DF_Session_Speaker_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Session_Speaker] ADD  CONSTRAINT [DF_Session_Speaker_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Session_Speaker] ADD  CONSTRAINT [DF_Session_Speaker_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Session_Speaker] ADD  CONSTRAINT [DF_Session_Speaker_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SessionCategoryType] ADD  CONSTRAINT [DF_SessionCategoryType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[SessionCategoryType] ADD  CONSTRAINT [DF_SessionCategoryType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[SessionCategoryType] ADD  CONSTRAINT [DF_SessionCategoryType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[SessionCategoryType] ADD  CONSTRAINT [DF_SessionCategoryType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Sponsor] ADD  CONSTRAINT [DF_Sponsor_Rank]  DEFAULT ((100)) FOR [Rank]
GO
ALTER TABLE [dbo].[Sponsor] ADD  CONSTRAINT [DF_Sponsor_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Sponsor] ADD  CONSTRAINT [DF_Sponsor_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Sponsor] ADD  CONSTRAINT [DF_Sponsor_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Sponsor] ADD  CONSTRAINT [DF_Sponsor_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] ADD  CONSTRAINT [DF_Sponsor_FeaturedEvent_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] ADD  CONSTRAINT [DF_Sponsor_FeaturedEvent_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] ADD  CONSTRAINT [DF_Sponsor_FeaturedEvent_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] ADD  CONSTRAINT [DF_Sponsor_FeaturedEvent_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[SponsorType] ADD  CONSTRAINT [DF_SponsorType_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[SponsorType] ADD  CONSTRAINT [DF_SponsorType_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[SponsorType] ADD  CONSTRAINT [DF_SponsorType_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[SponsorType] ADD  CONSTRAINT [DF_SponsorType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_PreferredLanguageId]  DEFAULT ((1)) FOR [PreferredLanguageId]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DataVersion]  DEFAULT ((1)) FOR [DataVersion]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedUtcDate]  DEFAULT (getutcdate()) FOR [CreatedUtcDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_ModifiedUtcDate]  DEFAULT (getutcdate()) FOR [ModifiedUtcDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_FeaturedEvent] FOREIGN KEY([FeaturedEventId])
REFERENCES [dbo].[FeaturedEvent] ([FeaturedEventId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_FeaturedEvent]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_FeedbackInitiatorType] FOREIGN KEY([FeedbackInitiatorTypeId])
REFERENCES [dbo].[FeedbackInitiatorType] ([FeedbackInitiatorTypeId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_FeedbackInitiatorType]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_FeedbackType] FOREIGN KEY([FeedbackTypeId])
REFERENCES [dbo].[FeedbackType] ([FeedbackTypeId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_FeedbackType]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([SessionId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Session]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Users]
GO
ALTER TABLE [dbo].[LookupList]  WITH CHECK ADD  CONSTRAINT [FK_LookupList_LanguageType] FOREIGN KEY([LanguageTypeId])
REFERENCES [dbo].[LanguageType] ([LanguageTypeId])
GO
ALTER TABLE [dbo].[LookupList] CHECK CONSTRAINT [FK_LookupList_LanguageType]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Room]
GO
ALTER TABLE [dbo].[Session_Like]  WITH CHECK ADD  CONSTRAINT [FK_Session_Like_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([SessionId])
GO
ALTER TABLE [dbo].[Session_Like] CHECK CONSTRAINT [FK_Session_Like_Session]
GO
ALTER TABLE [dbo].[Session_Like]  WITH CHECK ADD  CONSTRAINT [FK_Session_Like_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Session_Like] CHECK CONSTRAINT [FK_Session_Like_Users]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType]  WITH CHECK ADD  CONSTRAINT [FK_Session_SessionCategoryType_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([SessionId])
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] CHECK CONSTRAINT [FK_Session_SessionCategoryType_Session]
GO
ALTER TABLE [dbo].[Session_SessionCategoryType]  WITH CHECK ADD  CONSTRAINT [FK_Session_SessionCategoryType_SessionCategoryType] FOREIGN KEY([SessionCategoryTypeId])
REFERENCES [dbo].[SessionCategoryType] ([SessionCategoryTypeId])
GO
ALTER TABLE [dbo].[Session_SessionCategoryType] CHECK CONSTRAINT [FK_Session_SessionCategoryType_SessionCategoryType]
GO
ALTER TABLE [dbo].[Session_Speaker]  WITH CHECK ADD  CONSTRAINT [FK_Session_Speaker_Session] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Session] ([SessionId])
GO
ALTER TABLE [dbo].[Session_Speaker] CHECK CONSTRAINT [FK_Session_Speaker_Session]
GO
ALTER TABLE [dbo].[Session_Speaker]  WITH CHECK ADD  CONSTRAINT [FK_Session_Speaker_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Session_Speaker] CHECK CONSTRAINT [FK_Session_Speaker_Users]
GO
ALTER TABLE [dbo].[Sponsor]  WITH CHECK ADD  CONSTRAINT [FK_Sponsor_SponsorType] FOREIGN KEY([SponsorTypeId])
REFERENCES [dbo].[SponsorType] ([SponsorTypeId])
GO
ALTER TABLE [dbo].[Sponsor] CHECK CONSTRAINT [FK_Sponsor_SponsorType]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent]  WITH CHECK ADD  CONSTRAINT [FK_Sponsor_FeaturedEvent_FeaturedEvent] FOREIGN KEY([FeaturedEventId])
REFERENCES [dbo].[FeaturedEvent] ([FeaturedEventId])
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] CHECK CONSTRAINT [FK_Sponsor_FeaturedEvent_FeaturedEvent]
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent]  WITH CHECK ADD  CONSTRAINT [FK_Sponsor_FeaturedEvent_Sponsor] FOREIGN KEY([SponsorId])
REFERENCES [dbo].[Sponsor] ([SponsorId])
GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] CHECK CONSTRAINT [FK_Sponsor_FeaturedEvent_Sponsor]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_GenderType_GenderTypeId] FOREIGN KEY([GenderTypeId])
REFERENCES [dbo].[GenderType] ([GenderTypeId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_GenderType_GenderTypeId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_LanguageType] FOREIGN KEY([PreferredLanguageId])
REFERENCES [dbo].[LanguageType] ([LanguageTypeId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_LanguageType]
GO
/****** Object:  Trigger [dbo].[trg_Announcement_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_Announcement_Update] ON [dbo].[Announcement]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Announcement a
        INNER JOIN inserted b
          ON a.AnnouncementId = b.AnnouncementId
GO
ALTER TABLE [dbo].[Announcement] ENABLE TRIGGER [trg_Announcement_Update]
GO
/****** Object:  Trigger [dbo].[trg_FeaturedEvent_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







      CREATE TRIGGER [dbo].[trg_FeaturedEvent_Update] ON [dbo].[FeaturedEvent]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM FeaturedEvent a
        INNER JOIN inserted b
          ON a.FeaturedEventId = b.FeaturedEventId


GO
ALTER TABLE [dbo].[FeaturedEvent] ENABLE TRIGGER [trg_FeaturedEvent_Update]
GO
/****** Object:  Trigger [dbo].[trg_Feedback_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Feedback_Update] ON [dbo].[Feedback]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Feedback a
        INNER JOIN inserted b
          ON a.FeedbackId = b.FeedbackId
GO
ALTER TABLE [dbo].[Feedback] ENABLE TRIGGER [trg_Feedback_Update]
GO
/****** Object:  Trigger [dbo].[trg_FeedbackInitiatorType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





      CREATE TRIGGER [dbo].[trg_FeedbackInitiatorType_Update] ON [dbo].[FeedbackInitiatorType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM FeedbackInitiatorType a
        INNER JOIN inserted b
          ON a.FeedbackInitiatorTypeId = b.FeedbackInitiatorTypeId


GO
ALTER TABLE [dbo].[FeedbackInitiatorType] ENABLE TRIGGER [trg_FeedbackInitiatorType_Update]
GO
/****** Object:  Trigger [dbo].[trg_FeedbackType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





      CREATE TRIGGER [dbo].[trg_FeedbackType_Update] ON [dbo].[FeedbackType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM FeedbackType a
        INNER JOIN inserted b
          ON a.FeedbackTypeId = b.FeedbackTypeId


GO
ALTER TABLE [dbo].[FeedbackType] ENABLE TRIGGER [trg_FeedbackType_Update]
GO
/****** Object:  Trigger [dbo].[trg_GenderType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





      CREATE TRIGGER [dbo].[trg_GenderType_Update] ON [dbo].[GenderType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM GenderType a
        INNER JOIN inserted b
          ON a.GenderTypeId = b.GenderTypeId


GO
ALTER TABLE [dbo].[GenderType] ENABLE TRIGGER [trg_GenderType_Update]
GO
/****** Object:  Trigger [dbo].[trg_LanguageType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





      CREATE TRIGGER [dbo].[trg_LanguageType_Update] ON [dbo].[LanguageType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM LanguageType a
        INNER JOIN inserted b
          ON a.LanguageTypeId = b.LanguageTypeId


GO
ALTER TABLE [dbo].[LanguageType] ENABLE TRIGGER [trg_LanguageType_Update]
GO
/****** Object:  Trigger [dbo].[trg_LookupList_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [trg_LookupList_Update]
CREATE TRIGGER [dbo].[trg_LookupList_Update] ON [dbo].[LookupList]
FOR UPDATE
AS 

SET NOCOUNT ON

UPDATE a SET 
a.DataVersion = b.DataVersion + 1
FROM LookupList a
INNER JOIN inserted b
    ON a.LookupListId = b.LookupListId

GO
ALTER TABLE [dbo].[LookupList] ENABLE TRIGGER [trg_LookupList_Update]
GO
/****** Object:  Trigger [dbo].[trg_Room_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_Room_Update] ON [dbo].[Room]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Room a
        INNER JOIN inserted b
          ON a.RoomId = b.RoomId
GO
ALTER TABLE [dbo].[Room] ENABLE TRIGGER [trg_Room_Update]
GO
/****** Object:  Trigger [dbo].[trg_Session_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Session_Update] ON [dbo].[Session]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Session a
        INNER JOIN inserted b
          ON a.SessionId = b.SessionId
GO
ALTER TABLE [dbo].[Session] ENABLE TRIGGER [trg_Session_Update]
GO
/****** Object:  Trigger [dbo].[trg_Session_Like_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









      CREATE TRIGGER [dbo].[trg_Session_Like_Update] ON [dbo].[Session_Like]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Session_Like a
        INNER JOIN inserted b
          ON a.SessionId = b.SessionId
		  AND a.UserId = b.UserId


GO
ALTER TABLE [dbo].[Session_Like] ENABLE TRIGGER [trg_Session_Like_Update]
GO
/****** Object:  Trigger [dbo].[trg_Session_SessionCategoryType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








      CREATE TRIGGER [dbo].[trg_Session_SessionCategoryType_Update] ON [dbo].[Session_SessionCategoryType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Session_SessionCategoryType a
        INNER JOIN inserted b
          ON a.SessionId = b.SessionId
		  AND a.SessionCategoryTypeId = b.SessionCategoryTypeId


GO
ALTER TABLE [dbo].[Session_SessionCategoryType] ENABLE TRIGGER [trg_Session_SessionCategoryType_Update]
GO
/****** Object:  Trigger [dbo].[trg_Session_Speaker_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










      CREATE TRIGGER [dbo].[trg_Session_Speaker_Update] ON [dbo].[Session_Speaker]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Session_Speaker a
        INNER JOIN inserted b
          ON a.SessionId = b.SessionId
		  AND a.UserId = b.UserId


GO
ALTER TABLE [dbo].[Session_Speaker] ENABLE TRIGGER [trg_Session_Speaker_Update]
GO
/****** Object:  Trigger [dbo].[trg_SessionCategoryType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







      CREATE TRIGGER [dbo].[trg_SessionCategoryType_Update] ON [dbo].[SessionCategoryType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM SessionCategoryType a
        INNER JOIN inserted b
          ON a.SessionCategoryTypeId = b.SessionCategoryTypeId


GO
ALTER TABLE [dbo].[SessionCategoryType] ENABLE TRIGGER [trg_SessionCategoryType_Update]
GO
/****** Object:  Trigger [dbo].[trg_Sponsor_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







      CREATE TRIGGER [dbo].[trg_Sponsor_Update] ON [dbo].[Sponsor]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Sponsor a
        INNER JOIN inserted b
          ON a.SponsorId = b.SponsorId


GO
ALTER TABLE [dbo].[Sponsor] ENABLE TRIGGER [trg_Sponsor_Update]
GO
/****** Object:  Trigger [dbo].[trg_Sponsor_FeaturedEvent_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









      CREATE TRIGGER [dbo].[trg_Sponsor_FeaturedEvent_Update] ON [dbo].[Sponsor_FeaturedEvent]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Sponsor_FeaturedEvent a
        INNER JOIN inserted b
          ON a.SponsorId = b.SponsorId
		  AND a.FeaturedEventId = b.FeaturedEventId


GO
ALTER TABLE [dbo].[Sponsor_FeaturedEvent] ENABLE TRIGGER [trg_Sponsor_FeaturedEvent_Update]
GO
/****** Object:  Trigger [dbo].[trg_SponsorType_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






      CREATE TRIGGER [dbo].[trg_SponsorType_Update] ON [dbo].[SponsorType]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM SponsorType a
        INNER JOIN inserted b
          ON a.SponsorTypeId = b.SponsorTypeId


GO
ALTER TABLE [dbo].[SponsorType] ENABLE TRIGGER [trg_SponsorType_Update]
GO
/****** Object:  Trigger [dbo].[trg_Users_Update]    Script Date: 5/11/2019 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Users_Update] ON [dbo].[Users]
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Users a
        INNER JOIN inserted b
          ON a.UserId = b.UserId
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_Users_Update]
GO
