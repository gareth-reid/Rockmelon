
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2012 14:42:19
-- Generated from EDMX file: M:\Source\Gareth\Rockmelon\Rockmelon.Domain\Rockmelon.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GameRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rating] DROP CONSTRAINT [FK_GameRating];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Game]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Game];
GO
IF OBJECT_ID(N'[dbo].[Rating]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rating];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Game'
CREATE TABLE [dbo].[Game] (
    [GameId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Rating'
CREATE TABLE [dbo].[Rating] (
    [RatingId] int IDENTITY(1,1) NOT NULL,
    [GameId] int  NOT NULL,
    [RatingValue] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GameId] in table 'Game'
ALTER TABLE [dbo].[Game]
ADD CONSTRAINT [PK_Game]
    PRIMARY KEY CLUSTERED ([GameId] ASC);
GO

-- Creating primary key on [RatingId] in table 'Rating'
ALTER TABLE [dbo].[Rating]
ADD CONSTRAINT [PK_Rating]
    PRIMARY KEY CLUSTERED ([RatingId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameId] in table 'Rating'
ALTER TABLE [dbo].[Rating]
ADD CONSTRAINT [FK_GameRating]
    FOREIGN KEY ([GameId])
    REFERENCES [dbo].[Game]
        ([GameId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GameRating'
CREATE INDEX [IX_FK_GameRating]
ON [dbo].[Rating]
    ([GameId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------