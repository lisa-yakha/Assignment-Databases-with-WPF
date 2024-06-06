CREATE PROCEDURE [dbo].[RETRIEVE_ComplaintsByNameOfAuthor]
	@Name NVARCHAR(250)
AS
SELECT Id,NameOfAuthor,BuildingNumberOfAuthor,ApartmentNumberOfAuthor, Description, BuildingNumberOfComplaint, ApartmentNumberOfComplaint, ComplaintCategory, ComplaintStatus, DateAdded FROM Complaints WHERE @Name = NameOfAuthor

