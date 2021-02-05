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
