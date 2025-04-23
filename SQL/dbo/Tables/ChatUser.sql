CREATE TABLE [dbo].[ChatUser] (
    [ChatsChatId] INT NOT NULL,
    [UsersId]     INT NOT NULL,
    CONSTRAINT [PK_ChatUser] PRIMARY KEY CLUSTERED ([ChatsChatId] ASC, [UsersId] ASC),
    CONSTRAINT [FK_ChatUser_Chats_ChatsChatId] FOREIGN KEY ([ChatsChatId]) REFERENCES [dbo].[Chats] ([ChatId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ChatUser_Users_UsersId] FOREIGN KEY ([UsersId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ChatUser_UsersId]
    ON [dbo].[ChatUser]([UsersId] ASC);

