CREATE TABLE [dbo].[Log]
(
	 [Id]			int				not null	primary key identity(1,1)
	,[IdLevel]		int				not null	foreign key references [dbo].[LogLevel]([Id])
	,[Message]		varchar(7900)	not null
	,[Date]			datetime		not null	default getdate()
)
