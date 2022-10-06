CREATE PROCEDURE [dbo].[AddTask]
	@createdDate datetime,
	@requiredBy datetime,
	@taskDescription varchar(max),
	@taskStatus int,
	@taskType int,
	@assignedTo int,
	@comment varchar(max),
	@dateAdded datetime,
	@commentType int
	
AS
    DECLARE @taskId int
    INSERT INTO dbo.Task(CreatedDate,RequiredBy,TaskDescription,TaskStatus,TaskType,AssignedTo)
	VALUES(@createdDate,@requiredBy,@taskDescription,@taskStatus,@taskType,@assignedTo)
	SET @taskId = (SELECT max(TaskID) FROM dbo.Task)

	INSERT INTO dbo.Comments(DateAdded,Comment,CommentType,TaskId)
	Values(@DateAdded,@comment,@commentType,@taskId)

