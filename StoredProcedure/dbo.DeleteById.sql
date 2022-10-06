CREATE PROCEDURE [dbo].[DeleteById]
	@taskId int 
AS
	DELETE FROM dbo.Comments where TaskId = @taskId
	DELETE FROM dbo.Task where TaskId = @taskId

