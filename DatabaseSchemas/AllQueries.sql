--Task Status
--1 Not Started
--2 In Progress
--3 Completed
--4 Cancelled

--Task Type
--1 User Instruction
--2 Technical Info

--Comment Type
--1 New
--2 Update
create table dbo.TaskStatus(
TaskStatusID int identity(1,1) Primary Key,
TaskStatusName varchar(20) not null
)

--INSERT INTO dbo.TaskStatus(TaskStatusName)
--VALUES ('Completed');

--Select * from dbo.TaskStatus

create table dbo.TaskType(
TaskTypeID int identity(1,1) Primary Key,
TaskTypeName varchar(20) not null
)
--INSERT INTO dbo.TaskType(TaskTypeName)
--VALUES ('Technical Info');

--Select * from dbo.TaskType

create table dbo.users(
UserID int identity(1,1) Primary Key,
FirstName varchar(50) not null,
MiddleName varchar(50),
LastName varchar(50) not null
)

--INSERT INTO dbo.users(FirstName,LastName)
--VALUES ('Elia','Martel');

--Select * from users


Create Table dbo.CommentType(
CommentTypeID int identity(1,1) Primary Key,
CommentTypeName varchar(20) not null
)

--INSERT INTO dbo.CommentType(CommentTypeName)
--VALUES ('Update');


Create Table dbo.Comments(
CommentID int identity(1,1) Primary Key,
DateAdded DateTime,
Comment varchar(max),
CommentType int foreign key references CommentType(CommentTypeID),
ReminderDate DateTime,
TaskId int foreign key references Task(TaskID)
)
--drop table dbo.Comments
--INSERT INTO dbo.Comments(DateAdded,Comment,CommentType,ReminderDate,TaskId)
--VALUES ('20221025 21:19:05 PM','Comment 3',2,'20221110 09:30:00 AM',4)

--2	2022-06-18 10:34:09.000	Comment 1	1	2022-07-18 09:30:00.000
--3	2022-08-22 11:29:01.000	Comment 2	1	2022-10-18 09:30:00.000
--4	2022-09-26 00:29:54.000	Comment 3	2	2023-01-18 08:30:00.000

--Select * from Comments

Create Table dbo.Task(
TaskID int identity(1,1) Primary Key,
CreatedDate DateTime,
RequiredBy DateTime,
TaskDescription varchar(max),
TaskStatus int foreign key references TaskStatus(TaskStatusID),
TaskType int foreign key references TaskType(TaskTypeID),
AssignedTo int foreign key references users(UserID),
NextActionDate DateTime
)

--SELECT max(TaskID) FROM dbo.Task
--drop table dbo.Task
--select * from dbo.Task
--2	2022-06-26 00:29:54.000	2022-07-22 07:00:00.000	Task description 2	2	2	2	2022-07-18 09:30:00.000	2
--3	2022-09-07 00:29:54.000	2022-10-22 07:00:00.000	Task description 3	2	2	3	2022-10-18 09:30:00.000	3
--INSERT INTO dbo.Task(CreatedDate,RequiredBy,TaskDescription,TaskStatus,TaskType,AssignedTo,NextActionDate)
--VALUES ('20221102 15:39:09 PM','20221120 07:00:00 AM','Task description 5',1,1,2,'20221110 09:30:00 AM')


		 



