
/****************************_1_***************************/


--Create  DB Academy
CREATE DATABASE Academy
GO
-- Pick DB 
USE Academy
GO
--create Table  Groups
CREATE TABLE [Groups](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE  NOT NULL,
[Rating] INT CHECK ([Rating]>=0 AND [Rating]<=5) DEFAULT 0 NOT NULL,
[Year] INT  CHECK ([Rating]>=0 AND [Rating]<=5) DEFAULT 1 NOT NULL
)

--create Table  Departments
CREATE TABLE [Departments](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[Financing] MONEY CHECK([Financing]>=0) DEFAULT 0 NOT NULL,
[Name] NVARCHAR (100) UNIQUE CHECK([Name]<>'') NOT NULL,
)

--create Table  Faculties
CREATE TABLE [Faculties](
[id] INT  IDENTITY(1,1) PRIMARY KEY, 
[Name] NVARCHAR (100) UNIQUE CHECK([Name]<>'') NOT NULL,
)

--create Table  Teachers
CREATE TABLE [Teachers](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[EmploymentDate] DATE CHECK([EmploymentDate]>='0.1,0.1,1990') NOT NULL,
[Name] NVARCHAR (MAX) CHECK([Name]<>'') NOT NULL,
[Surname] NVARCHAR (MAX) CHECK([Name]<>'') NOT NULL,
[Salary] MONEY CHECK([Salary]>0) NOT NULL,
[Premium] MONEY CHECK([Salary]>=0) DEFAULT 0 NOT NULL,
[IsAssistent] BIT DEFAULT 0 NOT NULL,
[IsProfessor] BIT DEFAULT 0 NOT NULL,
)
/*------------------------------------------------------*/


/****************************_2_***************************/

create new db
CREATE DATABASE Business
GO
USE Business
GO

--Create customer Table
CREATE TABLE [Ñustomer](
[id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) CHECK([Name]<>'') NOT NULL,
[SureName] NVARCHAR(30) CHECK([SureName]<>'') NOT NULL,
[Phone] NVARCHAR(15) CHECK([Phone]<>'') NOT NULL,
)

--Create cart table
CREATE TABLE [Cart](
[ÑustomerId] INT NOT NULL,
[Products] NVARCHAR(30) NOT NULL,
[Price] MONEY CHECK ([Price]>0),
[QuantityProduct] INT CHECK([QuantityProduct]>0) NOT NULL,
FOREIGN KEY ([ÑustomerId]) REFERENCES [Ñustomer](Id),
)

--Add info in table customer
INSERT INTO  [Ñustomer] ([Name],[SureName],[Phone]) VALUES ('SOME NAME','SOME SureName','22-22-222-22')
INSERT INTO  [Ñustomer] ([Name],[SureName],[Phone]) VALUES ('ANY NAME','ANY SureName','23-23-232-23')

--Add info in table cart
INSERT INTO  [Cart] ([Products],[Price],[QuantityProduct],[ÑustomerId]) VALUES ('SOME Product','122','3','1')
INSERT INTO  [Cart] ([Products],[Price],[QuantityProduct],[ÑustomerId]) VALUES ('ANY Product','132','1','1')
INSERT INTO  [Cart] ([Products],[Price],[QuantityProduct],[ÑustomerId]) VALUES ('ANY Product','132','5','2')

SELECT* FROM [Cart] 
SELECT* FROM [Ñustomer]    

DELETE [Cart] WHERE [ÑustomerId]=1

SELECT* FROM [Cart] 
SELECT* FROM [Ñustomer] 


--Create product table
CREATE TABLE [Product](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Title] NVARCHAR(30) UNIQUE CHECK([Title]<>'') NOT NULL,
[Price] MONEY  CHECK([Price]>0) NOT NULL,
)
--Create shop table
CREATE TABLE [Shop](
[Title]VARCHAR(15)NOT NULL,
[TITLEProductId] NVARCHAR(30) NOT NULL,
[Count] INT CHECK([Count]>=0) DEFAULT 0 NOT NULL,
FOREIGN KEY ([TITLEProductId]) REFERENCES [Product]([Title]),--Connection with  title for the experiment
)

--Add info in table product
INSERT INTO [Product] ([Title],[Price])VALUES ('Some Product','9.99')
INSERT INTO [Product] ([Title],[Price])VALUES ('Any Product','10.99')

--Add info in table shop
INSERT INTO [Shop] ([Title],[TITLEProductId],[Count])VALUES ('ANY SHOP','Some Product','50')
INSERT INTO [Shop] ([Title],[TITLEProductId],[Count])VALUES ('ANY SHOP','Any Product','12')

SELECT* FROM [Product]
SELECT* From  [Shop]

/*------------------------------------------------------*/

/***********************************_3_*************************/

CREATE DATABASE Hospital
GO
USE Hospital

CREATE TABLE [Doctors](
[id] INT  IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30)   CHECK([Name]<>'') NOT NULL,
[Surname] NVARCHAR (30) CHECK([Surname]<>'') NOT NULL,
[speciality] NVARCHAR (30)CHECK([speciality]<>'') NOT NULL,
)


INSERT INTO [Doctors]([Name],[Surname],[speciality]) VALUES ('SOME NAME','SOME SureNAME','Surgery')
INSERT INTO [Doctors]([Name],[Surname],[speciality]) VALUES ('Any NAME','Any SureNAME','Surgery')

CREATE TABLE [Department](
[id] INT PRIMARY KEY IDENTITY(1,1),
[Title]VARCHAR(15)CHECK([Title]<>'') NOT NULL,
[Phone] NVARCHAR(15) CHECK([Phone]<>'') NOT NULL,
[DocId] INT NOT NULL,
FOREIGN KEY ([DocId]) REFERENCES [Doctors]([id])
)

SELECT* From [Doctors] Where [id]=1

INSERT INTO [Department]([Title],[Phone],[DocId]) VALUES ('Surgery','125-325-25','1')
INSERT INTO [Department]([Title],[Phone],[DocId]) VALUES ('Surgery','125-3505-25','2')

SELECT* FROM [Department] 



CREATE TABLE [Patients](
[id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(30) CHECK([Name]<>'') NOT NULL,
[SureName] NVARCHAR(30) CHECK([SureName]<>'') NOT NULL,
[DateB]DATE NOT NULL,
[Age]INT NOT NULL,
[Phone] NVARCHAR(15),
[HealthComplaints] NVARCHAR(MAX) NOT NULL, 
[State] NVARCHAR(30)NOT NULL,
[ReceiptDate] DATE NOT NULL,
[Department] NVARCHAR(15)  DEFAULT 'Reception' NOT NULL,
)

--GETUTCDATE ( )

INSERT INTO [Patients] VALUES ('Bob','Chudic',CAST('2000-12-30' as datetime),'23','033-25-36','Any Complaints','Normal',CAST('2023-12-30' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Anna','Cubric',CAST('2012-11-30' as datetime),'11','777-222-333','No Complaints','Midlle',CAST('2023-12-17' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Vasya','Petichkin',CAST('1999-12-30' as datetime),'24','322-233-322','Pain','Normal',CAST('2023-11-22' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Sandro','Pedro',CAST('1990-12-30' as datetime),'34','555-10-22-33','wreck','Critical',CAST('2023-12-25' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Huan','Carlos',CAST('2001-12-30' as datetime),'22','322-233-322','No Complaints','Critical',CAST('2023-12-25' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Pedro','Pedro',CAST('1982-12-30' as datetime),'41','555-10-22-33','wreck','Critical',CAST('2023-11-25' as datetime),'Reception')

INSERT INTO [Patients] VALUES ('Valera','Ivanovich',CAST('1933-12-30' as datetime),'90','111-55-66','Any Complaints','Normal',CAST('2023-12-30' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Anna','Frosivna',CAST('2003-12-30' as datetime),'20','235-666-777','No Complaints','Midlle',CAST('2023-12-17' as datetime),'Reception')
INSERT INTO [Patients] VALUES ('Vasya','Vasichkin',CAST('2003-12-30' as datetime),'20','322-233-322','Pain','Normal',CAST('2023-10-22' as datetime),'pediatrics')
INSERT INTO [Patients] VALUES ('Huan','Pedro',CAST('2005-12-30' as datetime),'18','555-10-22-33','wreck','Critical',CAST('2023-11-25' as datetime),'Surgery')
INSERT INTO [Patients] VALUES ('Sandro','Carlos',CAST('2007-12-30' as datetime),'16','322-233-322','No Complaints','Critical',CAST('2023-12-18' as datetime),'Surgery')
INSERT INTO [Patients] VALUES ('Vasya','Vasichkin',CAST('2009-12-30' as datetime),'14','322-233-322','Pain','Normal',CAST('2023-09-25' as datetime),'Reception')



SELECT* FROM [Department]

SELECT* FROM [Patients] --All Patient

SELECT* FROM [Patients] WHERE [Department]='Surgery'

SELECT [Title] FROM [Department]

SELECT* FROM [Patients] WHERE DATEDIFF(month,[ReceiptDate], GETUTCDATE ( ))>1 ORDER BY [ReceiptDate]

SELECT* FROM [Patients] WHERE [Age]=(SELECT MIN(DATEDIFF(YEAR,[DateB], GETUTCDATE ( )))From [Patients] )

SELECT* FROM [Patients] WHERE [Name] LIKE 'P%'


/*-----------------------------------------------------------*/
