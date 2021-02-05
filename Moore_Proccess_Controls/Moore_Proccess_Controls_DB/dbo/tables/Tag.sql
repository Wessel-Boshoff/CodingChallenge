CREATE TABLE [dbo].[Tag]
(
	 [Id]			int				not null	primary key identity(1,1)
	,[Name]			varchar(50)		not null	unique
)
