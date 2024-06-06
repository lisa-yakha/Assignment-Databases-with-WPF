CREATE PROCEDURE [dbo].[RETRIEVE_ComplaintsByDate]
	@Keyword DATE
AS
SELECT Id,NameOfAuthor,BuildingNumberOfAuthor,ApartmentNumberOfAuthor, Description, BuildingNumberOfComplaint, ApartmentNumberOfComplaint, ComplaintCategory, ComplaintStatus, DateAdded FROM Complaints WHERE CAST(DateAdded AS DATE) = @Keyword

