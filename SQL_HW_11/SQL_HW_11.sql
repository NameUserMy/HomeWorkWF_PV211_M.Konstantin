CREATE DATABASE MyDatabase

USE MyDatabase


CREATE TABLE [Files] (
    [Id] INT IDENTITY PRIMARY KEY,
    [FileName] NVARCHAR(50),
    [ParentFolderID] INT
);

INSERT INTO Files VALUES ('FolderA', NULL),
('File1.txt', 1), ('File2.txt', 1), ('FolderB', NULL),
('File3.txt', 4), ('File4.txt', 4), ('FolderC', NULL),
('File5.txt', 7);

WITH tree
AS
(
SELECT  Files.[FileName],[ParentFolderID]  FROM Files WHERE [ParentFolderID] IS NULL
UNION ALL
SELECT  Files.[FileName],Files.[ParentFolderID] FROM Files 
)SELECT * FROM tree

--additional tasks
GO
ALTER FUNCTION dbo.closerToZero(@inNumber NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
DECLARE @number TABLE(result NVARCHAR(MAX))
DECLARE @test NVARCHAR(MAX)
INSERT INTO @number  SELECT top(2)  value FROM STRING_SPLIT(@inNumber, ' ') order by value
IF(SELECT result FROM @number GROUP BY result HAVING COUNT(result)>1)!=0
BEGIN
SELECT top(1) @test = result FROM @number
RETURN @test + '+'
END;
ELSE
SELECT TOP(1) @test= result FROM @number
RETURN @test
END;

SELECT  dbo.closerToZero('2 2 25') AS 'Result'


CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
[Salary] MONEY CHECK([Salary]>0) NOT NULL,
[Department] NVARCHAR(20)CHECK([Department]<>'') NOT NULL,
)

INSERT INTO Employees ([Name],[Salary],[Department])VALUES ('first','4990','dep 1'),
('Second','5000','dep 2'),('Third','17000','dep 3'),('Fourth','8000','dep 4')

GO
ALTER FUNCTION dbo.employeesLevel()
RETURNS TABLE
AS
RETURN(
WITH  recEvenCTE
AS
(
SELECT Employees.[Name],Employees.Salary FROM Employees 
)
SELECT recEvenCTE.[Name], recEvenCTE.[Salary],'Low' AS 'Level' FROM recEvenCTE  WHERE recEvenCTE.Salary<5000 
UNION
SELECT recEvenCTE.[Name], recEvenCTE.[Salary],'Middle' AS 'Level' FROM recEvenCTE  
WHERE recEvenCTE.Salary>=5000 and recEvenCTE.Salary<=15000
UNION
SELECT recEvenCTE.[Name], recEvenCTE.[Salary],'High' AS 'Level' FROM recEvenCTE  
WHERE recEvenCTE.Salary>15000
)

SELECT * FROM dbo.employeesLevel()


CREATE TABLE [Categories] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
)

CREATE TABLE [Products] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
    [Price] DECIMAL(10, 2) CHECK([Price]>0) NOT NULL,
	[CategoryID] INT NOT NULL,
	FOREIGN KEY ([CategoryID]) REFERENCES [Categories]([id])
)

INSERT INTO Categories VALUES ('First'),('Second')

INSERT INTO Products([Name],[Price],[CategoryID])VALUES
('Name 1','25','1'),('Name 2','25','1'),('Name 3','25','1'),
('Name 3','25','2'),('Name 4','25','2')
--
GO
CREATE VIEW ProductCountInCategories
AS
SELECT Categories.[Name], COUNT(Products.Name) AS 'Count products in category' FROM Categories JOIN Products ON Categories.[Id]=Products.[CategoryID]
GROUP BY Categories.[Name]

SELECT * FROM ProductCountInCategories

GO
ALTER VIEW ProductCountInCategories
AS
SELECT Categories.[Id], Categories.[Name], COUNT(Products.Name) AS 'Count products in category' FROM Categories JOIN Products ON Categories.[Id]=Products.[CategoryID]
GROUP BY Categories.[Name],Categories.[Id]

SELECT * FROM ProductCountInCategories


GO
CREATE VIEW ProductUppdate
AS
SELECT [Id],[Name],[Price] FROM Products

SELECT * FROM ProductUppdate

UPDATE ProductUppdate SET [Price]+='75' WHERE [Id]='3'

SELECT * FROM Products