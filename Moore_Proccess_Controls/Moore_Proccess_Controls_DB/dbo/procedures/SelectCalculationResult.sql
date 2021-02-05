CREATE PROCEDURE [dbo].[SelectCalculationResult]
AS
SELECT cr.[Id]
      ,[IdTag]
      ,t.[Name] 'TagName'
      ,[IdCalculationType]
      ,ct.[Name] 'CalculationTypeName'
      ,[Value]
      ,[Date]
  FROM [dbo].[CalculationResult] cr

join
    [dbo].[CalculationType] ct
on  
    cr.[IdCalculationType] = ct.[Id]

join
    [dbo].[Tag] t
on
    cr.[IdTag] = t.[Id]