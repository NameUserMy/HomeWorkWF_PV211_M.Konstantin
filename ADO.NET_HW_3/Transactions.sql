CREATE DATABASE MyTransactions
USE MyTransactions

CREATE TABLE [Accounts] (

    [AccountID] INT PRIMARY KEY IDENTITY(10000, 1),
    [AccountNumber] NVARCHAR(20) UNIQUE,
    [Balance] DECIMAL(10, 2)

);


INSERT INTO [Accounts] VALUES('337585','20000'),('387585','25000')
SELECT * from [Accounts]

GO
CREATE PROCEDURE sp_test
@accountNumber NVARCHAR(20),
@amountTransfer DECIMAL(10,2),
@targetAccount NVARCHAR(20)
AS
BEGIN

BEGIN TRANSACTION
DECLARE @Balance DECIMAL(10, 2) 

IF EXISTS(SELECT [AccountNumber] FROM  Accounts WHERE [AccountNumber]=@accountNumber)
BEGIN
SELECT @Balance= [Balance] FROM [Accounts] WHERE [AccountNumber]=@accountNumber
END
IF(@Balance>=@amountTransfer) 
BEGIN
UPDATE [Accounts] SET [Balance]-=@amountTransfer WHERE [AccountNumber]=@accountNumber
END
ELSE 
BEGIN
ROLLBACK
PRINT 'NO money'
END

IF EXISTS(SELECT [AccountNumber] FROM  Accounts WHERE [AccountNumber]=@targetAccount)
BEGIN
UPDATE [Accounts] SET [Balance]+=@amountTransfer WHERE [AccountNumber]=@targetAccount
END
ELSE
BEGIN
ROLLBACK
PRINT 'NO Accaunt'
END
COMMIT TRANSACTION 

END;

EXEC sp_test @accountNumber='387585',@amountTransfer='200',@targetAccount='337585'

SELECT * from [Accounts]


-- Additional tasks

--- Storage
CREATE DATABASE Storage
USE Storage



CREATE TABLE Stock
(
[Id] INT PRIMARY KEY IDENTITY,
[StockName]NVARCHAR(50) DEFAULT 'Stock 1' CHECK([StockName]<>'')  NOT NULL
)

CREATE TABLE Ñategory
(
[Id] INT PRIMARY KEY IDENTITY,
[ÑategoryName]NVARCHAR(50) DEFAULT 'Category ' CHECK([ÑategoryName]<>'')  NOT NULL
)

CREATE TABLE Contractor(
[Id] INT PRIMARY KEY IDENTITY,
[ContractorName]NVARCHAR(50) CHECK([ContractorName]<>'')  NOT NULL,
)

CREATE TABLE Product
(
[Id] INT PRIMARY KEY IDENTITY,
[Name]NVARCHAR(50) CHECK([Name]<>'')  NOT NULL,
[Count] INT DEFAULT 1 CHECK([Count]>0) NOT NULL,
[StockId] INT NOT NULL,
[ÑategoryId]INT DEFAULT 0 NOT NULL,
[ContractorId]INT NOT NULL,
[SupplyDate] DATE DEFAULT GETDATE() NOT NULL,
FOREIGN KEY ([stockId]) REFERENCES Stock ([Id]),
FOREIGN KEY ([ÑategoryId]) REFERENCES Ñategory ([Id]),
FOREIGN KEY ([ContractorId]) REFERENCES Contractor ([Id])
)



INSERT INTO Stock VALUES ('First WareHouse')

INSERT INTO Contractor VALUES ('Best Contractor'),('Best Contractor 1')
INSERT INTO Ñategory VALUES ('My category'),('My category 1') 

INSERT INTO Product([Name],[ÑategoryId],[Count],[ContractorId],[StockId]) VALUES 
('BEST product 3','1','7','2','1'),('BEST product','1','15','1','1'),('BEST product 1','2','10','1','1')


SELECT * FROM Product




---

GO
CREATE PROCEDURE sp_selectAllProduct
AS
BEGIN
SELECT Product.[Name],Product.[Count],[ÑategoryName],[ContractorName],[StockName] FROM Product
JOIN Ñategory ON Ñategory.[Id]=Product.[ÑategoryId] 
JOIN Contractor ON Contractor.[id]=product.[ContractorId]
JOIN Stock ON Stock.[Id]=Product.[stockId]
END;


GO
CREATE PROCEDURE sp_selectMaxCoubtProduct
AS
BEGIN
SELECt TOP (1) Product.[Name],Product.[Count] FROM Product ORDER BY Product.[Count] DESC 
END;

GO
CREATE PROCEDURE sp_selectMinCoubtProduct
AS
BEGIN
SELECt TOP (1) Product.[Name],Product.[Count] FROM Product ORDER BY Product.[Count]
END;


GO
CREATE PROCEDURE sp_selectProduct
@productId INT
AS
BEGIN
SELECT Product.[Name],Product.[Count],[ÑategoryName],[ContractorName],[StockName] FROM Product
JOIN Ñategory ON Ñategory.[Id]=Product.[ÑategoryId] 
JOIN Contractor ON Contractor.[id]=product.[ContractorId]
JOIN Stock ON Stock.[Id]=Product.[stockId] WHERE Product.[Id]=@productId
END;

GO
CREATE PROCEDURE sp_selectAllContractor
AS
BEGIN
SELECT [ContractorName] FROM Contractor
END;


GO
CREATE PROCEDURE sp_selectProductByCategory
@CategoryId INT
AS
BEGIN
SELECT Product.[Name] FROM Product
JOIN Ñategory ON Ñategory.[Id]=Product.[ÑategoryId] 
WHERE Product.[ÑategoryId]=@CategoryId
END;


GO
CREATE PROCEDURE sp_selectProductByContractor
@ContractorId INT
AS
BEGIN
SELECT [Name] FROM Product JOIN Contractor ON Contractor.[Id]=Product.[ContractorId]
WHERE Contractor.[Id]=@ContractorId
END;


GO
CREATE PROCEDURE sp_selectOldProduct
AS
BEGIN
SELECt TOP (1) Product.[Name],Product.[SupplyDate] FROM Product ORDER BY Product.[SupplyDate]
END;


GO
CREATE PROCEDURE sp_selectAVGProductCategory
AS
BEGIN
SELECT [ÑategoryName], AVG(Product.[Count]) FROM Product 
JOIN Ñategory ON Ñategory.[Id]=Product.[ContractorId] GROUP BY [ÑategoryName]
END;


