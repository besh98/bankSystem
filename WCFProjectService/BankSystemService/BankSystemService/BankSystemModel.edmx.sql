
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2019 15:38:48
-- Generated from EDMX file: C:\Users\User\Desktop\WCFProjectStudy\WCFProjectService\BankSystemService\BankSystemService\BankSystemModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Cards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cards];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[BankSystemModelStoreContainer].[CardsView]', 'U') IS NOT NULL
    DROP TABLE [BankSystemModelStoreContainer].[CardsView];
GO
IF OBJECT_ID(N'[BankSystemModelStoreContainer].[TransactionsUsersCardsView]', 'U') IS NOT NULL
    DROP TABLE [BankSystemModelStoreContainer].[TransactionsUsersCardsView];
GO
IF OBJECT_ID(N'[BankSystemModelStoreContainer].[TransactionsView]', 'U') IS NOT NULL
    DROP TABLE [BankSystemModelStoreContainer].[TransactionsView];
GO
IF OBJECT_ID(N'[BankSystemModelStoreContainer].[UserCardsView]', 'U') IS NOT NULL
    DROP TABLE [BankSystemModelStoreContainer].[UserCardsView];
GO
IF OBJECT_ID(N'[BankSystemModelStoreContainer].[UsersView]', 'U') IS NOT NULL
    DROP TABLE [BankSystemModelStoreContainer].[UsersView];
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

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [User_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'Cards'
CREATE TABLE [dbo].[Cards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CardNumber] bigint  NOT NULL,
    [Available] varchar(250)  NULL,
    [Balance] varchar(250)  NULL,
    [Name] varchar(250)  NULL,
    [UserId] nvarchar(128)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NULL,
    [Date] datetime  NULL,
    [Title] nvarchar(max)  NULL,
    [Amount] varchar(250)  NULL,
    [Balance] varchar(250)  NULL
);
GO

-- Creating table 'CardsViews'
CREATE TABLE [dbo].[CardsViews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CardNumber] bigint  NOT NULL,
    [Available] varchar(250)  NULL,
    [Balance] varchar(250)  NULL,
    [Name] varchar(250)  NULL,
    [UserId] nvarchar(128)  NULL
);
GO

-- Creating table 'TransactionsUsersCardsViews'
CREATE TABLE [dbo].[TransactionsUsersCardsViews] (
    [TransactionId] int  NOT NULL,
    [UserId] nvarchar(128)  NULL,
    [Date] datetime  NULL,
    [Title] nvarchar(max)  NULL,
    [TransactionAmount] varchar(250)  NULL,
    [TransactionBalance] varchar(250)  NULL,
    [UserName] nvarchar(max)  NULL,
    [CardId] int  NOT NULL,
    [CardNumber] bigint  NOT NULL,
    [CardAvailable] varchar(250)  NULL,
    [CardBalance] varchar(250)  NULL,
    [CardName] varchar(250)  NULL
);
GO

-- Creating table 'TransactionsViews'
CREATE TABLE [dbo].[TransactionsViews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NULL,
    [Date] datetime  NULL,
    [Title] nvarchar(max)  NULL,
    [Amount] varchar(250)  NULL,
    [Balance] varchar(250)  NULL
);
GO

-- Creating table 'UserCardsViews'
CREATE TABLE [dbo].[UserCardsViews] (
    [UserId] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL,
    [CardId] int  NOT NULL,
    [CardNumber] bigint  NOT NULL,
    [Available] varchar(250)  NULL,
    [Balance] varchar(250)  NULL,
    [CardName] varchar(250)  NULL
);
GO

-- Creating table 'UsersViews'
CREATE TABLE [dbo].[UsersViews] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
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

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [PK_Cards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [CardNumber] in table 'CardsViews'
ALTER TABLE [dbo].[CardsViews]
ADD CONSTRAINT [PK_CardsViews]
    PRIMARY KEY CLUSTERED ([Id], [CardNumber] ASC);
GO

-- Creating primary key on [TransactionId], [CardId], [CardNumber] in table 'TransactionsUsersCardsViews'
ALTER TABLE [dbo].[TransactionsUsersCardsViews]
ADD CONSTRAINT [PK_TransactionsUsersCardsViews]
    PRIMARY KEY CLUSTERED ([TransactionId], [CardId], [CardNumber] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionsViews'
ALTER TABLE [dbo].[TransactionsViews]
ADD CONSTRAINT [PK_TransactionsViews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [CardId], [CardNumber] in table 'UserCardsViews'
ALTER TABLE [dbo].[UserCardsViews]
ADD CONSTRAINT [PK_UserCardsViews]
    PRIMARY KEY CLUSTERED ([UserId], [CardId], [CardNumber] ASC);
GO

-- Creating primary key on [Id] in table 'UsersViews'
ALTER TABLE [dbo].[UsersViews]
ADD CONSTRAINT [PK_UsersViews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([User_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRole]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUser'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUser]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------