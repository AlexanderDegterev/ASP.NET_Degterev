
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/24/2015 15:35:18
-- Generated from EDMX file: C:\!_ASP_NET\degterev_net\EF6App\EF6App\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [manager.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[LoadingFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoadingFiles];
GO
IF OBJECT_ID(N'[dbo].[ManagerSales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSales];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'ManagerSales'
CREATE TABLE [dbo].[ManagerSales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ManagerSurname] nvarchar(max)  NULL,
    [ManagerDate] datetime  NOT NULL,
    [ClientDate] datetime  NOT NULL,
    [Client] nvarchar(max)  NULL,
    [Product] nvarchar(max)  NULL,
    [Sum] int  NOT NULL
);
GO

-- Creating table 'LoadingFiles'
CREATE TABLE [dbo].[LoadingFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] varchar(100)  NULL,
    [CreationDate] datetime  NULL,
    [FileLenght] decimal(10,0)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSales'
ALTER TABLE [dbo].[ManagerSales]
ADD CONSTRAINT [PK_ManagerSales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoadingFiles'
ALTER TABLE [dbo].[LoadingFiles]
ADD CONSTRAINT [PK_LoadingFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------