﻿CREATE TABLE [dbo].[Session_Like] (
    [SessionLikeId]   UNIQUEIDENTIFIER CONSTRAINT [DF_Session_Like_SessionLikeId] DEFAULT (newid()) NOT NULL,
    [SessionId]       INT              NOT NULL,
    [UserId]          INT              NOT NULL,
    [DataVersion]     INT              CONSTRAINT [DF_Session_Like_DataVersion] DEFAULT ((1)) NOT NULL,
    [CreatedUtcDate]  DATETIME2 (7)    CONSTRAINT [DF_Session_Like_CreatedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [CreatedBy]       NVARCHAR (200)   NOT NULL,
    [ModifiedUtcDate] DATETIME2 (7)    CONSTRAINT [DF_Session_Like_ModifiedUtcDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedBy]      NVARCHAR (200)   NOT NULL,
    [IsDeleted]       BIT              CONSTRAINT [DF_Session_Like_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Session_Like] PRIMARY KEY CLUSTERED ([SessionLikeId] ASC),
    CONSTRAINT [FK_Session_Like_Session] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([SessionId]),
    CONSTRAINT [FK_Session_Like_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [UC_Session_Like] UNIQUE NONCLUSTERED ([UserId] ASC, [SessionId] ASC)
);


GO
CREATE TRIGGER [dbo].[trg_Session_Like_Update] ON dbo.Session_Like
      FOR UPDATE
      AS 

      SET NOCOUNT ON

      UPDATE a SET 
        a.DataVersion = b.DataVersion + 1
      FROM Session_Like a
        INNER JOIN inserted b
          ON a.SessionId = b.SessionId
		  AND a.UserId = b.UserId
