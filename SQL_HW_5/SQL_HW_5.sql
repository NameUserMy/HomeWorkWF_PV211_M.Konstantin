Use master


BEGIN --Hospital

CREATE DATABASE Hospital

USE Hospital

BEGIN --Greate table ([Donations],[Departments],[Sponsors],[Wards],[Examinations],[DoctorsExaminations],[Doctors])


CREATE TABLE [Doctors](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name]NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
[SureName]NVARCHAR(30)CHECK([SureName]<>'')NOT NULL,
[Selary] MONEY CHECK([Selary]>0) NOT NULL, 
[Premium] MONEY CHECK([Premium]>=0) NOT NULL,
)

CREATE TABLE [Sponsors](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name]NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
)

CREATE TABLE [Departments](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Building]INT CHECK([Building]>=0)NOT NULL,
[Name]NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
)

CREATE TABLE [Donation](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Amount] MONEY CHECK([Amount]>0)NOT NULL,
[Date]DATE NOT NULL,
[SponsorId] INT NOT NULL,
[DepartmentsId] INT NOT NULL,

FOREIGN KEY ([SponsorId]) REFERENCES [Sponsors](Id),
FOREIGN KEY ([DepartmentsId]) REFERENCES [Departments](Id),
)

CREATE TABLE [Wards](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name]NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
[Places]INT NOT NULL,
[DepartmentId] INT NOT NULL,

FOREIGN KEY ([DepartmentId]) REFERENCES [Departments](Id), 
)

CREATE TABLE [Examinations](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name]NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
)


CREATE TABLE [DoctorsExaminations](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[StartTime] TIME NOT NULL,
[EndTime] TIME NOT NULL,
[DoctorsId] INT NOT NULL,
[ExaminationsId] INT NOT NULL,
[WardsId]INT NOT NULL,
FOREIGN KEY ([DoctorsId]) REFERENCES [Doctors](Id),
FOREIGN KEY ([ExaminationsId]) REFERENCES [Examinations](Id),
FOREIGN KEY ([WardsId]) REFERENCES [Wards](Id),
)
END;

BEGIN --Fill Info

INSERT INTO [Doctors]([Name],[SureName],[Selary],[Premium]) VALUES ('Thomas','Gerada','5000','350'),
('Myke','Vazovskiy','10000','300'),('Doctor','Pindershles','12000','200'),('Anthony','Davis','11500','200'),('Joshua','Bell','11500','300')

INSERT INTO [Departments] ([Name],[Building]) VALUES ('General Surgery','0'),('Dentistry','0'),('Cardiology','0'),
('Gastroenterology','1'),('MRT','1'),('Microbiology','2'),('Neurology','5'),('Oncology','5')

INSERT INTO [Wards] ([Name],[Places],[DepartmentId]) VALUES('Microbiology 100','1','6'),('Microbiology 1002','2','6'),
('Wards Microbiology 105','2','6'),('General Surgery 1001','5','1'),('General Surgery 1007','5','1'),('Gastroenterology 115','7','4')

INSERT INTO [Sponsors] VALUES ('Very kind man'),('MRT fonat'),('John Doe'),('Klaus')

INSERT INTO [Donation] ([Amount],[Date],[SponsorId],[DepartmentsId]) VALUES ('30000',GETDATE(),'1','1'),('150000',GETDATE(),'2','5'),
('10000',GETDATE(),'3','2'),('7000',GETDATE(),'4','4'),('3000',GETDATE(),'3','5'),('7500',GETDATE(),'3','7')



INSERT INTO [Examinations] VALUES ('Dentistry'),('Cardiology'),('General Surgery'),('Gastroenterology') 

INSERT INTO [DoctorsExaminations] ([StartTime],[EndTime],[DoctorsId],[ExaminationsId],[WardsId]) VALUES ('12:00','15:00','5','3','4'),('15:00','15:30','5','4','6') 

END;

SELECT [Departments].[Name] FROM [Departments] WHERE [Departments].[Building] = (SELECT [Building] FROM [Departments] WHERE [Departments].[Name]='Cardiology' )

SELECT [Departments].[Name] FROM [Departments] WHERE [Departments].[Building] IN (SELECT [Building] FROM [Departments] WHERE [Departments].[Name] IN ('General Surgery','Gastroenterology'))

SELECT [Departments].[Name] FROM [Departments] JOIN Donation ON [Departments].[Id]=[Donation].[DepartmentsId] WHERE [Donation].[Amount]=(SELECT MIN([Donation].[Amount]) FROM Donation)

SELECT [Doctors].[SureName] FROM [Doctors] WHERE [Doctors].[Selary]>(SELECT [Doctors].[Selary] FROM [Doctors] WHERE [Doctors].[Name]='Thomas' AND [Doctors].[SureName]='Gerada' )

SELECT [Wards].[Name],[Wards].[Places] FROM [Wards] JOIN [Departments] ON [Wards].[DepartmentId]=[Departments].[Id] WHERE [Wards].[Places]>   
(SELECT AVG([Wards].[Places]) FROM [Wards] JOIN [Departments] ON [Wards].DepartmentId=Departments.Id   WHERE   [Departments].[Name]='Microbiology')

SELECT [Doctors].[Name],[Doctors].[SureName] FROM [Doctors] WHERE ([Doctors].[Selary]+[Doctors].[Premium])-
(SELECT [Doctors].[Selary]+[Doctors].[Premium] FROM[Doctors] WHERE [Doctors].[Name]='Anthony' AND [Doctors].[SureName]='Davis')>100

SELECT [Departments].[Name] FROM Departments JOIN [Wards] ON [Departments].[Id]=[Wards].[DepartmentId] 
JOIN [DoctorsExaminations] ON [Wards].[Id]=[DoctorsExaminations].[WardsId]  JOIN [Doctors] ON [DoctorsExaminations].[DoctorsId]=[Doctors].[Id] 
WHERE [Doctors].[Id]=(SELECT [Doctors].[Id] FROM [Doctors] WHERE [Doctors].[Name]='Joshua' AND [Doctors].[SureName]='Bell')

SELECT [Doctors].[SureName] FROM [Doctors] JOIN [DoctorsExaminations] ON [DoctorsExaminations].[DoctorsId]=[Doctors].[Id] WHERE [DoctorsExaminations].[StartTime]='12:00' AND [DoctorsExaminations].[EndTime]='15:00'

END;


BEGIN -- Furniture store

CREATE DATABASE FurnitureStore

USE FurnitureStore


BEGIN --Greate table ([Product],[Сustomer],[Delivery],[Order])

CREATE TABLE [Product](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Title] NVARCHAR(30) CHECK([Title]<>'') NOT NULL,
[Price] MONEY CHECK ([Price]>0) NOT NULL,
)

CREATE TABLE [Сustomer](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) CHECK([Name]<>'') NOT NULL,
[SureName] NVARCHAR(30) CHECK([SureName]<>'') NOT NULL,
[Phone] NVARCHAR(20) CHECK([Phone]<>'') NOT NULL,
[Adress] NVARCHAR(30) CHECK([Adress]<>'') NOT NULL,
[Email] NVARCHAR(30) CHECK([Email]<>'') NOT NULL,
)

CREATE TABLE [Order](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Count] INT CHECK ([Count]>0) NOT NULL,
[СustomerId] INT NOT NULL,
[ProductId] INT NOT NULL,
FOREIGN KEY ([СustomerId]) REFERENCES [Сustomer]([Id]),
FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)

CREATE TABLE [DeliveryMethod](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[post] BIT DEFAULT 0 NOT NULL,
[PickupItself] BIT DEFAULT 0 NOT NULL,
[Price] MONEY CHECK([Price]>=0) NOT NULL,
[OrderId] INT  UNIQUE REFERENCES [Order]([Id]) NOT NULL
)



END;


BEGIN --Fill Info

INSERT INTO [Product] VALUES ('Sofa','30.22'),('Closet','10.25'),('Table','25.70'),
('Bed','150.55'),('Chair','10'),('Сhildren chair','10')

INSERT INTO [Сustomer]([Name],[SureName],[Phone],[Adress],[Email]) VALUES ('Greg','Donavan','123-55-86','ANY','Greg@Mail.Com'),
('John','potato','155-86-86','Some','John@Mail.Com'),('Bob','Bean','758-33-86','Adress','Bob@Mail.Com'),('Helena','Vasevna','965-88-22','Some Adress','Helena@Mail.Com'),
('Valeriya','Anyvna','754-88-22','Any Adress','Valeriya@Mail.Com')

INSERT INTO [Order]([ProductId],[СustomerId],[Count]) Values ('1','4','2'),('3','1','1'),('3','5','2'),('5','3','1')

INSERT INTO [DeliveryMethod]([post],[PickupItself],[Price],[OrderId])VALUES ('0','1','0','4'),('0','1','0','2'),
('1','0','30','1'),('1','0','10','3')


END;

SELECT MIN([Product].[Price]) AS 'Min price product' FROM [Product]

SELECT MAx([Product].[Price]) AS 'Max price product' FROM [Product]

SELECT [Product].[Price] FROM [Product] GROUP BY [Price] HAVING COUNT(Price)>1

SELECT TOP(2) [Сustomer].[Name],([Product].[Price]*[Order].[Count]) AS 'Spend money' FROM [Сustomer] JOIN [Order] ON [Сustomer].Id=[Order].[СustomerId] JOIN [Product] 
ON [Order].[ProductId]=[Product].[Id] WHERE  ([Product].[Price]*[Order].[Count])> ANY(SELECT ([Product].[Price]*[Order].[Count]) FROM [Product] WHERE [Сustomer].[Id]=[Order].[СustomerId]) 
ORDER BY ([Product].[Price]*[Order].[Count]) DESC

SELECT TOP(2) [Сustomer].[Name],([Product].[Price]*[Order].[Count]) AS 'Spend money' FROM [Сustomer] JOIN [Order] ON [Сustomer].Id=[Order].[СustomerId] JOIN [Product] 
ON [Order].[ProductId]=[Product].[Id] WHERE  ([Product].[Price]*[Order].[Count])< ANY(SELECT ([Product].[Price]*[Order].[Count]) FROM [Product] WHERE [Сustomer].[Id]=[Order].[СustomerId]) 
ORDER BY ([Product].[Price]*[Order].[Count])

SELECT [Сustomer].[Name] FROM [Сustomer] JOIN [Order] ON [Order].[СustomerId]=[Сustomer].[Id] JOIN [DeliveryMethod] ON [DeliveryMethod].[OrderId]=[Order].[Id]
WHERE [DeliveryMethod].[PickupItself]='1'


SELECT  [Сustomer].[Name],([Product].[Price]*[Order].[Count]+[DeliveryMethod].[Price]) AS 'Spend money + Delivery' FROM [Сustomer] JOIN [Order] ON [Сustomer].Id=[Order].[СustomerId] JOIN [Product] 
ON [Order].[ProductId]=[Product].[Id] JOIN [DeliveryMethod] ON [DeliveryMethod].[OrderId]=[Order].[Id]


SELECT  [Сustomer].[Name],([Product].[Price]*[Order].[Count]+[DeliveryMethod].[Price]) AS 'Spend money + Delivery' FROM [Сustomer] JOIN [Order] ON [Сustomer].Id=[Order].[СustomerId] JOIN [Product] 
ON [Order].[ProductId]=[Product].[Id] JOIN [DeliveryMethod] ON [DeliveryMethod].[OrderId]=[Order].[Id] WHERE [Сustomer].[Name]='Helena'


SELECT [Сustomer].[Name],[Сustomer].[SureName],[Сustomer].[Adress],[Product].[Title] FROM [Сustomer] JOIN [Order] ON [Сustomer].[Id]=[Order].[СustomerId] 
JOIN [Product] ON [Product].[Id]=[Order].[ProductId] 

SELECT COUNT(Product.Title) AS 'Count Product',SUM(Product.Price) AS 'Sum price All products ' FROM [Product]

END;

USE master

DROP DATABASE FitnessClub
BEGIN --Fitness club

CREATE DATABASE FitnessClub

USE FitnessClub


BEGIN --Create table([Instructors],[Visitors],[Sections][Registration])

CREATE TABLE [Visitors](
[Id] INT PRIMARY KEY IDENTITY (1,1),
[Name] NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
[Phone] NVARCHAR(30)CHECK([Phone]<>'')NOT NULL,
)

CREATE TABLE [Sections](
[Id] INT PRIMARY KEY IDENTITY (1,1),
[Title] NVARCHAR(30)CHECK([Title]<>'')NOT NULL,
)

CREATE TABLE [Instructors](
[Id] INT PRIMARY KEY IDENTITY (1,1),
[Name] NVARCHAR(30)CHECK([Name]<>'')NOT NULL,
[SectionId] INT CHECK([SectionId]>=0) NOT NULL,
FOREIGN KEY ([SectionId]) REFERENCES  [Sections] ([Id]),
)

CREATE TABLE [Regestration](
[Id] INT PRIMARY KEY IDENTITY (1,1),
[RegDate] DATE CHECK([RegDate]<>'') NOT NULL,
[VisitorId] INT CHECK([VisitorId]>0) NOT NULL,

FOREIGN KEY ([VisitorId])  REFERENCES [Visitors](Id),
)

CREATE TABLE [RegestrationInfo](
[Id] INT PRIMARY KEY IDENTITY (1,1),
[CountVisits] INT CHECK([CountVisits]>=0) NOT NULL,
[WhenDate] DATE CHECK([whenDate]<>'') NOT NULL,
[WhenTime] TIME CHECK([whenTime]<>'') NOT NULL,

[RegestrationId] INT CHECK([RegestrationId]>0) NOT NULL,
[SectionId] INT CHECK([SectionId]>0) NOT NULL,
[InstructorsId] INT CHECK([InstructorsId]>0) NOT NULL,


FOREIGN KEY ([InstructorsId]) REFERENCES  [Instructors] ([Id]),
FOREIGN KEY ([RegestrationId]) REFERENCES  [Regestration] ([Id]),
FOREIGN KEY ([SectionId]) REFERENCES  [Sections] ([Id]),
)
END;


BEGIN-- Fill info

INSERT INTO [Visitors]([Name],[Phone]) VALUES ('Helena','+38095------'),('Olga','+38097------'),('Anna','+38095------'),
('Grundik','+38066--------'),('Gregory','+38063--------'),('John','+38067---------'),('Helena','+38099------')

INSERT INTO [Sections]VALUES ('Pilatos'),('Yoga'),('Gym')

INSERT INTO [Instructors]([Name],[SectionId])VALUES('Tanya','1'),('Karina','1'),('Tim','2'),('Gektor','2'),('Bob','3')

INSERT INTO [Regestration]([VisitorId],[RegDate]) VALUES ('1',GETDATE()),('2',GETDATE()),('4',GETDATE()),('7',GETDATE())

INSERT INTO [RegestrationInfo]([RegestrationId],[SectionId],[InstructorsId],[whenDate],[whenTime],[CountVisits])VALUES('1','1','1',GETDATE(),'15:20','1'),('1','2','3',GETDATE(),'13:00','1'),
('2','2','4',GETDATE(),'13:00','3'),('2','1','2',GETDATE(),'15:20','3'),('3','3','5',GETDATE(),'16:20','7'),('4','1','1',GETDATE(),'15:20','5')

END;


-- 1) Вывести количество инструкторов по каждой секции;
SELECT [Sections].[Title], COUNT([Sections].[Title]) AS 'Count Instructor' FROM [Sections] JOIN [Instructors]ON [Sections].[Id]=[Instructors].[SectionId]
GROUP BY [Sections].[Title]

-- 2) Показать количество людей, которые должны заниматься в определенный момент времени в каждой секции;
SELECT [Sections].[Title], COUNT([Sections].[Title]) AS 'Count visiters' FROM [Sections] JOIN [RegestrationInfo]ON [Sections].[Id]=[RegestrationInfo].[SectionId]
WHERE [RegestrationInfo].[WhenTime]='15:20' GROUP BY [Sections].[Title] 

-- 3) Вывести количество посетителей фитнес клуба, которые пользуются услугами определенного мобильного оператора;
SELECT COUNT([Visitors].[Name])AS 'Visitor count use Vodafone Operator' FROM [Visitors] WHERE [Visitors].[Phone]='+38095------'

-- 4) Получить количество посетителей, у которых фамилия совпадает с фамилиями из определенного списка;
SELECT COUNT([Visitors].[Name])AS 'Count INTERSECT'  FROM [Visitors] WHERE [Visitors].[Name]= (SELECT [Name] INTERSECT SELECT [Visitors].[Name] FROM [Visitors])

-- 5) Показать количество людей с одинаковыми именами, которые занимаются у определенного инструктора;
SELECT COUNT ([Visitors].[Name])AS 'Count identical names' FROM [Regestration] JOIN [RegestrationInfo] ON [RegestrationInfo].[RegestrationId]=[Regestration].[Id]
JOIN Visitors ON [Visitors].[Id]=[Regestration].[VisitorId]JOIN [Instructors]ON[Instructors].[Id]=[RegestrationInfo].[InstructorsId] 
WHERE [Instructors].[Name]='Tanya'

-- 6) Получить информацию о людях, которые посетили фитнес зал минимальное количество раз;
SELECT *FROM [Visitors] JOIN [Regestration] ON [Regestration].[VisitorId]=[Visitors].[Id]
JOIN [RegestrationInfo] ON [RegestrationInfo].[RegestrationId]=[Regestration].[Id] 
WHERE [RegestrationInfo].[CountVisits]=(SELECT MIN([RegestrationInfo].[CountVisits]) FROM [RegestrationInfo])

-- 7) Вывести количество посетителей, которые занимались в определенной секции за первую половину текущего года;
SELECT [Sections].[Title], COUNT([Sections].[Title]) AS 'Count visiters' FROM [Sections] JOIN [RegestrationInfo]ON [Sections].[Id]=[RegestrationInfo].[SectionId]
WHERE [Sections].[Title]='Pilatos' AND [RegestrationInfo].[WhenDate]='2023-06-20' GROUP BY [Sections].[Title] 

-- 8) Определить общее количество людей, посетивших фитнес зал за прошлый год.
SELECT COUNT([Visitors].[Name]) AS 'Count visitor' FROM [Visitors] JOIN [Regestration] ON [Regestration].[VisitorId]=Visitors.Id  
WHERE [Regestration].[RegDate]='2022-12-20' 

END;