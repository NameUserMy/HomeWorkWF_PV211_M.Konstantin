
BEGIN --First task
CREATE DATABASE forTrigger
USE forTrigger
BEGIN -- Ccreate TABLE (Users,Regestration)

CREATE TABLE Users(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) CHECK([Name]<>'') NOT NULL
)

CREATE TABLE Regestration(
[Id] INT PRIMARY KEY IDENTITY,
[UserName] NVARCHAR(30) CHECK([UserName]<>'') NOT NULL,
[Email] NVARCHAR(30) CHECK([Email]<>'') NOT NULL,

)
END;

BEGIN--Fill info

INSERT INTO Users VALUES('VASYA'),('Petya')

INSERT INTO Regestration ([UserName],[Email])VALUES('VASYA','Some @email'),('Petya','Petya @email')

DELETE FROM Users WHERE Id=2

END;

END;
--Create Trigger
GO
CREATE TRIGGER deleteInfo
ON Users
FOR DELETE
AS
BEGIN
DELETE FROM Regestration  WHERE [Id]=(SELECT id FROM deleted ) 
END;

SELECT * FROM Users

SELECT * FROM Regestration
--end trigger





BEGIN --Scond Task


CREATE DATABASE SportShop

USE SportShop

BEGIN--Create table(Employees,Products,Ñustomers,aboutSales,ÑustomersHistory)

CREATE TABLE Ñustomers(
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(30)CHECK([FirstName]<>'') NOT NULL,
    [LastName]  NVARCHAR(30)CHECK([LastName]<>'') NOT NULL,
    [Phone]  NVARCHAR(30)CHECK([Phone]<>'') NOT NULL,
    [Email] NVARCHAR (50)CHECK([Email]<>'') NOT NULL,
    [Sex] NCHAR  CHECK([Sex]<>'') NOT NULL,
	[IsSubscribe] BIT DEFAULT 0  NOT NULL,
	[ProcentDiscount]INT DEFAULT 0 CHECK([ProcentDiscount]>=0) NOT NULL,
	[RegestrationDate] DATE
)

CREATE TABLE Employees (
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(30)CHECK([FirstName]<>'') NOT NULL,
    [LastName]  NVARCHAR(30)CHECK([LastName]<>'') NOT NULL,
    [JobTitle] NVARCHAR (30)CHECK([JobTitle]<>'') NOT NULL,
    [HireDate] DATE CHECK([HireDate]<>'') NOT NULL,
	[Sex] NCHAR  CHECK([Sex]<>'') NOT NULL,
	[Salary] MONEY CHECK([Salary]>0) NOT NULL
)

CREATE TABLE Products(
[Id] INT PRIMARY KEY IDENTITY,
[Title] NVARCHAR(50)CHECK([Title]<>'') NOT NULL,
[type] INT NOT NULL,
[InStock] INT CHECK([InStock]>=0) NOT NULL,
[primeCost] MONEY CHECK([primeCost]>0) NOT NULL,
[Manufacturer] NVARCHAR(50)CHECK([Manufacturer]<>'') NOT NULL,
[Price] MONEY CHECK([Price]>0) NOT NULL,
)

CREATE TABLE aboutSales(
[Id] INT PRIMARY KEY IDENTITY,
[Quantity]INT CHECK([Quantity]>0) NOT NULL,
[DateOfSale] DATE NOT NULL,
[EmployeeId]INT NOT NULL,
[ÑustomerId]INT NOT NULL,
[ProductsId] INT NOT NULL,
FOREIGN KEY (EmployeeId) REFERENCES Employees ([Id]),
FOREIGN KEY ([ProductsId]) REFERENCES Products ([Id]),
FOREIGN KEY ([ÑustomerId]) REFERENCES Ñustomers ([Id])
)

CREATE TABLE ÑustomersHistory(
    [Id] INT PRIMARY KEY IDENTITY,
    [Title] NVARCHAR(50)CHECK([Title]<>'') NOT NULL,
	[Price] MONEY CHECK([Price]>0) NOT NULL,
	[Quantity]INT CHECK([Quantity]>0) NOT NULL,
	[Date] DATE NOT NULL,
 	[ÑustomerId] INT NOT NULL UNIQUE REFERENCES Ñustomers([Id])
)

CREATE TABLE EmployeesHistory (
    [Id] INT NOT NULL,
    [FirstName] NVARCHAR(30)CHECK([FirstName]<>'') NOT NULL,
    [LastName]  NVARCHAR(30)CHECK([LastName]<>'') NOT NULL,
    [JobTitle] NVARCHAR (30)CHECK([JobTitle]<>'') NOT NULL,
    [HireDate] DATE CHECK([HireDate]<>'') NOT NULL,
	[Sex] NCHAR  CHECK([Sex]<>'') NOT NULL,
	[Salary] MONEY CHECK([Salary]>0) NOT NULL,
	
)





END;

BEGIN -- fill info

INSERT INTO Products ([Title],[Manufacturer],[primeCost],[Price],[type],[InStock])VALUES ('Some product','Some manufacture 1','75','110','1','8'),
('Some product 1','Some manufacture 2','33','75','1','5'),('Some product','Some manufacture 3','33','75','2','5'),('Some product','Some manufacture 4','33','75','2','0')


INSERT INTO Employees([FirstName],[LastName],[Sex],[JobTitle],[Salary],[HireDate]) VALUES('Employee 1','Employee 1','M','seller','100',GETDATE()),
('Employee 2','Employee 2','W','seller','150',GETDATE()),('Employee 3','Employee 3','W','seller','100',GETDATE())




INSERT INTO Ñustomers([FirstName],[LastName],[Sex],[Phone],[Email],[RegestrationDate],[ProcentDiscount])
VALUES('Some Name','Some LastName','M','Some Phone','SOME EMAIL','2000-01-01','0'),
('Some Name1','Some LastName1','M','Some Phone1','SOME EMAIL1','2002-10-30','0'),('Some Name3','Some LastName3','W','Some Phone3','SOME EMAIL3','2005-10-30','0'),
('Some Name2','Some LastName2','M','Some Phone2','SOME EMAIL2','2005-11-30','0'),('Some Name4','Some LastName4','M','Some Phone4','SOME EMAIL4','2008-10-30','0'),
('Some Name5','Some LastName5','W','Some Phone5','SOME EMAIL5','2008-11-30','0'),('Some Name6','Some LastName6','M','Some Phone6','SOME EMAIL4','2008-10-30','0')

INSERT INTO aboutSales([ProductsId],[Quantity],[EmployeeId],[DateOfSale],[ÑustomerId])VALUES('1','10','2',GETDATE(),'1'),
('2','20','2',GETDATE(),'3'),('3','10','1',GETDATE(),'4'),('1','3','3',GETDATE(),'2')

END;

INSERT INTO Employees([FirstName],[LastName],[Sex],[JobTitle],[Salary],[HireDate]) VALUES('Employee 1','Employee 1','M','seller','100',GETDATE())

DELETE Employees WHERE [Id]=1

INSERT INTO Products ([Title],[Manufacturer],[primeCost],[Price],[type],[InStock])VALUES ('Some product 1','Some manufacture 2','33','75','1','5')


END;



--Create triggers

GO
--1
CREATE TRIGGER addProduct
ON Products
INSTEAD OF INSERT
AS
BEGIN
 IF EXISTS (SELECT [Title] FROM Products WHERE Products.[Title] = (SELECT  [Title] FROM inserted))
 BEGIN
  UPDATE Products SET [InStock]+=1 WHERE [Title]=(SELECT  [Title] FROM inserted)
 END;
 ELSE
 BEGIN
 INSERT INTO Products ([Title],[Manufacturer],[primeCost],[Price],[type],[InStock])VALUES ((SELECT  [Title] FROM inserted),
 (SELECT  [Manufacturer] FROM inserted),(SELECT  [primeCost] FROM inserted),(SELECT  [Price] FROM inserted),(SELECT  [type] FROM inserted),(SELECT  [InStock] FROM inserted))
 END;
 END;
 --2
 GO
 CREATE TRIGGER dismissalEmployee
 ON Employees
 AFTER DELETE
 AS
 BEGIN
  INSERT INTO EmployeesHistory  ([Id] ,[FirstName],[LastName],[Job title],[HireDate],[Sex],[Salary])
 SELECT [Id] ,[FirstName],[LastName],[Job title],[HireDate],[Sex],[Salary] FROM deleted 
 END;
 --3
 GO 
 CREATE TRIGGER limitHiringSeller
 ON Employees
 FOR INSERT
 AS
 BEGIN
 DECLARE @MaxSeller INT
 SELECT @MaxSeller=COUNT([JobTitle]) FROM Employees WHERE [JobTitle]='seller'
   IF(@MaxSeller>4)
   BEGIN
   PRINT 'Employee limit reached'
   ROLLBACK 
   END;
   ELSE
   BEGIN
   Print 'Employee added'
   END;
 END;

--End create triggers



BEGIN--Music collection

CREATE DATABASE MusicCollection
USE MusicCollection

--Create Tabble
CREATE TABLE Author(
[Id] INT PRIMARY KEY IDENTITY,
[Name]NVARCHAR(30) CHECK([Name]<>'')NOT NULL,
[Genre]NVARCHAR(30) CHECK([Genre]<>'')NOT NULL,
)

CREATE TABLE Album(
[Id] INT PRIMARY KEY IDENTITY,
[Title]NVARCHAR(30) CHECK([Title]<>'')NOT NULL,
[TrackCount]INT NOT NULL,
[AutorId]INT NOT NULL,
FOREIGN KEY([AutorId])REFERENCES Author(Id),
)

CREATE TABLE Stock(
[Id] INT PRIMARY KEY IDENTITY,
[InStock] INT  DEFAULT 0 CHECK([InStock]>=0)  NOT NULL,
[AlbumId] INT NOT NULL
FOREIGN KEY([AlbumId])REFERENCES Album(Id)
)
CREATE TABLE Customer(
[Id] INT PRIMARY KEY IDENTITY,
[Name]NVARCHAR(30) CHECK([Name]<>'')NOT NULL,
[Email]NVARCHAR(30) CHECK([Email]<>'')NOT NULL,
)


CREATE TABLE Sales(
[Id] INT PRIMARY KEY IDENTITY,
[Price] MONEY CHECK([Price]>0),
[Discount] INT DEFAULT 0 CHECK([Discount]>=0)  NOT NULL,
[Quantity] INT  DEFAULT 0 CHECK([Quantity]>0)  NOT NULL,
[CustomerId] INT NOT NULL,
[AlbumId] INT NOT NULL,
FOREIGN KEY([AlbumId])REFERENCES Album(Id),
FOREIGN KEY([CustomerId])REFERENCES Customer(Id)
)



CREATE TABLE historySales(
[Id] INT PRIMARY KEY IDENTITY,
[Price] MONEY CHECK([Price]>0),
[Discount] INT DEFAULT 0 CHECK([Discount]>=0)  NOT NULL,
[AlbumId] INT NOT NULL
)
CREATE TABLE Archive(
[AlbumId] INT NOT NULL
)

--End table


--Fiil info

INSERT INTO Customer ([Name],[Email])VALUES ('Some Name','email')


SELECT * FROM Customer


INSERT INTO Author([Name],[Genre])VALUES ('SOME AVTOR','Rock'),('SOME AVTOR 1','HArd Rock'),
('SOME AVTOR 2','blues'),('SOME AVTOR 3','classic'),('SOME AVTOR 4','Pank Rock')

INSERT INTO Album([Title],[TrackCount],[AutorId])VALUES('Some Album','10','1'),('Some Album 1','10','2')
--end fiil


INSERT INTO Stock([AlbumId],[InStock])VALUES ('1','10'),('2','20')
SELECT * FROM historySales
SELECT * FROM Stock

INSERT INTO Sales([AlbumId],[Quantity],[Discount],[Price],[CustomerId])VALUES ('2','20','0','25','1')
SELECt *FROM Archive

DELETE Customer WHERE Customer.Id=1
SELECt *FROM Customer




END;


--Create trigger

GO
CREATE TRIGGER checkCustomer
ON Customer
INSTEAD OF INSERT
AS
BEGIN
IF EXISTS (SELECT [Name],[Email] FROM Customer WHERE Customer.[Name] = (SELECT  [Name] FROM inserted) AND  Customer.[Email]=(SELECT  [Email] FROM inserted) )
BEGIN
PRINT 'Already such a user'
END;
ELSE
BEGIN
INSERT INTO Customer ( [Name],[Email]) SELECT [Name],[Email] FROM inserted 
END;

END;

GO
CREATE TRIGGER addHistorySales
ON Sales
FOR INSERT
AS
BEGIN
DECLARE @Count INT
SELECT @Count = [InStock] FROM Stock WHERE Stock.[AlbumId]= (SELECT [AlbumId] FROM inserted)
IF @Count>0 AND @COUNT>=(SELECT [Quantity] FROM inserted)
BEGIN
 UPDATE Stock SET [Instock]-=(SELECT [Quantity] FROM inserted) WHERE Stock.[AlbumId]= (SELECT [AlbumId] FROM inserted)

INSERT INTO historySales ([Price],[Discount],[AlbumId])
SELECT [Price],[Discount],[AlbumId] FROM inserted
END;

END;


GO
CREATE TRIGGER afterSales
ON Sales
FOR INSERT
AS
BEGIN
DECLARE @Count INT
SELECT @Count= [Instock] FROM Stock WHERE Stock.[AlbumId]= (SELECT [AlbumId] FROM inserted)
IF(@Count=0)
INSERT INTO Archive([AlbumId]) SELECT [AlbumId] FROM inserted  
END;

GO
CREATE TRIGGER banDeleteCustomer
ON Customer
INSTEAD OF DELETE
AS
BEGIN
PRINT 'Deletion rejected'
END;


GO
CREATE TRIGGER discount
ON Sales
FOR INSERT
AS
BEGIN
DECLARE @sum Money 
SELECT @sum= SUM([Price]*[Quantity]) FROM Sales JOIN Customer ON Sales.[CustomerId]=Customer.[Id] 
WHERE  Sales.[CustomerId]=(SELECT [CustomerId] FROM inserted )
IF(@sum>=50000)
UPDATE Sales SET [Discount]+=15 WHERE Sales.[CustomerId]=(SELECT [CustomerId] FROM inserted ) 
END;


GO
CREATE TRIGGER checkAlbum
ON Album
INSTEAD OF INSERT
AS
BEGIN
IF EXISTS ( (SELECT  [Title] FROM inserted WHERE [Title]='Sun' OR  [Title]='Sky' ) )
BEGIN
PRINT 'NO'
END;
ELSE
BEGIN
INSERT INTO Album ( [Title],[TrackCount],[AutorId]) SELECT [Title],[TrackCount],[AutorId] FROM inserted 
END;

END;


GO
CREATE TRIGGER checkInStock
ON Sales
FOR INSERT
AS
BEGIN
DECLARE @Count INT
SELECT @Count= [Instock] FROM Stock WHERE Stock.[AlbumId]= (SELECT [AlbumId] FROM inserted)
IF(@Count=1)
INSERT INTO Archive([AlbumId]) SELECT [AlbumId] FROM inserted  
END;

--end trigger

