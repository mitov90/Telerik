CREATE DATABASE Images
GO

USE Images
GO

CREATE TABLE Images(
	ImageId int identity not null primary key,
	[Image] image not null,
	ImageFormat varchar(4) not null
)
GO
