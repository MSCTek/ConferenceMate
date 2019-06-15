CREATE TABLE [dbo].[Users] (
    [UserId]              INT             IDENTITY (1, 1) NOT NULL,
    [UserName]            NVARCHAR (255)  NULL,
    [Email]               NVARCHAR (255)  NULL,
    [BirthDate]           DATETIME2 (7)   NULL,
    [FirstName]           NVARCHAR (255)  NULL,
    [LastName]            NVARCHAR (255)  NULL,
    [GenderTypeId]        INT             NOT NULL,
    [Password]            NVARCHAR (255)  NULL,
    [Salt]                NVARCHAR (255)  NULL,
    [LastLogin]           DATETIME2 (7)   NOT NULL,
    [PreferredLanguageId] INT             CONSTRAINT [DF_Users_PreferredLanguageId] DEFAULT ((1)) NOT NULL,
    [Biography]           NVARCHAR (4000) NULL,
    [PhotoUrl]            NVARCHAR (1000) NULL,
    [AvatarUrl]           NVARCHAR (1000) NULL,
    [CompanyName]         NVARCHAR (1000) NULL,
    [JobTitle]            NVARCHAR (1000) NULL,
    [CompanyWebsiteUrl]   NVARCHAR (1000) NULL,
    [BlogUrl]             NVARCHAR (1000) NULL,
    [TwitterUrl]          NVARCHAR (1000) NULL,
    [LinkedInUrl]         NVARCHAR (1000) NULL,
    [DataVersion]         INT             CONSTRAINT [DF_Users_DataVersion] DEFAULT ((1)) NOT NULL,
    [CreatedUtcDate]      DATETIME2 (7)   CONSTRAINT [DF_Users_CreatedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]           NVARCHAR (200)  NOT NULL,
    [ModifiedUtcDate]     DATETIME2 (7)   CONSTRAINT [DF_Users_ModifiedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]          NVARCHAR (200)  NOT NULL,
    [IsDeleted]           BIT             CONSTRAINT [DF_Users_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Users_GenderType_GenderTypeId] FOREIGN KEY ([GenderTypeId]) REFERENCES [dbo].[GenderType] ([GenderTypeId]),
    CONSTRAINT [FK_Users_LanguageType] FOREIGN KEY ([PreferredLanguageId]) REFERENCES [dbo].[LanguageType] ([LanguageTypeId])
);


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
