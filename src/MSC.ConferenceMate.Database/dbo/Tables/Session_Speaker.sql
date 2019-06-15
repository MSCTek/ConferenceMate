﻿CREATE TABLE [dbo].[Session_Speaker] (
    [SessionId]       INT            NOT NULL,
    [UserId]          INT            NOT NULL,
    [DataVersion]     INT            CONSTRAINT [DF_Session_Speaker_DataVersion] DEFAULT ((1)) NOT NULL,
    [CreatedUtcDate]  DATETIME2 (7)  CONSTRAINT [DF_Session_Speaker_CreatedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]       NVARCHAR (200) NOT NULL,
    [ModifiedUtcDate] DATETIME2 (7)  CONSTRAINT [DF_Session_Speaker_ModifiedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]      NVARCHAR (200) NOT NULL,
    [IsDeleted]       BIT            CONSTRAINT [DF_Session_Speaker_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Session_Users] PRIMARY KEY CLUSTERED ([SessionId] ASC, [UserId] ASC),
    CONSTRAINT [FK_Session_Speaker_Session] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([SessionId]),
    CONSTRAINT [FK_Session_Speaker_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);


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


