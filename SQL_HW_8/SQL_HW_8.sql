

BEGIN --1

CREATE DATABASE forProcedure
USE forProcedure

BEGIN --Create table ([Employees],[EmployeeDetails])

CREATE TABLE [Employees] (
����[ID] INT PRIMARY KEY IDENTITY,
����[Name] NVARCHAR(50),
����[Position] NVARCHAR(50),
����[Department] NVARCHAR(50)
);

CREATE TABLE [EmployeeDetails] (
����[ID] INT PRIMARY KEY IDENTITY,
����[EmployeeID] INT FOREIGN KEY REFERENCES [Employees]([ID]),
����[Email] NVARCHAR(50),
����[PhoneNumber] NVARCHAR(15)
);
END;

EXEC sp_addDataEmployee 'ddd','sss','sss'

EXEC sp_addDataEmployeeDetails '1','blahblah@net.com','2222'

SELECT * FROM [EmployeeDetails]

EXEC sp_getData

EXEC sp_uppdateData '1','Some NAme','Position','Department','@Email','PhoneNumber'

EXEC sp_deleteData '1'


EXEC sp_uppdateDataDefault '1','VALUE'


EXEC sp_insertDataEmployeeDefault 'blah'

SELECT * FROM [Employees]

DECLARE @Name NVARCHAR(50),@Depart NVARCHAR(50)
EXEC sp_getNameDepartEmployee  '1',@Name OUTPUT,@Depart OUTPUT
PRINT @Name+' '+@Depart

END;

-- Create procedure FRO first task
GO
CREATE PROCEDURE sp_addDataEmployee
@Name NVARCHAR(50),@Position NVARCHAR(50),@Department NVARCHAR(50)
AS
BEGIN
INSERT INTO [Employees]([Name],[Position],[Department])VALUES(@Name,@Position,@Department)
END;
GO
CREATE PROCEDURE sp_addDataEmployeeDetails
@ID INT,@Email NVARCHAR(50),@PhoneNumber NVARCHAR(15)
AS
BEGIN
INSERT INTO [EmployeeDetails]([EmployeeID],[Email],[PhoneNumber])VALUES(@ID,@Email,@PhoneNumber)
END;
GO
CREATE PROCEDURE sp_getData
AS
BEGIN
SELECT * FROM [Employees] JOIN [EmployeeDetails] ON [Employees].[ID]=[EmployeeDetails].[EmployeeID]
END;
GO
CREATE PROCEDURE sp_uppdateData
@ID INT,@Name NVARCHAR(50),@Position NVARCHAR(50),@Department NVARCHAR(50),
@PhoneNumber NVARCHAR(15),@Email NVARCHAR(50)
AS
BEGIN
UPDATE [Employees] SET [Name]=@Name,[Position]=@Position,[Department]=@Department  WHERE [Employees].[ID]=@ID
UPDATE [EmployeeDetails] SET [Email]=@Email,[PhoneNumber]=@PhoneNumber WHERE [EmployeeDetails].[EmployeeID]=@ID
END;
GO
CREATE PROCEDURE sp_insertDataEmployeeDefault
@Name NVARCHAR(50)=NULL,
@Position NVARCHAR(50)=NULL,
@Department NVARCHAR(50)=NULL
AS
BEGIN
INSERT INTO [Employees]([Name],[Position],[Department]) VALUES (@Name,@Position,@Department)
END;
GO
CREATE PROCEDURE sp_deleteData
@ID INT
AS
BEGIN
DELETE FROM[EmployeeDetails] WHERE [EmployeeID]=@ID 
DELETE FROM[Employees] WHERE [Employees].[ID]=@ID
END
GO
CREATE PROCEDURE sp_getNameDepartEmployee
@ID INT,
@Name NVARCHAR(50) OUTPUT,
@Depart NVARCHAR(50) OUTPUT
AS
BEGIN
SELECT @Name=[Name],@Depart=[Department] FROM [Employees] WHERE [Employees].[ID]=1
END

--End Create

BEGIN -- Second task

BEGIN-- Create table(HiTech)
CREATE TABLE HiTech(
        [ProductId] INT IDENTITY(1,1) NOT NULL,
        [CategoryId] INT NOT NULL, 
        [ProductName] NVARCHAR(100) NOT NULL,
        [Price] MONEY NULL
   )

END;

BEGIN --fill info
INSERT INTO HiTech(CategoryId, ProductName, Price) VALUES 
   (1, '����', 100),
   (1, '����������', 200),
   (2, '�������', 400)

END;

EXEC  sp_addProduct  @CategoryId='1',@ProductName='Any product 6',@Price='33' 

SELECT * FROM HiTech

END;


--Create procedure
GO
CREATE PROCEDURE sp_addProduct
@CategoryId INT,@ProductName NVARCHAR(100),@Price MONEY=NULL
AS
BEGIN
INSERT INTO HiTech ([CategoryId],[ProductName],[Price])VALUES(@CategoryId,TRIM (@ProductName),@Price)
SELECT * FROM HiTech WHERE HiTech.CategoryId=@CategoryId
END;

GO
ALTER  PROCEDURE sp_addProduct
@CategoryId INT,@ProductName NVARCHAR(100),@Price MONEY
AS
BEGIN
INSERT INTO HiTech ([CategoryId],[ProductName],[Price])VALUES(@CategoryId,TRIM (@ProductName),@Price)
END;

DROP PROCEDURE sp_addProduct

--end create procedure



BEGIN --Third task (Sport shop)

CREATE DATABASE SportShop

USE SportShop

BEGIN--Create table(Employees,Products,�ustomers,aboutSales,�ustomersHistory)

CREATE TABLE �ustomers(
�   [Id] INT PRIMARY KEY IDENTITY,
����[FirstName] NVARCHAR(30)CHECK([FirstName]<>'') NOT NULL,
��� [LastName]  NVARCHAR(30)CHECK([LastName]<>'') NOT NULL,
    [Phone]  NVARCHAR(30)CHECK([Phone]<>'') NOT NULL,
��� [Email] NVARCHAR (50)CHECK([Email]<>'') NOT NULL,
    [Sex] NCHAR  CHECK([Sex]<>'') NOT NULL,
	[IsSubscribe] BIT DEFAULT 0  NOT NULL,
	[ProcentDiscount]INT DEFAULT 0 CHECK([ProcentDiscount]>=0) NOT NULL,
	[RegestrationDate] DATE
)

CREATE TABLE Employees (
����[Id] INT PRIMARY KEY IDENTITY,
����[FirstName] NVARCHAR(30)CHECK([FirstName]<>'') NOT NULL,
��� [LastName]  NVARCHAR(30)CHECK([LastName]<>'') NOT NULL,
��� [Job title] NVARCHAR (30)CHECK([Job title]<>'') NOT NULL,
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
[�ustomerId]INT NOT NULL,
[ProductsId] INT NOT NULL,
FOREIGN KEY (EmployeeId) REFERENCES Employees ([Id]),
FOREIGN KEY ([ProductsId]) REFERENCES Products ([Id]),
FOREIGN KEY ([�ustomerId]) REFERENCES �ustomers ([Id])
)

CREATE TABLE �ustomersHistory(
�   [Id] INT PRIMARY KEY IDENTITY,
    [Title] NVARCHAR(50)CHECK([Title]<>'') NOT NULL,
	[Price] MONEY CHECK([Price]>0) NOT NULL,
	[Quantity]INT CHECK([Quantity]>0) NOT NULL,
	[Date] DATE NOT NULL,
�	[�ustomerId] INT NOT NULL UNIQUE REFERENCES �ustomers([Id])
)

END;


BEGIN -- fill info

INSERT INTO Products ([Title],[Manufacturer],[primeCost],[Price],[type],[InStock])VALUES ('Some product','Some manufacture 1','75','110','1','8'),
('Some product 1','Some manufacture 2','33','75','1','5'),('Some product','Some manufacture 3','33','75','2','5'),('Some product','Some manufacture 4','33','75','2','0')


INSERT INTO Employees([FirstName],[LastName],[Sex],[Job title],[Salary],[HireDate]) VALUES('Employee 1','Employee 1','M','seller','100',GETDATE()),
('Employee 2','Employee 2','W','seller','150',GETDATE()),('Employee 3','Employee 3','W','seller','100',GETDATE())


INSERT INTO �ustomers([FirstName],[LastName],[Sex],[Phone],[Email],[RegestrationDate],[ProcentDiscount])
VALUES('Some Name','Some LastName','M','Some Phone','SOME EMAIL','2000-01-01','0'),
('Some Name1','Some LastName1','M','Some Phone1','SOME EMAIL1','2002-10-30','0'),('Some Name3','Some LastName3','W','Some Phone3','SOME EMAIL3','2005-10-30','0'),
('Some Name2','Some LastName2','M','Some Phone2','SOME EMAIL2','2005-11-30','0'),('Some Name4','Some LastName4','M','Some Phone4','SOME EMAIL4','2008-10-30','0'),
('Some Name5','Some LastName5','W','Some Phone5','SOME EMAIL5','2008-11-30','0'),('Some Name6','Some LastName6','M','Some Phone6','SOME EMAIL4','2008-10-30','0')

INSERT INTO aboutSales([ProductsId],[Quantity],[EmployeeId],[DateOfSale],[�ustomerId])VALUES('1','10','2',GETDATE(),'1'),
('2','20','2',GETDATE(),'3'),('3','10','1',GETDATE(),'4'),('1','3','3',GETDATE(),'2')







END;


 


EXEC sp_showAllProducts

EXEC sp_allinfoProductType @Type='1'

EXEC sp_top3OldClients

EXEC sp_top1Employee

EXEC sp_isStock @Manufacturer='Some manufacture 4'

EXEC sp_isStock @Manufacturer='Some manufacture 1'

EXEC sp_top1Manufacturer

SELECT * FROM �ustomers

EXEC sp_deleteClientsByDate @Date='2008-10-30'

END;


--Create sp
--1) �������� ��������� ���������� ������ ���������� � ���� �������
GO
CREATE PROCEDURE sp_showAllProducts
AS
BEGIN
SELECT * FROM Products
END;

--2) �������� ��������� ���������� ������ ���������� � ������ ����������� ����. ��� ������ ��������� � �������� ���������. ��������, 
--���� � �������� ��������� ������� �����, ����� �������� ��� �����, ������� ���� � �������.
GO
CREATE PROCEDURE sp_allinfoProductType
@Type INT
AS
BEGIN
SELECT * FROM Products WHERE Products.[type]=@Type AND Products.[InStock]>0
END;

--3) �������� ��������� ���������� ���-3 ����� ������ ��������. ���-3 ������������ �� ���� �����������.
GO
CREATE PROCEDURE sp_top3OldClients
AS
BEGIN
SELECT  TOP(3) �ustomers.[FirstName],�ustomers.[RegestrationDate] FROM �ustomers ORDER BY �ustomers.[RegestrationDate]
END;

--4) �������� ��������� ���������� ���������� � ����� �������� ��������. ���������� ������������ �� ����� ����� ������ �� �� �����.
GO
CREATE PROCEDURE sp_top1Employee
AS
BEGIN
SELECT TOP(1) Employees.[FirstName],SUM(Products.[Price]*aboutSales.[Quantity])AS 'Sum'  FROM Employees JOIN aboutSales ON Employees.[Id]=aboutSales.[EmployeeId]
JOIN Products ON Products.[Id]=aboutSales.[ProductsId]   
GROUP BY Employees.[FirstName] ORDER BY SUM(Products.[Price]*aboutSales.[Quantity]) DESC
END;

--5) �������� ��������� ��������� ���� �� ���� ���� ����� ���������� ������������� � �������. �������� ������������� ��������� � �������� ���������. 
--�� ������ ������ �������� ��������� ������ ������� yes � ��� ������, ���� ����� ����, � no, ���� ������ ���.
GO
CREATE PROCEDURE sp_isStock
@Manufacturer NVARCHAR(50)
AS
BEGIN
SELECT IIF( Products.[InStock]>0,'YES','NO') AS 'Is Stock' FROM Products WHERE Products.[Manufacturer]=@Manufacturer
END;

--6) �������� ��������� ���������� ���������� � ����� ���������� ������������� ����� �����������. 
--������������ ����� ����������� ������������ �� ����� ����� ������

GO
CREATE PROCEDURE sp_top1Manufacturer
AS
BEGIN
SELECT TOP(1) Products.[Manufacturer],SUM(Products.[Price]*aboutSales.[Quantity])AS 'Sum'  FROM Employees JOIN aboutSales ON Employees.[Id]=aboutSales.[EmployeeId]
JOIN Products ON Products.[Id]=aboutSales.[ProductsId]   
GROUP BY Products.[Manufacturer] ORDER BY SUM(Products.[Price]*aboutSales.[Quantity]) DESC
END;

--7)  �������� ��������� ������� ���� ��������, ������������������ ����� ��������� ����. 
--���� ��������� � �������� ���������. ��������� ���������� ���������� ��������� �������.
GO
CREATE PROCEDURE sp_deleteClientsByDate
@Date Date
AS
BEGIN
DELETE  FROM �ustomers WHERE �ustomers.[RegestrationDate]=@Date  
SELECT @@ROWCOUNT AS 'Deleted entries'
END;
DROP procedure  sp_deleteClientsByDate
--end sp
