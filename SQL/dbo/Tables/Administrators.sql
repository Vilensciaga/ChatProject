CREATE TABLE [dbo].[Administrators] (
    [Id]              NVARCHAR (450) NOT NULL,
    [AdministratorId] INT            NOT NULL,
    [UserId]          INT            NOT NULL,
    CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Administrators_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Administrators_UserId]
    ON [dbo].[Administrators]([UserId] ASC);

