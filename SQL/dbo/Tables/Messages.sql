CREATE TABLE [dbo].[Messages] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [ChatId]    INT            NOT NULL,
    [MessageId] INT            NOT NULL,
    [message]   NVARCHAR (MAX) NOT NULL,
    [UserId]    INT            NOT NULL,
    [date]      DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Messages_Chats_ChatId] FOREIGN KEY ([ChatId]) REFERENCES [dbo].[Chats] ([ChatId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_ChatId]
    ON [dbo].[Messages]([ChatId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_UserId]
    ON [dbo].[Messages]([UserId] ASC);

