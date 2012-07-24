
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

Print 'Seeding Games....'
delete from rating
delete from game
insert into dbo.Game select 'World of Warcraft', 'Sed vulputate magna ligula, vitae consequat est. Etiam nec eros mauris. Donec tristique, tellus in ultricies viverra, purus ligula consectetur metus, ut interdum purus erat tristique risus. Etiam ac tincidunt mauris.'
declare @id int 
set @id = scope_identity()
insert into dbo.Rating select @id, 5
insert into dbo.Rating select @id, 1
insert into dbo.Game select 'Minute to Win IT', 'Nunc vitae mi egestas tortor aliquet dapibus id eget dui. Ut vitae dapibus nibh. Curabitur ultrices, nunc vitae gravida iaculis, ante lectus pharetra magna, ac imperdiet ipsum neque a purus. '
set @id = scope_identity()
insert into dbo.Rating select @id, 2
insert into dbo.Rating select @id, 2
insert into dbo.Game select 'Rush', 'Aliquam vehicula nunc in nibh porta condimentum. Morbi et nulla at mi tempor placerat ut nec ipsum.'
set @id = scope_identity()
insert into dbo.Rating select @id, 2
insert into dbo.Rating select @id, 2
insert into dbo.Game select 'Toy Soldiers', 'Nullam eget nisi purus, ut posuere lacus. Maecenas commodo risus sed justo placerat commodo vel sit amet dolor. Phasellus iaculis, lectus sed luctus interdum, nisi est fringilla augue, eu interdum purus enim vel mi.'
set @id = scope_identity()
insert into dbo.Rating select @id, 1
insert into dbo.Rating select @id, 4
insert into dbo.Game select 'Plants vs Zombies', 'Maecenas non massa ut ante vehicula mattis a nec turpis. Etiam quis lorem ipsum, vel dapibus eros. Ut hendrerit, mauris eleifend tempor bibendum, lorem nunc hendrerit enim, ut imperdiet sapien felis id ipsum.'
set @id = scope_identity()
insert into dbo.Rating select @id, 1
insert into dbo.Rating select @id, 1
