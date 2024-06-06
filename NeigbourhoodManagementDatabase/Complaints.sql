CREATE TABLE [dbo].[Complaints]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[NameOfAuthor] NVARCHAR(250) NOT NULL,
	[BuildingNumberOfAuthor] INT NOT NULL,
	[ApartmentNumberOfAuthor] INT NOT NULL,
	[Description] NVARCHAR(2000) NOT NULL,
	[BuildingNumberOfComplaint] INT NOT NULL,
	[ApartmentNumberOfComplaint] INT NOT NULL,
	[ComplaintCategory] INT NOT NULL,
	[ComplaintStatus] INT NOT NULL,
	[DateAdded] DATETIME NOT NULL

)
