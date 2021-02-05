CREATE TABLE [dbo].[CalculationResult]
(
	 [Id]					int				not null	primary key identity(1,1)
	,[IdTag]				int				not null	foreign key references [dbo].[Tag]([Id])
	,[IdCalculationType]	int				not null	foreign key references [dbo].[CalculationType]([Id])
	,[Value]				decimal(18,9)	not null	
	,[Date]					datetime		not null	default getdate()
)
