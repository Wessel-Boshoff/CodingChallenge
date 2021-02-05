﻿/*
Deployment script for Moore_Proccess_Controls

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
USE [master];


GO

IF (DB_ID(N'Moore_Proccess_Controls') IS NOT NULL) 
BEGIN
    ALTER DATABASE [Moore_Proccess_Controls]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [Moore_Proccess_Controls];
END

GO
PRINT N'Creating Moore_Proccess_Controls...'
GO
CREATE DATABASE [Moore_Proccess_Controls]
    ON 
    PRIMARY(NAME = [Moore_Proccess_Controls], FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Moore_Proccess_Controls_Primary.mdf')
    LOG ON (NAME = [Moore_Proccess_Controls_log], FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Moore_Proccess_Controls_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [Moore_Proccess_Controls];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'Moore_Proccess_Controls')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [Moore_Proccess_Controls]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'Moore_Proccess_Controls')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [Moore_Proccess_Controls]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [Moore_Proccess_Controls]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE [Moore_Proccess_Controls]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'Moore_Proccess_Controls')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[CalculationResult]...';


GO
CREATE TABLE [dbo].[CalculationResult] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [IdTag]             INT             NOT NULL,
    [IdCalculationType] INT             NOT NULL,
    [Value]             DECIMAL (18, 9) NOT NULL,
    [Date]              DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[CalculationType]...';


GO
CREATE TABLE [dbo].[CalculationType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (170) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Log]...';


GO
CREATE TABLE [dbo].[Log] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [IdLevel] INT            NOT NULL,
    [Message] VARCHAR (7900) NOT NULL,
    [Date]    DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[LogLevel]...';


GO
CREATE TABLE [dbo].[LogLevel] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (70) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Tag]...';


GO
CREATE TABLE [dbo].[Tag] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[CalculationResult]...';


GO
ALTER TABLE [dbo].[CalculationResult]
    ADD DEFAULT getdate() FOR [Date];


GO
PRINT N'Creating unnamed constraint on [dbo].[Log]...';


GO
ALTER TABLE [dbo].[Log]
    ADD DEFAULT getdate() FOR [Date];


GO
PRINT N'Creating unnamed constraint on [dbo].[CalculationResult]...';


GO
ALTER TABLE [dbo].[CalculationResult]
    ADD FOREIGN KEY ([IdTag]) REFERENCES [dbo].[Tag] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[CalculationResult]...';


GO
ALTER TABLE [dbo].[CalculationResult]
    ADD FOREIGN KEY ([IdCalculationType]) REFERENCES [dbo].[CalculationType] ([Id]);


GO
PRINT N'Creating unnamed constraint on [dbo].[Log]...';


GO
ALTER TABLE [dbo].[Log]
    ADD FOREIGN KEY ([IdLevel]) REFERENCES [dbo].[LogLevel] ([Id]);


GO
PRINT N'Creating [dbo].[InsertCalculationResult]...';


GO
CREATE PROCEDURE [dbo].[InsertCalculationResult]
     @IdTag                 int 
    ,@IdCalculationType     int 
    ,@Value                 decimal(18,9)
AS
INSERT INTO [dbo].[CalculationResult]
           ([IdTag]
           ,[IdCalculationType]
           ,[Value]
           ,[Date])
     VALUES
           (@IdTag
           ,@IdCalculationType
           ,@Value
           ,getdate())
GO
PRINT N'Creating [dbo].[InsertLog]...';


GO
CREATE PROCEDURE [dbo].[InsertLog]
     @IdLevel       int
    ,@Message       varchar(7900)
AS
INSERT INTO [dbo].[Log]
           ([IdLevel]
           ,[Message]
           ,[Date])
     VALUES
           (@IdLevel
           ,@Message
           ,getdate())
GO
PRINT N'Creating [dbo].[SelectCalculationType]...';


GO
CREATE PROCEDURE [dbo].[SelectCalculationType]
AS
SELECT [Id]
      ,[Name]
  FROM [dbo].[CalculationType]
GO
PRINT N'Creating [dbo].[SelectTag]...';


GO
CREATE PROCEDURE [dbo].[SelectTag]
AS
SELECT [Id]
      ,[Name]
  FROM [dbo].[Tag]
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


print 'Merge [dbo].[LogLevel]'
set identity_insert [dbo].[LogLevel] on
merge into [dbo].[LogLevel] as target
using
(
    values
           (1, 'Debug')
          ,(2, 'Info')
          ,(3, 'Warning')
          ,(4, 'Error')
          ,(5, 'Fatal')
)
as source
(
     [Id]
    ,[Name]
)
on
(
    source.[Id] = target.[Id]
)
when not matched then
insert
(
     [Id]
    ,[Name]
)
values
(
     source.[Id]
    ,source.[Name]
)
when matched then
update
set
     target.[Name] = source.[Name];
set identity_insert [dbo].[LogLevel] off



print 'Merge [dbo].[Tag]'
set identity_insert [dbo].[Tag] on
merge into [dbo].[Tag] as target
using
(
    values
           (1, 'TAG1')
          ,(2, 'TAG2')
          ,(3, 'TAG3')
          ,(4, 'TAG4')
          ,(5, 'TAG5')
          ,(6, 'TAG6')
          ,(7, 'TAG7')
          ,(8, 'TAG8')
          ,(9, 'TAG9')
          ,(10, 'TAG10')
          ,(11, 'TAG11')
          ,(12, 'TAG12')
          ,(13, 'TAG13')
          ,(14, 'TAG14')
          ,(15, 'TAG15')
          ,(16, 'TAG16')
          ,(17, 'TAG17')
          ,(18, 'TAG18')
)
as source
(
     [Id]
    ,[Name]
)
on
(
    source.[Id] = target.[Id]
)
when not matched then
insert
(
     [Id]
    ,[Name]
)
values
(
     source.[Id]
    ,source.[Name]
)
when matched then
update
set
     target.[Name] = source.[Name];
set identity_insert [dbo].[Tag] off





print 'Merge [dbo].[CalculationType]'
set identity_insert [dbo].[CalculationType] on
merge into [dbo].[CalculationType] as target
using
(
    values
           (1, 'Standard Deviation')
          ,(2, 'RMS')
          ,(3, 'Specific Rate of Change')
)
as source
(
     [Id]
    ,[Name]
)
on
(
    source.[Id] = target.[Id]
)
when not matched then
insert
(
     [Id]
    ,[Name]
)
values
(
     source.[Id]
    ,source.[Name]
)
when matched then
update
set
     target.[Name] = source.[Name];
set identity_insert [dbo].[CalculationType] off
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'Moore_Proccess_Controls', 'ON';
    END


GO
PRINT N'Update complete.';


GO