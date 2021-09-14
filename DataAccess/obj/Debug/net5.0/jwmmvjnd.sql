IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Companies] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NULL,
    [Addres] nvarchar(150) NOT NULL,
    [LastModification] datetime2 NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(100) NULL,
    [AgeRestriction] int NOT NULL DEFAULT 0,
    [UrlImage] nvarchar(max) NULL,
    [Price] decimal(4,3) NOT NULL,
    [CompanyId] int NOT NULL,
    [LastModification] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Addres', N'LastModification', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] ON;
INSERT INTO [Companies] ([Id], [Addres], [LastModification], [Name])
VALUES (1, N'', '2021-09-09T16:03:13.6679745-05:00', N'Mattel');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Addres', N'LastModification', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
    SET IDENTITY_INSERT [Companies] OFF;
GO

CREATE INDEX [IX_Products_CompanyId] ON [Products] ([CompanyId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210909210314_changeAgeRestrictionProperty', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Companies] SET [LastModification] = '2021-09-09T16:04:16.6520340-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AgeRestriction', N'CompanyId', N'Description', N'LastModification', N'Name', N'Price', N'UrlImage') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [AgeRestriction], [CompanyId], [Description], [LastModification], [Name], [Price], [UrlImage])
VALUES (1, 5, 1, N'Racing Model 1991', '0001-01-01T00:00:00.0000000', N'HotWheels Model 1', 10.5, N''),
(2, 3, 1, N'Racing Model 1991', '0001-01-01T00:00:00.0000000', N'HotWheels Model 2', 100.5, N''),
(3, 3, 1, N'Racing Model 1992', '0001-01-01T00:00:00.0000000', N'HotWheels Model 3', 69.5, N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AgeRestriction', N'CompanyId', N'Description', N'LastModification', N'Name', N'Price', N'UrlImage') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210909210417_firtsMigration', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Price');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Products] ALTER COLUMN [Price] decimal(10,2) NOT NULL;
GO

UPDATE [Companies] SET [LastModification] = '2021-09-09T16:07:42.6379002-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210909210743_firts', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [Companies] SET [LastModification] = '2021-09-09T16:33:47.2111367-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastModification] = '2021-09-09T16:33:47.2061286-05:00'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastModification] = '2021-09-09T16:33:47.2090240-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Products] SET [LastModification] = '2021-09-09T16:33:47.2090276-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210909213347_insertdata', N'5.0.0');
GO

COMMIT;
GO

