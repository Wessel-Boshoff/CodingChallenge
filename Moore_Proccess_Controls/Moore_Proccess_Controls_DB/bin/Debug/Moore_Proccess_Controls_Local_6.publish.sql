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
:setvar DatabaseName "Moore_Proccess_Controls"
:setvar DefaultFilePrefix "Moore_Proccess_Controls"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


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
PRINT N'Update complete.';


GO
