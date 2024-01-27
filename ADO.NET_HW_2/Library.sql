
CREATE DATABASE MyLibrary

USE MyLibrary


CREATE TABLE Books(
[Id] INT PRIMARY KEY IDENTITY,
[Title]NVARCHAR (20) CHECK([Title]<>'') NOT NULL,
[publications]DATE NOT NULL,
[Copies]INT CHECK([Copies]>0) DEFAULT 1 NOT NULL,
[AuthorID]INT NOT NULL,
FOREIGN KEY ([AuthorID]) REFERENCES Author([Id]) 
)


CREATE TABLE Author(
[Id] INT PRIMARY KEY IDENTITY,
[Name]NVARCHAR (20) CHECK([Name]<>'') NOT NULL,
[Lname]NVARCHAR (20) CHECK([Lname]<>'') NOT NULL,
)




CREATE TABLE Reader(
[Id] INT PRIMARY KEY IDENTITY,
[Name]NVARCHAR (20) CHECK([Name]<>'') NOT NULL,
[Lname]NVARCHAR (20) CHECK([Lname]<>'') NOT NULL,
[Phone]NVARCHAR (30) CHECK([Phone]<>'') NOT NULL,
)


CREATE TABLE Rent(
[ReaderID]INT NOT NULL,
[BookID]INT NOT NULL,
CONSTRAINT PK_Reader_Book PRIMARY KEY ([ReaderID],[BookID]),   
FOREIGN KEY ([ReaderID]) REFERENCES   Reader([Id]), 
FOREIGN KEY ([BookID])   REFERENCES   Books([Id]) 
)

CREATE TABLE Refund(
[ReaderID]INT NOT NULL,
[BookID]INT NOT NULL,
CONSTRAINT PK_Refund_Book PRIMARY KEY ([ReaderID],[BookID]),   
FOREIGN KEY ([ReaderID]) REFERENCES   Reader([Id]), 
FOREIGN KEY ([BookID])   REFERENCES   Books([Id]) 
)


INSERT INTO Author([Name],[Lname])VALUES ('Ray','Bradbury')
INSERT INTO Books([Title],[publications],[AuthorID],[Copies])VALUES ('book 1','2023-02-05','1','15'), ('book','2023-02-05','1','30')

INSERT INTO Reader([Name],[Lname],[Phone])VALUES ('Name 1','Lname','85623215'),('Name 2','Lname','85623215'),('Name','Lname','85623215')

INSERT INTO Rent([BookID],[ReaderID])VALUES('1','2') 

INSERT INTO Refund([BookID],[ReaderID])VALUES('1','2') 

-- get info procedure

GO
CREATE PROCEDURE sp_getAUthors
AS
SELECT Author.[Name],Author.[LName] FROM Author

GO
CREATE PROCEDURE sp_getReader
AS
SELECT Reader.[Name],Reader.[Lname],Reader.[Phone] FROM Reader

GO
CREATE PROCEDURE sp_getBook
AS
SELECT Books.[Title],Author.[Name],Author.[LName],Books.[publications] FROM Books JOIN Author ON Books.[AuthorID]=Author.[Id]
--


-- insert procedure

-- reader registration
GO
CREATE PROCEDURE sp_insertReader
@name NVARCHAR(20),
@lName NVARCHAR(20),
@phone NVARCHAR(30)
AS
BEGIN
INSERT INTO Reader([Name],[Lname],[Phone])VALUES (@name,@lName,@phone)
END;

GO
CREATE PROCEDURE sp_updateReader
@name NVARCHAR(20),
@lName NVARCHAR(20),
@phone NVARCHAR(30),
@id INT
AS
BEGIN
UPDATE Reader SET [Name]=@name,[Lname]=@lName,[Phone]=@phone WHERE Reader.[Id]=@id
END;

-- end reader

--insert author
GO
CREATE PROCEDURE sp_insertAuthor
@name NVARCHAR(20),
@lName NVARCHAR(20)
AS
BEGIN
INSERT INTO Author([Name],[Lname])VALUES (@name,@lName)
END;
-- end author


-- insert book
GO
CREATE PROCEDURE sp_insertBook
@title NVARCHAR(20),
@publication DATE,
@copies INT,
@author INT
AS
BEGIN
INSERT INTO Books([Title],[publications],[AuthorID],[Copies])VALUES (@title,@publication,@author,@copies)
END;
-- end book

--book manipulation
GO
CREATE PROCEDURE sp_rentBook
@bookId INT,
@readerId INT
AS
BEGIN
INSERT INTO Rent([BookID],[ReaderID])VALUES(@bookId,@readerId)
END;


GO
CREATE PROCEDURE sp_refundBook
@bookId INT,
@readerId INT
AS
BEGIN
INSERT INTO Refund([BookID],[ReaderID])VALUES(@bookId,@readerId)
END;
--

--






GO
ALTER TRIGGER rentBook
ON Rent
FOR INSERT
AS
BEGIN
DECLARE @countBook INT,@id INT
SELECT @id=Books.[Id] FROM Books JOIN Rent ON Books.[Id]=Rent.BookID
SELECT @countBook= Books.[Copies] FROM Books JOIN Rent ON Books.[Id]=Rent.BookID
IF @countBook>=1
BEGIN
UPDATE Books SET [Copies]-=1 WHERE Books.[Id]=@id
END;
ELSE
BEGIN
ROLLBACK
END;
END;



GO
CREATE TRIGGER refundBook
ON Refund
FOR INSERT
AS
BEGIN
DECLARE @readerId INT,@id INT
SELECT @readerId = Reader.[Id] FROM Reader JOIN  Refund ON Reader.Id=Refund.ReaderID
SELECT @id=Books.[Id] FROM Books JOIN Rent ON Books.[Id]=Rent.BookID
UPDATE Books SET [Copies]+=1 WHERE Books.[Id]=@id
DELETE Rent WHERE Rent.[ReaderID]=@readerId AND Rent.[BookID]=@id
SELECT @readerId AS 'reader Id', @id AS 'Book Id' ,Books.Copies,Books.AuthorID FROM Books 
END;