
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/10/2014 19:17:47
-- Generated from EDMX file: C:\Development\virtual-manager\VirtualManager\libVmDal\EDM\VirtualManagerDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VirtualManagerDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AccountClaimsTable_dbo_AccountTable_IdentityUser_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountClaimsTable] DROP CONSTRAINT [FK_dbo_AccountClaimsTable_dbo_AccountTable_IdentityUser_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AccountLoginTable_dbo_AccountTable_IdentityUser_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountLoginTable] DROP CONSTRAINT [FK_dbo_AccountLoginTable_dbo_AccountTable_IdentityUser_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AccountUserRoleTable_dbo_AccountRoleTable_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountUserRoleTable] DROP CONSTRAINT [FK_dbo_AccountUserRoleTable_dbo_AccountRoleTable_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AccountUserRoleTable_dbo_AccountTable_IdentityUser_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountUserRoleTable] DROP CONSTRAINT [FK_dbo_AccountUserRoleTable_dbo_AccountTable_IdentityUser_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodDrinkProjectAssignment_FoodDrinkTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodDrinkProjectAssignment] DROP CONSTRAINT [FK_FoodDrinkProjectAssignment_FoodDrinkTable];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodDrinkProjectAssignment_ProjectTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodDrinkProjectAssignment] DROP CONSTRAINT [FK_FoodDrinkProjectAssignment_ProjectTable];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodDrinkTable_MeasureTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodDrinkTable] DROP CONSTRAINT [FK_FoodDrinkTable_MeasureTable];
GO
IF OBJECT_ID(N'[dbo].[FK_FoodDrinkTable_ProviderFoodCoastTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoodDrinkTable] DROP CONSTRAINT [FK_FoodDrinkTable_ProviderFoodCoastTable];
GO
IF OBJECT_ID(N'[module].[FK_ModuleProjectAssociation_ModuleTable]', 'F') IS NOT NULL
    ALTER TABLE [module].[ModuleProjectAssociation] DROP CONSTRAINT [FK_ModuleProjectAssociation_ModuleTable];
GO
IF OBJECT_ID(N'[module].[FK_ModuleProjectAssociation_ProjectTable]', 'F') IS NOT NULL
    ALTER TABLE [module].[ModuleProjectAssociation] DROP CONSTRAINT [FK_ModuleProjectAssociation_ProjectTable];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentTable_AccountTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentTable] DROP CONSTRAINT [FK_PaymentTable_AccountTable];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentTable_ProjectTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentTable] DROP CONSTRAINT [FK_PaymentTable_ProjectTable];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentTable_WorkAgreementTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentTable] DROP CONSTRAINT [FK_PaymentTable_WorkAgreementTable];
GO
IF OBJECT_ID(N'[project].[FK_ProjectTable_FileRepositoryTable]', 'F') IS NOT NULL
    ALTER TABLE [project].[ProjectTable] DROP CONSTRAINT [FK_ProjectTable_FileRepositoryTable];
GO
IF OBJECT_ID(N'[project].[FK_ProjectUserAssociateTable_AccountTable]', 'F') IS NOT NULL
    ALTER TABLE [project].[ProjectUserAssociateTable] DROP CONSTRAINT [FK_ProjectUserAssociateTable_AccountTable];
GO
IF OBJECT_ID(N'[project].[FK_ProjectUserAssociateTable_UserDetails]', 'F') IS NOT NULL
    ALTER TABLE [project].[ProjectUserAssociateTable] DROP CONSTRAINT [FK_ProjectUserAssociateTable_UserDetails];
GO
IF OBJECT_ID(N'[users].[FK_UserDetails_AccountTable]', 'F') IS NOT NULL
    ALTER TABLE [users].[UserDetails] DROP CONSTRAINT [FK_UserDetails_AccountTable];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountClaimsTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountClaimsTable];
GO
IF OBJECT_ID(N'[dbo].[AccountLoginTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountLoginTable];
GO
IF OBJECT_ID(N'[dbo].[AccountRoleTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountRoleTable];
GO
IF OBJECT_ID(N'[dbo].[AccountTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountTable];
GO
IF OBJECT_ID(N'[dbo].[AccountUserRoleTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountUserRoleTable];
GO
IF OBJECT_ID(N'[dbo].[AlmostAccountTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlmostAccountTable];
GO
IF OBJECT_ID(N'[dbo].[FileRepositoryTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileRepositoryTable];
GO
IF OBJECT_ID(N'[dbo].[FileTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileTable];
GO
IF OBJECT_ID(N'[dbo].[FoodDrinkProjectAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodDrinkProjectAssignment];
GO
IF OBJECT_ID(N'[dbo].[FoodDrinkTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoodDrinkTable];
GO
IF OBJECT_ID(N'[dbo].[Key]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Key];
GO
IF OBJECT_ID(N'[dbo].[MeasureTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MeasureTable];
GO
IF OBJECT_ID(N'[dbo].[PaymentTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTable];
GO
IF OBJECT_ID(N'[dbo].[ProviderFoodCoastTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProviderFoodCoastTable];
GO
IF OBJECT_ID(N'[dbo].[TemporaryTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemporaryTable];
GO
IF OBJECT_ID(N'[dbo].[WorkAgreementTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkAgreementTable];
GO
IF OBJECT_ID(N'[module].[ModuleProjectAssociation]', 'U') IS NOT NULL
    DROP TABLE [module].[ModuleProjectAssociation];
GO
IF OBJECT_ID(N'[module].[ModuleTable]', 'U') IS NOT NULL
    DROP TABLE [module].[ModuleTable];
GO
IF OBJECT_ID(N'[project].[ProjectTable]', 'U') IS NOT NULL
    DROP TABLE [project].[ProjectTable];
GO
IF OBJECT_ID(N'[project].[ProjectUserAssociateTable]', 'U') IS NOT NULL
    DROP TABLE [project].[ProjectUserAssociateTable];
GO
IF OBJECT_ID(N'[users].[UserAssociationTable]', 'U') IS NOT NULL
    DROP TABLE [users].[UserAssociationTable];
GO
IF OBJECT_ID(N'[users].[UserDetails]', 'U') IS NOT NULL
    DROP TABLE [users].[UserDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TemporaryTable'
CREATE TABLE [dbo].[TemporaryTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlmostAccountTable'
CREATE TABLE [dbo].[AlmostAccountTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [RegistrationDateTime] uniqueidentifier  NOT NULL,
    [LinkToken] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'AccountTable'
CREATE TABLE [dbo].[AccountTable] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Discriminator] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ModuleProjectAssociation'
CREATE TABLE [dbo].[ModuleProjectAssociation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [ModuleId] int  NOT NULL,
    [TurnOn] bit  NOT NULL
);
GO

-- Creating table 'ModuleTable'
CREATE TABLE [dbo].[ModuleTable] (
    [Id] int  NOT NULL,
    [ModuleName] nvarchar(250)  NOT NULL,
    [ModuleDescription] nvarchar(500)  NULL,
    [ModuleDLLname] nvarchar(100)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Version] nvarchar(10)  NULL,
    [DeveloperName] nvarchar(250)  NULL,
    [StableVersion] bit  NOT NULL,
    [UpdatedDLL] datetime  NULL,
    [PathToDLL] nchar(600)  NULL
);
GO

-- Creating table 'ProjectTable'
CREATE TABLE [dbo].[ProjectTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(500)  NOT NULL,
    [ProjectDescription] nvarchar(1000)  NULL,
    [Created] datetime  NOT NULL,
    [Removed] datetime  NULL,
    [IsVisible] bit  NOT NULL,
    [FileRepositoryId] int  NULL,
    [AvailableModulesId] int  NULL
);
GO

-- Creating table 'ProjectUserAssociateTable'
CREATE TABLE [dbo].[ProjectUserAssociateTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [CreatedTime] datetime  NOT NULL,
    [RemovedTime] datetime  NULL,
    [Locked] bit  NOT NULL,
    [IsOwner] bit  NOT NULL
);
GO

-- Creating table 'UserAssociationTable'
CREATE TABLE [dbo].[UserAssociationTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChiefUserGuid] nchar(10)  NULL,
    [EmployeeGuid] nchar(10)  NULL
);
GO

-- Creating table 'UserDetails'
CREATE TABLE [dbo].[UserDetails] (
    [UserId] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(250)  NULL,
    [UserSurname] nvarchar(250)  NULL,
    [BornDate] datetime  NULL,
    [PESEL] nchar(12)  NULL,
    [Country] nvarchar(250)  NULL,
    [CountryZone] nvarchar(250)  NULL,
    [Gmina] nvarchar(250)  NULL,
    [Street] nvarchar(250)  NULL,
    [NoHome] tinyint  NULL,
    [NoLocal] tinyint  NULL,
    [City] int  NULL,
    [PostalCode] int  NULL,
    [UrzadSkarbowyNazwa] nvarchar(1000)  NULL,
    [SymbolUs] nvarchar(10)  NULL,
    [UserEmailContact] nvarchar(128)  NULL,
    [BankBillNo] nvarchar(26)  NULL,
    [NFZ_No] nvarchar(3)  NULL,
    [WorkersGroup] nvarchar(50)  NULL,
    [Department] nvarchar(150)  NULL
);
GO

-- Creating table 'AccountClaimsTable'
CREATE TABLE [dbo].[AccountClaimsTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(max)  NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [IdentityUser_Id] nvarchar(128)  NULL
);
GO

-- Creating table 'AccountLoginTable'
CREATE TABLE [dbo].[AccountLoginTable] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [IdentityUser_Id] nvarchar(128)  NULL
);
GO

-- Creating table 'AccountRoleTable'
CREATE TABLE [dbo].[AccountRoleTable] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AccountUserRoleTable'
CREATE TABLE [dbo].[AccountUserRoleTable] (
    [UserId] nvarchar(128)  NOT NULL,
    [RoleId] nvarchar(128)  NOT NULL,
    [IdentityUser_Id] nvarchar(128)  NULL
);
GO

-- Creating table 'FileRepositoryTable'
CREATE TABLE [dbo].[FileRepositoryTable] (
    [Id] int  NOT NULL,
    [FileRepoName] nvarchar(150)  NOT NULL,
    [FilesId] int  NOT NULL
);
GO

-- Creating table 'FileTable'
CREATE TABLE [dbo].[FileTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(550)  NOT NULL,
    [Extension] nvarchar(20)  NOT NULL,
    [FileSize] int  NOT NULL,
    [Created] datetime  NULL,
    [Updated] datetime  NULL,
    [UploadedByUserId] nvarchar(128)  NOT NULL,
    [IsVisible] bit  NOT NULL,
    [PathToFile] nvarchar(1000)  NULL,
    [IsFolder] bit  NULL
);
GO

-- Creating table 'Key'
CREATE TABLE [dbo].[Key] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PaymentTable'
CREATE TABLE [dbo].[PaymentTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [WorkAgreementId] int  NOT NULL
);
GO

-- Creating table 'WorkAgreementTable'
CREATE TABLE [dbo].[WorkAgreementTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AgreeementType] nvarchar(500)  NULL,
    [Cost] int  NULL,
    [PerTime] nchar(10)  NULL,
    [AgreementTimeFrom] datetime  NULL,
    [AgreementTimeTo] datetime  NULL,
    [Description] varchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'FoodDrinkProjectAssignment'
CREATE TABLE [dbo].[FoodDrinkProjectAssignment] (
    [Id] int  NOT NULL,
    [ProjectId] int  NOT NULL,
    [FoodDrinkId] int  NOT NULL,
    [FoodDrinkPrice] float  NOT NULL,
    [DateCreated] datetime  NULL,
    [IsEnabled] bit  NOT NULL,
    [HowMany] float  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'FoodDrinkTable'
CREATE TABLE [dbo].[FoodDrinkTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(250)  NULL,
    [ShortNameProduct] nvarchar(50)  NULL,
    [MeasureId] int  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [PhotoPath] nvarchar(500)  NULL,
    [ProviderId] int  NULL
);
GO

-- Creating table 'MeasureTable'
CREATE TABLE [dbo].[MeasureTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ShortName] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'ProviderFoodCoastTable'
CREATE TABLE [dbo].[ProviderFoodCoastTable] (
    [Id] int  NOT NULL,
    [CompanyName] nvarchar(250)  NULL,
    [ProviderName] nvarchar(50)  NULL,
    [ProviderSurname] nvarchar(100)  NULL,
    [City] nvarchar(150)  NULL,
    [CityCode] nvarchar(10)  NULL,
    [Street] nvarchar(350)  NULL,
    [No] int  NULL,
    [BankAccountNo] nvarchar(100)  NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TemporaryTable'
ALTER TABLE [dbo].[TemporaryTable]
ADD CONSTRAINT [PK_TemporaryTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AlmostAccountTable'
ALTER TABLE [dbo].[AlmostAccountTable]
ADD CONSTRAINT [PK_AlmostAccountTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountTable'
ALTER TABLE [dbo].[AccountTable]
ADD CONSTRAINT [PK_AccountTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModuleProjectAssociation'
ALTER TABLE [dbo].[ModuleProjectAssociation]
ADD CONSTRAINT [PK_ModuleProjectAssociation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModuleTable'
ALTER TABLE [dbo].[ModuleTable]
ADD CONSTRAINT [PK_ModuleTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectTable'
ALTER TABLE [dbo].[ProjectTable]
ADD CONSTRAINT [PK_ProjectTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectUserAssociateTable'
ALTER TABLE [dbo].[ProjectUserAssociateTable]
ADD CONSTRAINT [PK_ProjectUserAssociateTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserAssociationTable'
ALTER TABLE [dbo].[UserAssociationTable]
ADD CONSTRAINT [PK_UserAssociationTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'UserDetails'
ALTER TABLE [dbo].[UserDetails]
ADD CONSTRAINT [PK_UserDetails]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AccountClaimsTable'
ALTER TABLE [dbo].[AccountClaimsTable]
ADD CONSTRAINT [PK_AccountClaimsTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AccountLoginTable'
ALTER TABLE [dbo].[AccountLoginTable]
ADD CONSTRAINT [PK_AccountLoginTable]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AccountRoleTable'
ALTER TABLE [dbo].[AccountRoleTable]
ADD CONSTRAINT [PK_AccountRoleTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'AccountUserRoleTable'
ALTER TABLE [dbo].[AccountUserRoleTable]
ADD CONSTRAINT [PK_AccountUserRoleTable]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [Id] in table 'FileRepositoryTable'
ALTER TABLE [dbo].[FileRepositoryTable]
ADD CONSTRAINT [PK_FileRepositoryTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileTable'
ALTER TABLE [dbo].[FileTable]
ADD CONSTRAINT [PK_FileTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Key'
ALTER TABLE [dbo].[Key]
ADD CONSTRAINT [PK_Key]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentTable'
ALTER TABLE [dbo].[PaymentTable]
ADD CONSTRAINT [PK_PaymentTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkAgreementTable'
ALTER TABLE [dbo].[WorkAgreementTable]
ADD CONSTRAINT [PK_WorkAgreementTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FoodDrinkProjectAssignment'
ALTER TABLE [dbo].[FoodDrinkProjectAssignment]
ADD CONSTRAINT [PK_FoodDrinkProjectAssignment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FoodDrinkTable'
ALTER TABLE [dbo].[FoodDrinkTable]
ADD CONSTRAINT [PK_FoodDrinkTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MeasureTable'
ALTER TABLE [dbo].[MeasureTable]
ADD CONSTRAINT [PK_MeasureTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProviderFoodCoastTable'
ALTER TABLE [dbo].[ProviderFoodCoastTable]
ADD CONSTRAINT [PK_ProviderFoodCoastTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'ProjectUserAssociateTable'
ALTER TABLE [dbo].[ProjectUserAssociateTable]
ADD CONSTRAINT [FK_ProjectUserAssociateTable_AccountTable]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUserAssociateTable_AccountTable'
CREATE INDEX [IX_FK_ProjectUserAssociateTable_AccountTable]
ON [dbo].[ProjectUserAssociateTable]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'UserDetails'
ALTER TABLE [dbo].[UserDetails]
ADD CONSTRAINT [FK_UserDetails_AccountTable]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ModuleId] in table 'ModuleProjectAssociation'
ALTER TABLE [dbo].[ModuleProjectAssociation]
ADD CONSTRAINT [FK_ModuleProjectAssociation_ModuleTable]
    FOREIGN KEY ([ModuleId])
    REFERENCES [dbo].[ModuleTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleProjectAssociation_ModuleTable'
CREATE INDEX [IX_FK_ModuleProjectAssociation_ModuleTable]
ON [dbo].[ModuleProjectAssociation]
    ([ModuleId]);
GO

-- Creating foreign key on [ProjectId] in table 'ModuleProjectAssociation'
ALTER TABLE [dbo].[ModuleProjectAssociation]
ADD CONSTRAINT [FK_ModuleProjectAssociation_ProjectTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModuleProjectAssociation_ProjectTable'
CREATE INDEX [IX_FK_ModuleProjectAssociation_ProjectTable]
ON [dbo].[ModuleProjectAssociation]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'ProjectUserAssociateTable'
ALTER TABLE [dbo].[ProjectUserAssociateTable]
ADD CONSTRAINT [FK_ProjectUserAssociateTable_UserDetails]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUserAssociateTable_UserDetails'
CREATE INDEX [IX_FK_ProjectUserAssociateTable_UserDetails]
ON [dbo].[ProjectUserAssociateTable]
    ([ProjectId]);
GO

-- Creating foreign key on [IdentityUser_Id] in table 'AccountClaimsTable'
ALTER TABLE [dbo].[AccountClaimsTable]
ADD CONSTRAINT [FK_dbo_AccountClaimsTable_dbo_AccountTable_IdentityUser_Id]
    FOREIGN KEY ([IdentityUser_Id])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AccountClaimsTable_dbo_AccountTable_IdentityUser_Id'
CREATE INDEX [IX_FK_dbo_AccountClaimsTable_dbo_AccountTable_IdentityUser_Id]
ON [dbo].[AccountClaimsTable]
    ([IdentityUser_Id]);
GO

-- Creating foreign key on [IdentityUser_Id] in table 'AccountLoginTable'
ALTER TABLE [dbo].[AccountLoginTable]
ADD CONSTRAINT [FK_dbo_AccountLoginTable_dbo_AccountTable_IdentityUser_Id]
    FOREIGN KEY ([IdentityUser_Id])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AccountLoginTable_dbo_AccountTable_IdentityUser_Id'
CREATE INDEX [IX_FK_dbo_AccountLoginTable_dbo_AccountTable_IdentityUser_Id]
ON [dbo].[AccountLoginTable]
    ([IdentityUser_Id]);
GO

-- Creating foreign key on [RoleId] in table 'AccountUserRoleTable'
ALTER TABLE [dbo].[AccountUserRoleTable]
ADD CONSTRAINT [FK_dbo_AccountUserRoleTable_dbo_AccountRoleTable_RoleId]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AccountRoleTable]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AccountUserRoleTable_dbo_AccountRoleTable_RoleId'
CREATE INDEX [IX_FK_dbo_AccountUserRoleTable_dbo_AccountRoleTable_RoleId]
ON [dbo].[AccountUserRoleTable]
    ([RoleId]);
GO

-- Creating foreign key on [IdentityUser_Id] in table 'AccountUserRoleTable'
ALTER TABLE [dbo].[AccountUserRoleTable]
ADD CONSTRAINT [FK_dbo_AccountUserRoleTable_dbo_AccountTable_IdentityUser_Id]
    FOREIGN KEY ([IdentityUser_Id])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AccountUserRoleTable_dbo_AccountTable_IdentityUser_Id'
CREATE INDEX [IX_FK_dbo_AccountUserRoleTable_dbo_AccountTable_IdentityUser_Id]
ON [dbo].[AccountUserRoleTable]
    ([IdentityUser_Id]);
GO

-- Creating foreign key on [UserId] in table 'PaymentTable'
ALTER TABLE [dbo].[PaymentTable]
ADD CONSTRAINT [FK_PaymentTable_AccountTable]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AccountTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTable_AccountTable'
CREATE INDEX [IX_FK_PaymentTable_AccountTable]
ON [dbo].[PaymentTable]
    ([UserId]);
GO

-- Creating foreign key on [FileRepositoryId] in table 'ProjectTable'
ALTER TABLE [dbo].[ProjectTable]
ADD CONSTRAINT [FK_ProjectTable_FileRepositoryTable]
    FOREIGN KEY ([FileRepositoryId])
    REFERENCES [dbo].[FileRepositoryTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTable_FileRepositoryTable'
CREATE INDEX [IX_FK_ProjectTable_FileRepositoryTable]
ON [dbo].[ProjectTable]
    ([FileRepositoryId]);
GO

-- Creating foreign key on [ProjectId] in table 'PaymentTable'
ALTER TABLE [dbo].[PaymentTable]
ADD CONSTRAINT [FK_PaymentTable_ProjectTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTable_ProjectTable'
CREATE INDEX [IX_FK_PaymentTable_ProjectTable]
ON [dbo].[PaymentTable]
    ([ProjectId]);
GO

-- Creating foreign key on [WorkAgreementId] in table 'PaymentTable'
ALTER TABLE [dbo].[PaymentTable]
ADD CONSTRAINT [FK_PaymentTable_WorkAgreementTable]
    FOREIGN KEY ([WorkAgreementId])
    REFERENCES [dbo].[WorkAgreementTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTable_WorkAgreementTable'
CREATE INDEX [IX_FK_PaymentTable_WorkAgreementTable]
ON [dbo].[PaymentTable]
    ([WorkAgreementId]);
GO

-- Creating foreign key on [FoodDrinkId] in table 'FoodDrinkProjectAssignment'
ALTER TABLE [dbo].[FoodDrinkProjectAssignment]
ADD CONSTRAINT [FK_FoodDrinkProjectAssignment_FoodDrinkTable]
    FOREIGN KEY ([FoodDrinkId])
    REFERENCES [dbo].[FoodDrinkTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodDrinkProjectAssignment_FoodDrinkTable'
CREATE INDEX [IX_FK_FoodDrinkProjectAssignment_FoodDrinkTable]
ON [dbo].[FoodDrinkProjectAssignment]
    ([FoodDrinkId]);
GO

-- Creating foreign key on [ProjectId] in table 'FoodDrinkProjectAssignment'
ALTER TABLE [dbo].[FoodDrinkProjectAssignment]
ADD CONSTRAINT [FK_FoodDrinkProjectAssignment_ProjectTable]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[ProjectTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodDrinkProjectAssignment_ProjectTable'
CREATE INDEX [IX_FK_FoodDrinkProjectAssignment_ProjectTable]
ON [dbo].[FoodDrinkProjectAssignment]
    ([ProjectId]);
GO

-- Creating foreign key on [MeasureId] in table 'FoodDrinkTable'
ALTER TABLE [dbo].[FoodDrinkTable]
ADD CONSTRAINT [FK_FoodDrinkTable_MeasureTable]
    FOREIGN KEY ([MeasureId])
    REFERENCES [dbo].[MeasureTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodDrinkTable_MeasureTable'
CREATE INDEX [IX_FK_FoodDrinkTable_MeasureTable]
ON [dbo].[FoodDrinkTable]
    ([MeasureId]);
GO

-- Creating foreign key on [ProviderId] in table 'FoodDrinkTable'
ALTER TABLE [dbo].[FoodDrinkTable]
ADD CONSTRAINT [FK_FoodDrinkTable_ProviderFoodCoastTable]
    FOREIGN KEY ([ProviderId])
    REFERENCES [dbo].[ProviderFoodCoastTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodDrinkTable_ProviderFoodCoastTable'
CREATE INDEX [IX_FK_FoodDrinkTable_ProviderFoodCoastTable]
ON [dbo].[FoodDrinkTable]
    ([ProviderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------