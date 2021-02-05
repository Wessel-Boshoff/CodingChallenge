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
