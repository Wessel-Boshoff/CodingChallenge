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