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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212182452_initial'
)
BEGIN
    CREATE TABLE [Species] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Species] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212182452_initial'
)
BEGIN
    CREATE TABLE [Pets] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Age] int NULL,
        [Weight] decimal(18,2) NULL,
        [SpeciesId] int NULL,
        CONSTRAINT [PK_Pets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pets_Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [Species] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212182452_initial'
)
BEGIN
    CREATE INDEX [IX_Pets_SpeciesId] ON [Pets] ([SpeciesId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212182452_initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241212182452_initial', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212183204_MigrationBread'
)
BEGIN
    ALTER TABLE [Pets] ADD [BreadId] int NOT NULL DEFAULT 0;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212183204_MigrationBread'
)
BEGIN
    CREATE TABLE [Breads] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Breads] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212183204_MigrationBread'
)
BEGIN
    CREATE INDEX [IX_Pets_BreadId] ON [Pets] ([BreadId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212183204_MigrationBread'
)
BEGIN
    ALTER TABLE [Pets] ADD CONSTRAINT [FK_Pets_Breads_BreadId] FOREIGN KEY ([BreadId]) REFERENCES [Breads] ([Id]) ON DELETE CASCADE;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241212183204_MigrationBread'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241212183204_MigrationBread', N'9.0.0');
END;

COMMIT;
GO

