CREATE DATABASE Sales

USE Sales



CREATE TABLE [Users] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(30)CHECK([Name]<>'')
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] NVARCHAR(50)CHECK([FirstName]<>'') NOT NULL,
[LaststName] NVARCHAR(50)CHECK([LaststName]<>'') NOT NULL,
[Position] NVARCHAR(50)CHECK([Position]<>'') NOT NULL,
)



CREATE TABLE [Products] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
    [Price] DECIMAL(10, 2) CHECK([Price]>0) NOT NULL,
)

CREATE TABLE [Orders] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId]  INT CHECK([UserId]>0) NOT NULL,
	[EmployeesId]  INT CHECK([EmployeesId]>0) NOT NULL,
    [OrderDate] DATE CHECK([OrderDate]<>'') NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([EmployeesId]) REFERENCES [Employees]([Id])
)

CREATE TABLE [OrderDetails] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [OrderId] INT CHECK([OrderId]>0) NOT NULL,
    [ProductId] INT CHECK([ProductId]>0) NOT NULL,
    [Quantity] INT CHECK([Quantity]>0)  NOT NULL,
    FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
)


--Fill Info

INSERT INTO [Employees]([FirstName],[LaststName],[Position])VALUES('Podjer','Any','Salesman'),
('Buble','Sullivan','Salesman 2'),('Greg','Any','Salesman'),
('Mike','Vazovsky','Salesman 1'),('James P','Sullivan','Salesman 2')



INSERT INTO [Products] VALUES ('Sofa','30.22'),('Closet','10.25'),('Table','25.70'),
('Bed','150.55'),('Chair','10'),('Ñhildren chair','10'),('Buble Gum','0.30'),('Bread','1.0'),
('Some product','35.44'),('Any product','75')

INSERT INTO [Users] VALUES('Anna'), ('Valeriya'),('Greg'),('John'),('Bob'),('Helena'),
('Valeriya'),('Anna')
-- Greg
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('1',GETDATE(),'3'),
('2',GETDATE(),'3')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','1','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','4','1')
--

--John
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('2',GETDATE(),'3')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','7','10')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','5','4')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','3','1')
--

-- Bob
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('3',GETDATE(),'2')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','4','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','2','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','6','7')
--Valeriya
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('5',CONVERT(DATE, '2022-05-08'),'2')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','7','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','8','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','9','1')


--Full backup
BACKUP DATABASE Sales
TO DISK = 'H:\Backups\Sales.bak'
WITH INIT;
--

INSERT INTO [Users] VALUES('Shifu')
UPDATE Products SET [Price]+='150' WHERE [Id]='1'
DELETE Employees WHERE Employees.[Id]='5'

-- Differential backup
BACKUP DATABASE Sales
TO DISK = 'H:\Backups\Sales_DifferentialBackup.bak'
WITH DIFFERENTIAL;
--

UPDATE Products SET [Price]-='150' WHERE [Id]='1'
DELETE Users WHERE Users.[Name]='Shifu'


ALTER DATABASE Sales
SET RECOVERY FULL;

--Full backup before journal
BACKUP DATABASE Sales
TO DISK = 'H:\Backups\Sales_before_journal.bak'
WITH INIT;
--

--Backup journal
BACKUP LOG Sales
TO DISK = 'H:\Backups\Sales_LogBackup.trn'
--

ALTER DATABASE Sales
SET RECOVERY SIMPLE;

--Full recovery
USE master;

IF DB_ID('Sales') IS NOT NULL
    DROP DATABASE Sales;

RESTORE DATABASE Sales
FROM DISK = 'H:\Backups\Sales.bak'
WITH REPLACE, RECOVERY;
--


--Full and Differential  recovery
USE master;


IF DB_ID('Sales') IS NOT NULL
    DROP DATABASE Sales;


RESTORE DATABASE Sales
FROM DISK = 'H:\Backups\Sales.bak'
WITH REPLACE, NORECOVERY; 

RESTORE DATABASE Sales
FROM DISK = 'H:\Backups\Sales_DifferentialBackup.bak'
WITH NORECOVERY; 

--

--Full, Differential and journal recovery

USE master;

IF DB_ID('Sales') IS NOT NULL
    DROP DATABASE Sales;

RESTORE DATABASE Sales
FROM DISK = 'H:\Backups\Sales.bak'
WITH REPLACE, NORECOVERY; 

RESTORE DATABASE Sales
FROM DISK = 'H:\Backups\Sales_DifferentialBackup.bak'
WITH NORECOVERY;

RESTORE LOG Sales
FROM DISK = 'H:\Backups\Sales_LogBackup.trn'
WITH RECOVERY;
--

ALTER DATABASE Sales
SET RECOVERY SIMPLE;


--- task
use Sales

CREATE TABLE Departments(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
)

CREATE TABLE Hobby(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
)

CREATE TABLE Workers(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20),
[Salary]MONEY,
[DepartmentId]INT NOT NULL,
[HobbyId] INT NULL
FOREIGN KEY ([DepartmentId]) REFERENCES Departments ([Id]),
FOREIGN KEY ([HobbyId]) REFERENCES Hobby ([Id])
)



INSERT INTO Departments([Name])VALUES('Department 1'),('Department 2'),('Department 3')

INSERT INTO Hobby([Name]) VALUES ('Hobby 1'),('Hobby 2'),('Hobby 3'),('GAMES')

INSERT INTO Workers([Name],[DepartmentId],[Salary],[HobbyId])VALUES
('Veruka','1','80000','4'),('Bob','1','80000','4'),('Greg','3','12000',NULL),
('Helena','3','7000','3'),('John','2','5000','3')

GO
CREATE VIEW getDepartmentsFromW
AS
SELECT Workers.[Name],Departments.[Name] AS 'Departments' FROM Workers JOIN Departments ON Workers.[DepartmentId]=Departments.[Id]

SELECT * FROM getDepartmentsFromW

DECLARE @InfoHoby TABLE (WorkersNmae NVARCHAR(20),Hoby NVARCHAR(20))
INSERT INTO @InfoHoby SELECT Workers.[Name], Hobby.[Name] FROM Workers  JOIN Hobby ON Workers.[HobbyId]=Hobby.[Id] 
SELECT * FROM @InfoHoby

DECLARE @Info TABLE (WorkersNmae NVARCHAR(20),Hoby NVARCHAR(20))
INSERT INTO @Info SELECT Workers.[Name], Hobby.[Name] FROM Workers LEFT JOIN Hobby ON Workers.[HobbyId]=Hobby.[Id]  
SELECT * FROM @Info


SELECT Workers.[Name],Hobby.[Name] AS 'Hoby' INTO  #GamesHoby  FROM Workers  JOIN Hobby ON Workers.[HobbyId]=Hobby.[Id] 
WHERE Workers.Salary <90000 AND Hobby.[Name]='GAMES' 

SELECT * FROM #GamesHoby


CREATE TABLE [Productsgoods] (
    [ProductID] INT IDENTITY PRIMARY KEY,
    [ProductName] VARCHAR(50),
    [Price] DECIMAL(10, 2)
);

CREATE TABLE [Ordersgoods] (
    [OrderID] INT IDENTITY PRIMARY KEY,
    [OrderDate] DATE,
    [CustomerName] VARCHAR(50)
);

CREATE TABLE [OrderDetailsgoods] (
    [OrderID] INT,
    [ProductID] INT REFERENCES [Productsgoods]([ProductID]),
    [Quantity] INT REFERENCES [Ordersgoods]([OrderID])
);


INSERT INTO Productsgoods([ProductName],[Price])VALUES 
('Product 1',25),('Product 2',300),('Product 3',880)

INSERT INTO Ordersgoods([CustomerName],[OrderDate])VALUES
('Bob',GETDATE()),('Gretta',GETDATE())

INSERT INTO OrderDetailsgoods([OrderID],[ProductID],[Quantity])VALUES
('1','2','1'),('1','1','1'),('2','2','2'),('2','3','2')

GO
CREATE VIEW getInfoMax
AS
SELECT Productsgoods.[ProductName],OrderDetailsgoods.[ProductID], COUNT(OrderDetailsgoods.[ProductID])AS 'Count product' FROM Productsgoods 
JOIN OrderDetailsgoods ON Productsgoods.[ProductID]=OrderDetailsgoods.[ProductID] 
GROUP BY Productsgoods.[ProductName],OrderDetailsgoods.[ProductID]

SELECT * FROM getInfoMax



CREATE DATABASE mySales
USE mySales

--Create table([Users],[Orders],[OrderDetails],[Products],)



CREATE TABLE [Users] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(30)CHECK([Name]<>'')
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] NVARCHAR(50)CHECK([FirstName]<>'') NOT NULL,
[LaststName] NVARCHAR(50)CHECK([LaststName]<>'') NOT NULL,
[Position] NVARCHAR(50)CHECK([Position]<>'') NOT NULL,
)



CREATE TABLE [Products] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
    [Price] DECIMAL(10, 2) CHECK([Price]>0) NOT NULL,
)

CREATE TABLE [Orders] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId]  INT CHECK([UserId]>0) NOT NULL,
	[EmployeesId]  INT CHECK([EmployeesId]>0) NOT NULL,
    [OrderDate] DATE CHECK([OrderDate]<>'') NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
	FOREIGN KEY ([EmployeesId]) REFERENCES [Employees]([Id])
)

CREATE TABLE [OrderDetails] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [OrderId] INT CHECK([OrderId]>0) NOT NULL,
    [ProductId] INT CHECK([ProductId]>0) NOT NULL,
    [Quantity] INT CHECK([Quantity]>0)  NOT NULL,
    FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
)


--Fill Info

INSERT INTO [Employees]([FirstName],[LaststName],[Position])VALUES('Podjer','Any','Salesman'),('Buble','Sullivan','Salesman 2'),('Greg','Any','Salesman'),
('Mike','Vazovsky','Salesman 1'),('James P','Sullivan','Salesman 2')



INSERT INTO [Products] VALUES ('Sofa','30.22'),('Closet','10.25'),('Table','25.70'),
('Bed','150.55'),('Chair','10'),('Ñhildren chair','10'),('Buble Gum','0.30'),('Bread','1.0'),
('Some product','35.44'),('Any product','75')

INSERT INTO [Users] VALUES('Anna'), ('Valeriya'),('Greg'),('John'),('Bob'),('Helena'),
('Valeriya'),('Anna')
-- Greg
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('1',GETDATE(),'3'),
('2',GETDATE(),'3')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','1','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','4','1')
--

--John
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('2',GETDATE(),'3')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','7','10')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','5','4')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','3','1')
--

-- Bob
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('3',GETDATE(),'2')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','4','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','2','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','6','7')
--Valeriya
INSERT INTO [Orders]([UserId],[OrderDate],[EmployeesId]) VALUES ('5',CONVERT(DATE, '2022-05-08'),'2')

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','7','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','8','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('5','9','1')
--

--1) 
GO
CREATE FUNCTION dbo.minSumOrderFromEmployees(@firstName NVARCHAR(20))
RETURNS MONEY
AS
BEGIN
DECLARE @sum MONEY
SELECT TOP(1) @sum= SUM(Products.[Price]*OrderDetails.[Quantity]) FROM Employees JOIN Orders ON Employees.[Id]=Orders.[EmployeesId]
JOIN OrderDetails ON OrderDetails.OrderId=Orders.[Id] JOIN Products ON Products.[Id]=OrderDetails.[ProductId]
WHERE Employees.[FirstName]=@firstName GROUP BY Orders.[Id] ORDER BY SUM(Products.[Price]*OrderDetails.[Quantity])
RETURN @sum
END;

SELECT dbo.minSumOrderFromEmployees('James P') AS 'Min sum order'

--2) 
GO
CREATE FUNCTION dbo.minSumOrderFromUser(@firstName NVARCHAR(20))
RETURNS MONEY
AS
BEGIN
DECLARE @sum MONEY
SELECT TOP(1) @sum=SUM(Products.[Price]*OrderDetails.[Quantity]) FROM Users JOIN Orders ON Users.[Id]=Orders.[UserId]
JOIN OrderDetails ON OrderDetails.OrderId=Orders.[Id] JOIN Products ON Products.[Id]=OrderDetails.[ProductId]
WHERE Users.[Name]=@firstName GROUP BY OrderDetails.[Id] ORDER BY SUM(Products.[Price]*OrderDetails.[Quantity])
RETURN @sum
END;

SELECT dbo.minSumOrderFromUser('John') AS 'Min Sum spent user'

--3) 
GO
CREATE FUNCTION dbo.minOrderOnDate(@date DATE)
RETURNS MONEY
AS
BEGIN
DECLARE @sum MONEY
SELECT @sum=SUM(Products.[Price]*OrderDetails.[Quantity]) FROM  Orders JOIN OrderDetails ON OrderDetails.OrderId=Orders.[Id] 
JOIN Products ON Products.[Id]=OrderDetails.[ProductId] WHERE Orders.[OrderDate]=CONVERT(DATE,@date)
RETURN @sum
END;

SELECT dbo.minOrderOnDate('2022-05-08') AS 'Sum on date'

--5) 
GO
CREATE FUNCTION dbo.infoProduct(@productName NVARCHAR(50))
RETURNS TABLE
AS
RETURN 
SELECT * FROM OrderDetails WHERE OrderDetails.ProductId=(SELECT Products.Id FROM Products WHERE Products.Name=@productName)

SELECT * FROM dbo.infoProduct('Buble Gum')

--6) 

GO
CREATE FUNCTION dbo.info()
RETURNS TABLE
AS
RETURN (WITH trtCTE
AS
(
SELECT  Employees.[LaststName] FROM Employees GROUP BY Employees.[LaststName] HAVING Count(Employees.[LaststName])>1
)
SELECT * FROM trtCTE 
)
SELECT * FROM dbo.info()
--7)

GO
CREATE FUNCTION dbo.infoUser()
RETURNS TABLE
AS
RETURN (
WITH trtCTE
AS
(
SELECT  Users.[Name] FROM Users GROUP BY Users.[Name] HAVING Count(Users.[Name])>1
)
SELECT * FROM trtCTE 
)

SELECT * FROM dbo.infoUser()

--8)

GO
CREATE FUNCTION dbo.infoUserEmpl()
RETURNS TABLE
AS
RETURN (
WITH trtCTE
AS
(
SELECT  Users.[Name] FROM Users GROUP BY Users.[Name] HAVING Count(Users.[Name])>1
UNION  
SELECT  Employees.[LaststName] FROM Employees GROUP BY Employees.[LaststName] HAVING Count(Employees.[LaststName])>1
)
SELECT * FROM trtCTE 
)

SELECT * FROM dbo.infoUserEmpl()
--