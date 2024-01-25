CREATE DATABASE home

USE home



-- 1 Functions
GO
CREATE FUNCTION dbo.blah (@name NVARCHAR(15))
RETURNS  NVARCHAR(50)
AS
BEGIN
RETURN 'Hello' + @name
END;

SELECT  dbo.blah('Varinuha') AS Hello

--2
GO
CREATE FUNCTION dbo.minut ()
RETURNS INT
AS
BEGIN
RETURN DATEPART(mi,GETDATE())
END;

SELECT  dbo.minut() AS 'Minute'

--3
GO
CREATE FUNCTION dbo.years ()
RETURNS INT
AS
BEGIN
RETURN DATEPART(YEAR,GETDATE())
END;

SELECT  dbo.years() AS 'Year'

--4
GO
CREATE FUNCTION dbo.yearIsEven ()
RETURNS NVARCHAR(5)
AS
BEGIN
DECLARE @year INT 
SELECT @year= DATEPART(YEAR,GETDATE())
RETURN IIF(@year%2=0,'Even','Odd')
END;

SELECT   dbo.yearIsEven() AS 'Even or Odd' 

--5) 
GO
CREATE FUNCTION dbo.evenOrOdd(@start INT,@end INT,@what NVARCHAR(5))
RETURNS TABLE
AS
RETURN(
WITH  recEvenCTE
AS
(
SELECT @start AS startNum
UNION ALL
SELECT startNum+1 FROM recEvenCTE WHERE startNum<=@end

)
SELECT  startNum FROM recEvenCTE WHERE startNum%2=0 AND @what='Even' OR startNum%2<>0 AND @what='Odd'
)

SELECT * FROM dbo.evenOrOdd(1,10,'Even')

--6) 
GO
CREATE FUNCTION dbo.minMax(@a INT,@b INT,@c INT,@d INT,@f INT)
RETURNS TABLE
AS
RETURN (
WITH sumMinMax 
AS
(
SELECT @a  AS num
UNION ALL
SELECT @b UNION ALL SELECT @c 
UNION ALL SELECT @d 
UNION ALL SELECT @f
) 
SELECT MAX(num)AS 'Max',MIN(num)AS 'Min' FROM sumMinMax 
)
SELECt *FROM dbo.minMax(12,3,8,12,1)

--7
GO
ALTER FUNCTION dbo.isSimple(@a INT)
RETURNS TABLE
AS
RETURN (WITH trtCTE
AS
(
SELECT 2 AS trash
UNION ALL
SELECT  trash+1  FROM trtCTE WHERE trash<@a
)
SELECT MIN(@a%trash) AS result FROM trtCTE WHERE trash!=@a 
)
SELECT  * FROM dbo.isSimple(11)
----------------------------------------------------------


--additional tasks

--1
CREATE DATABASE sales
USE sales

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


-----