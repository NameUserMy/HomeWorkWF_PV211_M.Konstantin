 
BEGIN--Shop

CREATE DATABASE Shop

USE Shop

BEGIN--Create table([Users],[Orders],[OrderDetails],[Products],)

CREATE TABLE [Users] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(30)CHECK([Name]<>'')
)

CREATE TABLE [Products] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
    [Price] DECIMAL(10, 2) CHECK([Price]>0) NOT NULL,
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

INSERT INTO [Products] VALUES ('Sofa','30.22'),('Closet','10.25'),('Table','25.70'),
('Bed','150.55'),('Chair','10'),('Сhildren chair','10'),('Buble Gum','0.30'),('Bread','1.0'),
('Some product','35.44'),('Any product','75')

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

--1) Получите общее количество заказанных товаров для каждого пользователя, а также общую сумму, потраченную каждым пользователем.
SELECT [Users].[Name],SUM([OrderDetails].[Quantity])AS 'Count Product',SUM([Products].[Price])AS'Spend Money' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] 
JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId] JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  GROUP BY [Users].[Name]

--2) Определите общую сумму каждого заказа.
SELECT [Users].[Name],([OrderDetails].[Quantity] *[Products].[Price])AS'Sum order' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId]
JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  

--3) Найдите средний чек для каждого пользователя.
SELECT [Users].[Name],AVG(([OrderDetails].[Quantity] *[Products].[Price]))AS'AVG Bill' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId]
JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  GROUP BY [Users].[Name]

--4) Найдите самый дорогой продукт в каждом заказе.
SELECT [Products].[Name],[Products].[Price] FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId]
JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  WHERE [Products].[Price]>ANY(SELECT [Products].[Price] From Products) ORDER BY [Products].[Price] DESC

--5) Подсчитайте общее количество заказов в определенном временном периоде.
SELECT SUM([OrderDetails].[Quantity])AS 'Count orders' FROM [OrderDetails] JOIN [Orders] ON [Orders].[Id]=[OrderDetails].[OrderId]
WHERE [Orders].[OrderDate]>=CAST('2023-11-20'AS DATE)AND[Orders].[OrderDate]<=GETDATE()

--6) Определите три самых популярных товара по количеству заказов.
SELECT TOP (3) [Products].[Name] FROM [Products]JOIN [OrderDetails] ON [Products].[Id]=[OrderDetails].[ProductId]
WHERE [OrderDetails].[Quantity]> ANY(SELECT [OrderDetails].[Quantity] FROM [OrderDetails] ) ORDER BY [OrderDetails].[Quantity] DESC

--7) Посчитайте количество заказов для каждого пользователя в определенном временном периоде. 
SELECT [Users].[Name],SUM([OrderDetails].[Quantity])AS 'Count Product' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] 
JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId] JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  
WHERE [Orders].[OrderDate]>=CAST('2023-11-20'AS DATE)AND[Orders].[OrderDate]<=GETDATE() GROUP BY [Users].[Name]

 --8) Рассчитайте сумму продаж по месяцам.
SELECT MONTH([Orders].[OrderDate])AS 'Month', SUM(([OrderDetails].[Quantity] *[Products].[Price]))AS'Sum order in month' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId]
JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId] GROUP BY [OrderDate]

--9) Определите количество заказов для каждого продукта.
SELECT [Products].[Name],COUNT([OrderDetails].[Quantity])AS 'Count order' FROM [Users] JOIN [Orders] ON  [Users].[Id]=[Orders].[UserId] 
JOIN [OrderDetails] ON [Orders].[Id]=[OrderDetails].[OrderId] JOIN [Products] ON [Products].[Id]=[OrderDetails].[ProductId]  GROUP BY [Products].[Name]

END;

BEGIN-- Employee

CREATE DATABASE Employee

USE Employee

BEGIN--Create table([Employees],[Projects])

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50)CHECK([Name]<>'') NOT NULL,
[Departments] NVARCHAR(50)CHECK([Departments]<>'') NOT NULL,
[Salary] MONEY CHECK([Salary]>0) NOT NULL
)



CREATE TABLE [Projects](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[ProjectsName] NVARCHAR(50)CHECK([ProjectsName]<>'') NOT NULL,
[Department] NVARCHAR(50)CHECK([Department]<>'') NOT NULL,
[EmployeeId]INT CHECK([EmployeeId]>0) NOT NULL,
FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)

END;

BEGIN --Fill Info
INSERT INTO [Employees]([Name],[Departments],[Salary])VALUES('John Smith','IT','75000'),('Jone Doe','Marketing','60000'),
('Bob johnson','Finance','80000'),('Alice Lee','IT','65000'),('Tom jones','Marketing','55000'),('Merry Brown','Finance','75000')

INSERT INTO [Projects]([ProjectsName],[Department],[EmployeeId])VALUES('Project A','IT','1'),
('Project B','Marketing','2'),('Project C','Finance','6'),('Project D','IT','1'),
('Project E','Marketing','4'),('Project E','Marketing','2'),('Project F','Finance','6')

END;

--1) Найдите среднюю зарплату всех сотрудников отдела информационных технологий.
SELECT AVG([Employees].[Salary]) FROM [Employees] WHERE [Employees].[Departments]='IT'

-- 2) Найдите имена всех сотрудников, которые зарабатывают больше, чем средняя зарплата в их отделе.
SELECT [Employees].[Name] FROM [Employees] WHERE [Employees].[Departments]='IT' AND [Employees].[Salary]>(SELECT AVG([Employees].[Salary]) FROM [Employees])

-- 3) Найдите количество сотрудников в каждом отделе.
SELECT [Projects].[Department],COUNT([Employees].[Id]) AS  'Count Employee' FROM [Projects] JOIN [Employees] ON [Projects].[EmployeeId]=[Employees].[Id]
GROUP BY[Projects].[Department]


-- 4) Найдите имена всех сотрудников, которые работают над проектом в отделе маркетинга.
SELECT [Employees].[Name] FROM [Employees] JOIN [Projects] ON [Employees].[Id]=[Projects].[EmployeeId]
WHERE  [Projects].[Department]='Marketing'

-- 5) Найдите среднюю зарплату всех сотрудников, которые не работают над проектом.
SELECT [Employees].[Name],AVG([Employees].[Salary]) AS 'AVG salary' FROM [Employees] LEFT JOIN [Projects] ON [Employees].[Id]=[Projects].[EmployeeId]
WHERE Projects.ProjectsName IS NULL GROUP BY [Employees].[Name]

--6) Найдите имя сотрудника, получающего самую высокую зарплату.
SELECT [Employees].[Name] FROM [Employees] WHERE [Employees].[Salary]=(SELECT MAX([Employees].[Salary]) FROM [Employees])

-- 7) Найдите имена всех сотрудников, которые зарабатывают больше средней зарплаты по своему отделу и работают над проектом.
SELECT [Employees].[Name] FROM [Employees]  JOIN [Projects] ON [Employees].[Id]=[Projects].[EmployeeId]
WHERE  [Projects].[Department]='IT' AND [Employees].[Salary]> (SELECT AVG ([Employees].[Salary]) FROM [Employees] )
GROUP BY [Employees].[Name]

-- 9) Найдите название проекта и отдел проекта, над которым работает наибольшее количество сотрудников.
SELECT TOP(1) [Projects].[ProjectsName],[Projects].[Department], COUNT([Employees].[Id]) AS 'count Employees' 
FROM [Projects] JOIN [Employees] ON [Projects].[EmployeeId]=[Employees].[Id]
GROUP BY [Projects].[ProjectsName],[Projects].[Department] ORDER BY COUNT([Employees].[Id]) DESC 
END;









