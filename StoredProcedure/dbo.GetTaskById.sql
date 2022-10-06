CREATE PROCEDURE [dbo].[GetTaskById]
	@TaskId int
AS
	Select ts.TaskStatusName,tt.TaskTypeName, c.Comment,ct.CommentTypeName,t.TaskDescription, CONCAT(u.FirstName,' ',u.LastName) as AssignedTo,t.NextActionDate FROM dbo.Task t
         join dbo.TaskStatus ts
		 on t.TaskStatus = ts.TaskStatusID
		 join dbo.TaskType tt
		 on t.TaskType = tt.TaskTypeID
		 join dbo.Comments c
		 on c.TaskId = t.TaskID
		 join dbo.users u
		 on t.AssignedTo = u.UserID
		 join dbo.CommentType ct
		 on c.CommentType = ct.CommentTypeID
		 where t.TaskID = @TaskId

