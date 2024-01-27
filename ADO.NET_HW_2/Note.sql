CREATE DATABASE ToDoList

USE ToDoList


CREATE TABLE [User](
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR (20) CHECK([Name]<>'') NOT NULL
)

CREATE TABLE [Note](
[Id] INT PRIMARY KEY IDENTITY,
[UserId]INT NOT NULL,
[Title] NVARCHAR (20) CHECK([Title]<>'') NOT NULL,
[Description] NVARCHAR (200)  NULL,
[CreateDate] DATE DEFAULT (GETDATE()) NOT NULL 
FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
 )

 GO
 CREATE PROCEDURE sp_insertUser
 @name NVARCHAR(20)
 AS
 BEGIN
 INSERT INTO [User] VALUES (@name)
 END;

 GO
 CREATE PROCEDURE sp_insertNote
 @title NVARCHAR(20),
 @description NVARCHAR (200),
 @userId INT
 AS
 BEGIN
 INSERT INTO [Note]([Title],[Description],[UserId]) VALUES (@title,@description,@userId)
 END;


  GO
 CREATE PROCEDURE sp_deleteNote
 @userId INT
 AS
 BEGIN
 DELETE Note WHERE UserId=@userId
 END;

 GO
 CREATE PROCEDURE sp_selectNote
 @userId INT
 AS
 BEGIN
 SELECT Note.Title,Note.[Description] FROM Note WHERE Note.UserId=@userId
 END;


 GO
 CREATE PROCEDURE sp_UpdateNote
 @title NVARCHAR(20),
 @description NVARCHAR (200),
 @userId INT,
 @noteId INT
 AS
 BEGIN
 UPDATE [Note] SET [Title]=@title,[Description]=@description WHERE Note.UserId=@userId AND Note.[Id]=@noteId
 END;