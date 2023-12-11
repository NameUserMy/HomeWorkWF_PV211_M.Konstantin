
BEGIN /************************_Auto Park_*******************/

CREATE DATABASE AutoPark

USE AutoPark



CREATE TABLE[Owners](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) NOT NULL,
[SureName] NVARCHAR(30) NOT NULL,
)

CREATE TABLE [Cars](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[CarBrand] NVARCHAR(20)NOT NULL,
[OwnerId] INT NOT NULL,  
FOREIGN KEY ([OwnerId]) REFERENCES [Owners]([Id]),
)


CREATE TABLE [CarTechnicalDetails](
[Id]INT PRIMARY KEY IDENTITY(1,1),
[Model]NVARCHAR(15)NOT NULL,
[Year]DATE NOT NULL,
[Odometer]INT NOT NULL CHECK([Odometer]!=''),
[CarId]INT NOT NULL UNIQUE REFERENCES [Cars]([Id])
)

CREATE TABLE [OwnershipHistory](
[OwnersId]INT NOT NULL,
[CarId]INT NOT NULL,
CONSTRAINT PK_Owners_Cars PRIMARY KEY ([OwnersId],[CarId]),
FOREIGN KEY ([OwnersId]) REFERENCES [Owners](Id),
FOREIGN KEY ([CarId]) REFERENCES [Cars](Id),
)

INSERT INTO [Owners] VALUES ('Bob','Cucumber'),('John','Doe'),('Eric','Ivanovich')

INSERT INTO [Cars] VALUES ('Ford','1'),('Subaru','2')
INSERT INTO [Cars] VALUES ('TOYOTA','1'),('Mercedes','2')

INSERT INTO [CarTechnicalDetails] VALUES ('Fiesta',CAST('2008-10-30' as DATE),'5000','1') 
INSERT INTO [CarTechnicalDetails] VALUES ('Corola',CAST('1999-05-7' as DATE),'250000','2')

INSERT INTO [CarTechnicalDetails] VALUES ('Ascent',CAST('2008-10-30' as DATE),'5000','3') 
INSERT INTO [CarTechnicalDetails] VALUES ('XZ',CAST('2010-05-7' as DATE),'250000','4')



INSERT INTO [OwnershipHistory] ([OwnersId],[CarId]) VALUES ('1','1') 
INSERT INTO [OwnershipHistory] ([OwnersId],[CarId]) VALUES ('1','2') 


INSERT INTO [OwnershipHistory] ([OwnersId],[CarId]) VALUES ('2','3')
INSERT INTO [OwnershipHistory] ([OwnersId],[CarId]) VALUES ('2','4')


SELECT* FROM [Cars]
SELECT* FROM [Owners]
SELECT* FROM [CarTechnicalDetails]
SELECT* FROM [OwnershipHistory] 

SELECT* FROM [Cars] JOIN [CarTechnicalDetails] ON [Cars].Id=[CarTechnicalDetails].CarId  WHERE [OwnerId]=1 

SELECT* FROM [OwnershipHistory] JOIN [Cars] ON [OwnershipHistory].[CarId]=[Cars].[Id] WHERE [OwnershipHistory].[OwnersId]=1 
/*----------------------------------------------------------------------*/
END;

BEGIN /*****************************************_University_*****************************/

CREATE DATABASE University

USE University

BEGIN --Create tablt ([Faculties],[Departments],[Groups],[Teachers])

CREATE TABLE [Faculties](

[id] INT  IDENTITY(1,1) PRIMARY KEY, 
[Name] NVARCHAR (30) NOT NULL,
[Dean] NVARCHAR(30) NOT NULL, 
)


CREATE TABLE [Departments](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[Financing] MONEY NOT NULL,
[Name] NVARCHAR (30) NOT NULL,
)

CREATE TABLE [Groups](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) NOT NULL,
[Rating] INT NOT NULL,
[Year] INT NOT NULL
)


CREATE TABLE [Teachers](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[EmploymentDate] DATE,
[Name] NVARCHAR (30) NOT NULL,
[SurName] NVARCHAR (30) NOT NULL,
[Premium] MONEY NOT NULL,
[Salary] MONEY NOT NULL,
[IsAssistent] BIT DEFAULT 0 NOT NULL,
[IsProfessor] BIT DEFAULT 0 NOT NULL,
)
END;

BEGIN --Fill info for table
INSERT INTO [Teachers]([Name],[SurName],[Salary],[Premium],[EmploymentDate],[IsProfessor],[IsAssistent]) 
VALUES ('Greg','Potter','1000','200',GETDATE(),'0','1'),('John','House','1500','150',GETDATE(),'1','0'),
('John','Piterman','1500','150',GETDATE(),'1','0'),('Antony','Chupakabra','1500','150',GETDATE(),'0','1'),
('Antony','Piterman','1500','150',CAST('01.01.1999' AS DATE),'0','1'),('Sonya','Vasserman','800','150',GETDATE(),'0','1'),
('Kristina','Kukuruza','750','150',GETDATE(),'0','1')

INSERT INTO [Faculties] VALUES ('Mathmatics','LAry'),('Computer Science','IT Technologes'),
('Some Faculties','ANY')

INSERT INTO [Departments] VALUES ('10000','Department'),
('30000','Department2'),('90000','Department5'),('11000','Department8'),
('250000','Software Development'),('300','FFF'),('300','G'),('300','K')


INSERT INTO [Groups] VALUES ('GROUP1','5','5'),
('GROUP2','2','3'),('GROUP3','3','5'),('GROUP8','4','5'),('GROUP4','5','5')
--------------------------------------------------------------------------------------------
END;


SELECT [Name],[Financing],[Id] FROM [Departments] 

SELECT [Name] AS GROUPNAME, [Rating] AS GROUPRating   FROM [Groups]

SELECT [Teachers].SurName,    (100-([Teachers].Premium*100)/([Teachers].Premium+[Teachers].Salary)) As SalaryProcent,
([Teachers].Premium*100)/([Teachers].Premium+[Teachers].Salary) As PremiunProcent,[Teachers].Salary,[Teachers].Premium  FROM [Teachers]    

SELECT [Faculties].[Dean],[Faculties].[Name] AS TheDeanOfFaculty FROM [Faculties] 

SELECT [Teachers].[SurName] FROM [Teachers] WHERE [Teachers].IsProfessor='1' AND [Teachers].Salary>'1050'

SELECT* From [Departments] WHERE [Departments].[Financing]<'11000' OR [Departments].[Financing]>'25000'

SELECT* FROM [Faculties] WHERE [Faculties].[Name]<>'Computer Science'

SELECT [Teachers].[SurName],[Teachers].[Salary],[Teachers].[Premium] FROM [Teachers] WHERE [Teachers].IsAssistent='1' AND [Teachers].Premium>='160' AND [Teachers].Premium<='550' 

SELECT [Teachers].[SurName],[Teachers].[Salary] FROM [Teachers] WHERE[Teachers].IsAssistent='1'

SELECT [Teachers].[SurName],[Teachers].IsAssistent,[Teachers].IsProfessor FROM [Teachers] WHERE [Teachers].[EmploymentDate]<'01.01.2000'

SELECT [Departments].[Name] AS  NameOfDepartment FROM [Departments] WHERE [Departments].[Name] LIKE '%[^S-Z]'

SELECT [Teachers].[SurName] FROM [Teachers] WHERE [Teachers].IsAssistent='1' AND [Teachers].Salary+[Teachers].Premium<=1200

SELECT [Groups].[Name] FROM [Groups] WHERE [Groups].[Rating]>='2'AND [Groups].[Rating]<='4'

SELECT [Teachers].[SurName] FROM [Teachers] WHERE [Teachers].IsAssistent='1' AND [Teachers].Salary<'550' OR [Teachers].IsAssistent='1' AND [Teachers].Premium<'200'
/*-------------------------------------------------------------------------------*/
END;



BEGIN/*****************************************_Clietn Bank Table_************************************/

CREATE DATABASE Bank

USE Bank

CREATE TABLE [Clients](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) CHECK([Name]!='')NOT NULL,
[SureName] NVARCHAR(30) CHECK([SureName]!='')NOT NULL,
[BankAccount] MONEY CHECK([BankAccount]<='10000000') DEFAULT '0' NOT NULL,
)

INSERT INTO [Clients] VALUES ('First client','Some SN','25000'),('Second client','Some SN','32000'),
('Third client','Some SN','32000'),
('Bob','Trank','50000'),('Jeck','Puokin','180000')

SELECT* FROM [Clients] 

SELECT CONCAT([Clients].[Name], [Clients].SureName) AS NameAndSureName, [Clients].BankAccount from [Clients];

DELETE FROM [Clients] WHERE [Clients].Id=2   

DELETE FROM [Clients] WHERE [Clients].[Name]='Jeck'

DELETE TOP (2) FROM [Clients] WHERE [Clients].BankAccount<40000

SELECT* FROM [Clients]
/*----------------------------------------------------------------------------------------------*/
END;