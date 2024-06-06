CREATE PROCEDURE [dbo].[UPDATE_ComplaintStatus]
	@Id UNIQUEIDENTIFIER,
	@NewStatus INT
AS
UPDATE Complaints SET  ComplaintStatus = @NewStatus WHERE Id = @Id
