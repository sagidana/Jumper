
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/08/2016 22:35:48
-- Generated from EDMX file: C:\Users\Administrator\Source\Repos\Jumper\Jumper\DAL\JumperDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SagiTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserZone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zones] DROP CONSTRAINT [FK_UserZone];
GO
IF OBJECT_ID(N'[dbo].[FK_ZonePolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zones] DROP CONSTRAINT [FK_ZonePolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPolicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_UserPolicy];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupUser] DROP CONSTRAINT [FK_GroupUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroup_Group]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupGroup] DROP CONSTRAINT [FK_GroupGroup_Group];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroup_Group1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupGroup] DROP CONSTRAINT [FK_GroupGroup_Group1];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicyGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Policies] DROP CONSTRAINT [FK_PolicyGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_UserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_GhostUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ghosts] DROP CONSTRAINT [FK_GhostUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Zones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zones];
GO
IF OBJECT_ID(N'[dbo].[Policies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Policies];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Ghosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ghosts];
GO
IF OBJECT_ID(N'[dbo].[GroupUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupUser];
GO
IF OBJECT_ID(N'[dbo].[GroupGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupGroup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] geography  NOT NULL
);
GO

-- Creating table 'Zones'
CREATE TABLE [dbo].[Zones] (
    [Id] uniqueidentifier  NOT NULL,
    [Location] geography  NOT NULL,
    [Radius] int  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Policy_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Policies'
CREATE TABLE [dbo].[Policies] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Group_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] uniqueidentifier  NOT NULL,
    [Location] geography  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [Radius] int  NOT NULL,
    [ExpirationTime] datetime  NOT NULL,
    [Content] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ghosts'
CREATE TABLE [dbo].[Ghosts] (
    [Id] uniqueidentifier  NOT NULL,
    [Location] geography  NOT NULL,
    [ExpirationTime] datetime  NOT NULL,
    [User_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'GroupUser'
CREATE TABLE [dbo].[GroupUser] (
    [Groups_Id] uniqueidentifier  NOT NULL,
    [Users_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'GroupGroup'
CREATE TABLE [dbo].[GroupGroup] (
    [InGroups_Id] uniqueidentifier  NOT NULL,
    [IncludedGroups_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zones'
ALTER TABLE [dbo].[Zones]
ADD CONSTRAINT [PK_Zones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [PK_Policies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ghosts'
ALTER TABLE [dbo].[Ghosts]
ADD CONSTRAINT [PK_Ghosts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Groups_Id], [Users_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [PK_GroupUser]
    PRIMARY KEY CLUSTERED ([Groups_Id], [Users_Id] ASC);
GO

-- Creating primary key on [InGroups_Id], [IncludedGroups_Id] in table 'GroupGroup'
ALTER TABLE [dbo].[GroupGroup]
ADD CONSTRAINT [PK_GroupGroup]
    PRIMARY KEY CLUSTERED ([InGroups_Id], [IncludedGroups_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Zones'
ALTER TABLE [dbo].[Zones]
ADD CONSTRAINT [FK_UserZone]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserZone'
CREATE INDEX [IX_FK_UserZone]
ON [dbo].[Zones]
    ([UserId]);
GO

-- Creating foreign key on [Policy_Id] in table 'Zones'
ALTER TABLE [dbo].[Zones]
ADD CONSTRAINT [FK_ZonePolicy]
    FOREIGN KEY ([Policy_Id])
    REFERENCES [dbo].[Policies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZonePolicy'
CREATE INDEX [IX_FK_ZonePolicy]
ON [dbo].[Zones]
    ([Policy_Id]);
GO

-- Creating foreign key on [UserId] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_UserPolicy]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPolicy'
CREATE INDEX [IX_FK_UserPolicy]
ON [dbo].[Policies]
    ([UserId]);
GO

-- Creating foreign key on [Groups_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_Group]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'GroupUser'
ALTER TABLE [dbo].[GroupUser]
ADD CONSTRAINT [FK_GroupUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupUser_User'
CREATE INDEX [IX_FK_GroupUser_User]
ON [dbo].[GroupUser]
    ([Users_Id]);
GO

-- Creating foreign key on [InGroups_Id] in table 'GroupGroup'
ALTER TABLE [dbo].[GroupGroup]
ADD CONSTRAINT [FK_GroupGroup_Group]
    FOREIGN KEY ([InGroups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IncludedGroups_Id] in table 'GroupGroup'
ALTER TABLE [dbo].[GroupGroup]
ADD CONSTRAINT [FK_GroupGroup_Group1]
    FOREIGN KEY ([IncludedGroups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroup_Group1'
CREATE INDEX [IX_FK_GroupGroup_Group1]
ON [dbo].[GroupGroup]
    ([IncludedGroups_Id]);
GO

-- Creating foreign key on [Group_Id] in table 'Policies'
ALTER TABLE [dbo].[Policies]
ADD CONSTRAINT [FK_PolicyGroup]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicyGroup'
CREATE INDEX [IX_FK_PolicyGroup]
ON [dbo].[Policies]
    ([Group_Id]);
GO

-- Creating foreign key on [UserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_UserMessage]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage'
CREATE INDEX [IX_FK_UserMessage]
ON [dbo].[Messages]
    ([UserId]);
GO

-- Creating foreign key on [User_Id] in table 'Ghosts'
ALTER TABLE [dbo].[Ghosts]
ADD CONSTRAINT [FK_GhostUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GhostUser'
CREATE INDEX [IX_FK_GhostUser]
ON [dbo].[Ghosts]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------