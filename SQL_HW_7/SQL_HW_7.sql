

BEGIN--Built-in functions

CREATE DATABASE forFunction

USE forFunction


BEGIN--Create table([Users],[Orders],[OrderDetails],[Products],)

CREATE TABLE [Users] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(30)CHECK([Name]<>'')
)

CREATE TABLE [Products] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
    [Price] DECIMAL(10, 2) CHECK([Price]>0) NOT NULL,
	[Date] DATE NOT NULL,
)

CREATE TABLE [Orders] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId]  INT CHECK([UserId]>0) NOT NULL,
    [OrderDate] DATE CHECK([OrderDate]<>'') NOT NULL,
    FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)



CREATE TABLE [OrderDetails] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [OrderId] INT CHECK([OrderId]>0) NOT NULL,
    [ProductId] INT CHECK([ProductId]>0) NOT NULL,
    [Quantity] INT CHECK([Quantity]>0)  NOT NULL,
    FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]),
    FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
)
END;


BEGIN --Fill Info

INSERT INTO [Products] VALUES ('Sofa','30.22','2021-01-01'),('Closet','10.25','2021-01-01'),('Table','25.70','2021-01-01'),
('Bed','150.55',GETDATE()),('Chair','10',GETDATE()),('Сhildren chair','10',GETDATE()),('Buble Gum','0.30',GETDATE()),('Bread','1.0',GETDATE()),
('Some product','35.44',GETDATE()),('Any product','75',GETDATE()),('str25332355jhjk','0.5',GETDATE())

INSERT INTO [Users] VALUES ('Greg'),('John'),('Bob'),('Helena'),
('Valeriya'),('Anna')
-- Greg
INSERT INTO [Orders]([UserId],[OrderDate]) VALUES ('1',GETDATE())

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','1','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('1','4','1')
--

--John
INSERT INTO [Orders]([UserId],[OrderDate]) VALUES ('2',GETDATE())

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','7','10')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','5','4')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('2','3','1')
--

INSERT INTO [Orders]([UserId],[OrderDate]) VALUES ('3',GETDATE())

INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','4','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','2','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('3','6','7')

INSERT INTO [Orders]([UserId],[OrderDate]) VALUES ('5',CAST('2023-11-01'AS DATE))
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('4','7','2')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('4','8','1')
INSERT INTO [OrderDetails]([OrderId],[ProductId],[Quantity])VALUES('4','9','1')

END;






--1) Напишите запрос, который извлечет только год из даты.
SELECT DATEPART(YYYY,GETDATE()) AS 'Year'

--2) Напишите запрос, который найдет все записи, где в текстовом поле содержится слово "SQL".
SELECT [Products].[Name] FROM [Products] WHERE [Products].[Name] LIKE '%Chair%'

--3) Напишите запрос, который заменит все вхождения слова "кошка" на слово "собака" в столбце my_text_column.
SELECT REPLACE([Products].[Name],'Chair','DOG') FROM [Products]

--4) Напишите запрос, который извлечет часть строки перед первым вхождением символа " i ".
SELECT  SUBSTRING([Products].[Name],1,PATINDEX('%i%',[Products].[Name])-1)  FROM [Products] WHERE Id=5

--5) Напишите запрос, который извлечет часть строки после последнего вхождения символа " i ".
--Сhildren chair
SELECT  SUBSTRING([Products].[Name],CHARINDEX('i',[Products].[Name],PATINDEX('%i%',[Products].[Name])+1)+1,LEN([Products].[Name])) FROM [Products] WHERE Id=6

--6) Напишите запрос, который извлечет все цифры из строки.
--'str25332355jhjk'

SELECT SUBSTRING([Products].[Name],PATINDEX('%[0-9]%',[Products].[Name]),PATINDEX('%[0-9]%',[Products].[Name])+PATINDEX('%[0-9]%',[Products].[Name])) FROM [Products] WHERE Id=11

--7) Напишите запрос, который извлечет день недели из даты.
SELECT DATEPART(WEEKDAY,GETDATE()) AS 'Day'

--8) Напишите запрос, который найдет все записи, где значение числового столбца меньше 10.
SELECT [Products].[Price] FROM [Products] WHERE [Products].[Price]<10

--9) Напишите запрос, который вычислит среднее значение числового столбца.
SELECT AVG([Products].[Price])AS 'Avg value' FROM [Products]

--10) Напишите запрос, который вычисляет сумму значений числового столбца для всех записей, где значение даты больше 01.01.2021.
SELECT SUM([Products].[Price]) FROM [Products] WHERE [Products].[Date]>'2021-01-01'

--11) Напишите запрос, который извлечет только месяц и год из даты.
SELECT CONCAT( MONTH(GETDATE()),' - ',YEAR(GETDATE())) AS 'Month and year'

--12) Напишите запрос, который удалит все пробелы в начале и конце текстового столбца. Sql
SELECT TRIM( '   SOME INFO 1    ') AS 'SOME INFO '

--13) Напишите запрос, который вычислит разницу между двумя датами в днях.
SELECT DATEDIFF(DAY,'2022-12-21',GETDATE()) AS 'Result'

--14) Напишите запрос, который вычислит сумму значений числового столбца для каждого значения текстового столбца.
SELECT [Products].[Price]+[Products].[Price] FROM [Products] 

--15) Напишите запрос, который заменит все буквы в текстовом столбце на заглавные.
SELECT UPPER([Products].[Name]) FROM [Products]

END;

BEGIN -- Book shop
use master
CREATE DATABASE bookShop
USE bookShop

BEGIN --Create table([Sellers],[Books],[BooksDetails])
create table [Sellers] 
(
[Id] INT IDENTITY PRIMARY KEY,
[FullName] NVARCHAR(60) NOT NULL
)
create table [Books](
[Id] INT IDENTITY PRIMARY KEY,
[Name] NVARCHAR(30) NOT NULL 
)
create table [BooksDetails](

[BooksId] INT NOT NULL ,
[SellerId] INT NOT NULL, 

CONSTRAINT PK_book_seler PRIMARY KEY([BooksId],[SellerId]), 
FOREIGN KEY ([BooksId]) REFERENCES Books(Id),
FOREIGN KEY ([SellerId]) REFERENCES [Sellers](Id),

[OrderDate] DATE NOT NULL,
[Quantity] INT NOT NULL,
[Price] MONEY NOT NULL
)
END;


BEGIN -- Fill info

INSERT INTO [Sellers]VALUES (' A.Smith'),('Mr.Anderson'),('R.Sanny'),('D.Spooner'),('E.Ripley')

INSERT INTO [Books]VALUES('Book 1'),('Book 2'),('Book 3'),('Book 4'),('Book 5'),('Book 6')

INSERT INTO [BooksDetails]([BooksId],[SellerId],[Quantity],[Price],[OrderDate])VALUES ('1','1','10','22.0','2020-12-10'),
('2','1','15','22.0','2020-12-10'),('5','2','31','22.0','2020-12-10'),('6','4','55','22.0','2020-12-10')

END;
SELECT [Sellers].[FullName] FROM [Sellers]JOIN [BooksDetails]ON [Sellers].[Id]=[BooksDetails].[SellerId]
WHERE [BooksDetails].[Quantity]>30 AND DATEPART(YEAR,[BooksDetails].[OrderDate])='2020'

END;




BEGIN --  Shop
use master
CREATE DATABASE Shop
USE Shop

BEGIN --Create table([Departments],[Employees],[Orders])

CREATE TABLE [Departments] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50)
);

CREATE TABLE [Employees] (
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(50),
    [LastName] NVARCHAR(50),
    [HireDate] DATE,
    [DepartmentID] INT,
    FOREIGN KEY ([DepartmentID]) REFERENCES [Departments]([Id])
);

CREATE TABLE [Orders] (
    [Id] INT PRIMARY KEY IDENTITY,
    [EmployeeID] INT,
    [OrderDate] DATE,
    [Amount] DECIMAL(10, 2),
    FOREIGN KEY (EmployeeID) REFERENCES Employees([Id])
);

END;


BEGIN -- Fill info

INSERT INTO [Departments]([Name])VALUES('Matrix'),('I robot'),('Alien')
INSERT INTO [Employees]([FirstName],[LastName],[DepartmentID],[HireDate])VALUES ('Agent','Smith','1','1999-03-31'),('Mister','Anderson','1','1999-03-31'),
('Robot','Sanny','2','2004-06-16'),('Detective','Spooner','2','2004-06-16'),('Ellen','Ripley','3','1979-05-25')

INSERT INTO [Orders]([Amount],[EmployeeID],[OrderDate])VALUES('205','1','1999-03-31'),('507','3','2004-06-16'),
('1050','5','1979-05-25'),('2025.00','3','2013-06-16')

INSERT INTO [Orders]([Amount],[EmployeeID],[OrderDate])VALUES('205','2',GETDATE()),('308','2',GETDATE())


--1) Выберите имена и фамилии сотрудников в верхнем регистре.
SELECT UPPER([Employees].[FirstName])AS 'First name',UPPER([Employees].[LastName])AS 'Last name' FROM [Employees]

--2) Рассчитайте и выведите возраст сотрудников вместе с остальными столбцами.
SELECT DATEDIFF(YEAR,Employees.HireDate,GETDATE())AS 'Age',* FROM [Employees]

--3) Выберите все заказы после определенной даты.
SELECT * FROM [Orders] WHERE DATEPART(YEAR,[Orders].[OrderDate])>'1979' 

--4) Выведите общую сумму заказов для каждого сотрудника.
SELECT [Employees].[FirstName], SUM([Orders].[Amount]) AS 'Sum All orders' FROM [Orders] JOIN [Employees] ON [Employees].[Id]=[Orders].[EmployeeID]
GROUP BY [Employees].[FirstName]
--5) Выведите количество сотрудников в каждом отделе.
SELECT [Departments].[Name],COUNT([Employees].[FirstName]) AS 'Employees in departmens' 
FROM [Departments] JOIN [Employees]ON [Departments].[Id]=[Employees].[DepartmentID]
GROUP BY [Departments].[Name]

--6) Рассчитайте среднюю продолжительность работы сотрудников в днях.
SELECT AVG(DATEDIFF(DAY,[Employees].[HireDate],GETDATE())) AS 'AVG day' FROM [Employees]

--7) Выведите длины имен всех сотрудников.
SELECT LEN([Employees].[FirstName]) AS 'Len name emploees' FROM [Employees]

--8) Выведите сумму заказа со знаком доллара, используя функцию FORMAT.
SELECt  FORMAT([Orders].[Amount],'C') AS 'Price' FROM [Orders]

--9) Выведите первые 3 символа имен сотрудников.
SELECT SUBSTRING([Employees].[FirstName],1,3)AS 'First 3 simbol' FROM [Employees]

--10) Определите количество знаков после запятой в сумме заказа.
SELECT LEN(SUBSTRING(CAST([Amount]AS NVARCHAR),CHARINDEX('.',[Amount])+1,LEN([Amount]))) AS 'count After .' FROM [Orders]

--11) Получите список сотрудников с самым длинным именем.
SELECT [Employees].[FirstName] FROM [Employees] WHERE LEN([FirstName])>ANY(SELECT LEN([FirstName]) FROM [Employees])

--12) Выведите среднюю продолжительность работы сотрудников в каждом отделе.
SELECT [Departments].[Name], AVG(DATEDIFF(YEAR,[Employees].[HireDate],GETDATE())) AS 'AVG year' FROM [Employees] JOIN [Departments]
ON [Departments].[Id]=[Employees].[DepartmentID] GROUP BY [Departments].[Name]

--13) Определите сумму заказов для каждого сотрудника за последние 90 дней.
SELECT [Employees].[FirstName], SUM([Orders].[Amount]) AS 'Sum All orders' FROM [Orders] JOIN [Employees] ON [Employees].[Id]=[Orders].[EmployeeID]
WHERE DATEDIFF(DAY,[Orders].[OrderDate],GETDATE())<=90 GROUP BY [Employees].[FirstName] 

--14) Выведите Топ-3 сотрудников с наибольшей общей суммой заказов.
 SELECT TOP(3)  [Employees].[FirstName], SUM([Orders].[Amount]) AS 'Sum All orders' FROM [Orders] JOIN [Employees] ON [Employees].[Id]=[Orders].[EmployeeID]
GROUP BY [Employees].[FirstName] ORDER BY SUM([Orders].[Amount]) DESC

--15) При выборке из таблицы сотрудников создайте столбец, который будет включать в себя и имя и общую сумму заказов.
SELECT CONCAT([Employees].[FirstName],' - ', SUM([Orders].[Amount])) AS 'Name and sum All orders' FROM [Orders] JOIN [Employees] ON [Employees].[Id]=[Orders].[EmployeeID]
GROUP BY [Employees].[FirstName]

END;

END;


