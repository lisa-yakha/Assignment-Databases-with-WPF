CREATE PROCEDURE [dbo].[INSERT_Complaint]
	@NameOfAuthor NVARCHAR(250),
	@BuildingNumberOfAuthor INT,
	@ApartmentNumberOfAuthor INT,
	@Description NVARCHAR(2000),
	@BuildingNumberOfComplaint INT,
	@ApartmentNumberOfComplaint INT,
	@ComplaintCategory INT,
	@ComplaintStatus INT
AS
INSERT INTO Complaints
(Id,NameOfAuthor,BuildingNumberOfAuthor,ApartmentNumberOfAuthor, Description, BuildingNumberOfComplaint, ApartmentNumberOfComplaint, ComplaintCategory, ComplaintStatus, DateAdded)
values
(NEWID(), @NameOfAuthor,@BuildingNumberOfAuthor,@ApartmentNumberOfAuthor, @Description, @BuildingNumberOfComplaint, @ApartmentNumberOfComplaint, @ComplaintCategory, 0 , SYSUTCDATETIME())
