
/*----------------------------1---------------------------*/

-- Create DB Casino
CREATE DATABASE Casino
GO
--USE Casino
GO
-- Create TABLE Card
CREATE TABLE [Card](
[GameDate] DATE,
[Winning] DECIMAL,
[GameDescription] NVARCHAR(60),
[Weight] TINYINT,
[QuantitySeats] TINYINT
)
Go
--fill table

INSERT INTO [Card] ([GameDate],[Winning],[GameDescription],[Weight],[QuantitySeats])
VALUES (GETUTCDATE ( ),'3000','SOME Description','120','5')
GO
--Rename Table
SP_RENAME [Card],[Automate]
GO
-- Delete info 
DELETE FROM [Automate]
GO
--Delete table
DROP TABLE [Automate]
GO
--Create new table
CREATE TABLE [Card](
[GameDate] DATE,
[Winning] DECIMAL,
[GameDescription] NVARCHAR(60),
[Weight] TINYINT,
[QuantitySeats] TINYINT
)
Go
ALTER TABLE [Card] ADD [Id] INT PRIMARY KEY IDENTITY(1,1)--Add new Column 
ALTER TABLE [Card] ALTER COLUMN [Weight] TINYINT NOT NULL -- Change colimn attribute
ALTER TABLE [Card] ALTER COLUMN [QuantitySeats] TINYINT NOT NULL -- Change colimn attribute
ALTER TABLE [Card] ADD CHECK ([Winning]>=1 AND [Winning]<=1000000)-- Add colimn attribute range
GO
INSERT INTO [Card] ([GameDate],[Winning],[GameDescription],[Weight],[QuantitySeats]) --try add info invalide range
VALUES (GETUTCDATE ( ),'0','SOME Description','0','5')

INSERT INTO [Card] ([GameDate],[Winning],[GameDescription],[QuantitySeats]) --try add info invalide NULL
VALUES (GETUTCDATE ( ),'25000','SOME Description','5')
/**************************************************************************************************************/


/*---------------------------- 2 ---------------------------*/
-- create new database
CREATE DATABASE Shop
GO
-- Pick our new data base
USE Shop 
Go
--Create new  table in database
CREATE TABLE [Product](
 [Id] INT PRIMARY KEY IDENTITY(1,1), 
 [Name] NVARCHAR(35) NOT NULL, 
 [Count] INT, 
 [Price] DECIMAL(10,2) CHECK ([Price]>0),
 [Date] DATE
)
GO
-- Fill Table
INSERT INTO [Product] ([Name],[Count],[Price],[Date]) VALUES ('SOME NAME','1','125',GETUTCDATE ( ))
INSERT INTO [Product] ([Name],[Count],[Price],[Date]) VALUES ('Any Name','25','300',GETUTCDATE ( ))
INSERT INTO [Product] ([Name],[Count],[Price],[Date]) VALUES ('SOME ANY NAME','3','425',GETUTCDATE ( ))
GO
-- Show all info
SELECT* FROM [Product]
GO
ALTER TABLE [Product] ADD [Rating] INT NOT NULL DEFAULT  '0' -- ADD new column
ALTER TABLE [Product] DROP COLUMN [Count] --Delete column Count 
/**************************************************************************************************************/

/*----------------------------3---------------------------*/

--Create new  table in database
CREATE DATABASE UseConnection
GO
-- Pick our new data base
USE UseConnection
GO
--Create new  table in database
CREATE TABLE [Category](
 [Id] INT PRIMARY KEY IDENTITY(1,1), 
 [Name] NVARCHAR(35) NOT NULL, 
 [Date] DATE
)
GO
CREATE TABLE [Product](
 [Id] INT PRIMARY KEY IDENTITY(1,1),
 [CategoryID] INT NOT NULL,
 [Name] NVARCHAR(35) NOT NULL, 
 [Count] INT, 
 [Price] DECIMAL(10,2) CHECK ([Price]>0),
 [Date] DATE
 FOREIGN KEY ([CategoryID]) references [Category] (Id)-- create connection from category
)
GO
INSERT INTO [Category] ([Name],[Date]) VALUES ('SOME CATEGORY', GETUTCDATE ( ))-- add category
GO
INSERT INTO [Product] ([Name],[Price],[Date],[CategoryID]) VALUES ('SOME1 Product','120', GETUTCDATE ( ),'1')--add product with category
INSERT INTO [Product] ([Name],[Price],[Date],[CategoryID]) VALUES ('SOME1 Product','120', GETUTCDATE ( ),'2')-- error no category 2

SELECT* FROM [Product]

/**************************************************************************************************************/

/*----------------------------4---------------------------*/
--Create new  table in database
CREATE DATABASE OrderCustomer
GO
-- Pick our new data base
USE OrderCustomer
GO
--Create new  table in database
CREATE TABLE [Order](
 [Id] INT PRIMARY KEY IDENTITY(1,1), 
 [Title] NVARCHAR(35) NOT NULL,
 [TotalSum] Decimal(10,2),
 [Count] INT  CHECK ([Count]>0),
 [Price] DECIMAL(10,2) CHECK ([Price]>0),
 [Date] DATE,
 )
GO
CREATE TABLE [Customer](
 [Id] INT PRIMARY KEY IDENTITY(1,1),
 [OrderID] INT NOT NULL,
 [Name] NVARCHAR(35) NOT NULL, 
 [Date] DATE
 CONSTRAINT FK_Order FOREIGN KEY ([OrderID]) references [Order] (Id) ON DELETE CASCADE-- create connection from order
)

GO
INSERT INTO [Order] ([Title],[Count],[Price],[Date]) VALUES ('SOME Order','1','145', GETUTCDATE ( ))-- add order
INSERT INTO [Order] ([Title],[Count],[Price],[Date]) VALUES ('SOME Order','2','175', GETUTCDATE ( ))
GO

INSERT INTO [Customer]([Name],[OrderID],[Date]) VALUES ('SOME NAME','1',GETUTCDATE ( ))-- add customer
INSERT INTO [Customer]([Name],[OrderID],[Date]) VALUES ('SOME NAME','2',GETUTCDATE ( ))
INSERT INTO [Customer]([Name],[OrderID],[Date]) VALUES ('SOME NAME','2',GETUTCDATE ( ))
GO
SELECT* FROM [Customer]
SELECT* FROM [Order]

GO
DELETE [Order] WHERE ID=2

Drop TABLE [Customer]
Drop TABLE [Order]

/**************************************************************************************************************/