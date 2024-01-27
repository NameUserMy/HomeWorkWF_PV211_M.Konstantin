
CREATE DATABASE ChroniclesOfAscents

USE ChroniclesOfAscents


CREATE TABLE MountaineerGroup(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) CHECK([Name]<>'') NOT NULL,
)

CREATE TABLE Mountaineer(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) CHECK([Name]<>'') NOT NULL,
[Adress] NVARCHAR(30) CHECK([Adress]<>'') NOT NULL,
[GroupId] INT NOT NULL,
FOREIGN KEY ([GroupId]) REFERENCES MountaineerGroup([Id]),
)

CREATE TABLE Mountain
(
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR (120) CHECK ([Name]<>'') NOT NULL,
[Height] FLOAT CHECK ([Height]>0.0) NOT NULL,
[Country] NVARCHAR (120) CHECK ([Country]<>'') NOT NULL,
);

CREATE TABLE Climbing(
[MountaineerGroupID] INT NOT NULL,
[MountainID] INT NOT NULL,
[Start]DATE CHECK([Start]<>'') NOT NULL,
[Edn]DATE  DEFAULT GETDATE() NOT NULL,
[IsSuccess] BIT DEFAULT 0 NOT NULL,
CONSTRAINT PK_Group_Mountain PRIMARY KEY ([MountainID],[MountaineerGroupID],[Start]),

)

--Create procedure CRUD

--group Mountaineer
GO
CREATE PROCEDURE sp_AddMountaineerGroup
@name NVARCHAR(20)
AS
INSERT INTO MountaineerGroup([Name])VALUES(@name) 
GO
CREATE PROCEDURE sp_updateMountaineerGroup
@name NVARCHAR(20),
@id INT
AS
UPDATE MountaineerGroup SET [Name]=@name WHERE [Id]=@id
GO
CREATE PROCEDURE sp_deleteMountaineerGroup
@id INT
AS
DELETE MountaineerGroup  WHERE [Id]=@id
--end

-- Mountaineer
GO
CREATE PROCEDURE sp_AddMountaineer
@name NVARCHAR(20),
@adress NVARCHAR (30),
@groupId INT
AS
INSERT INTO Mountaineer([Name],[Adress],[GroupId])VALUES(@name,@adress,@groupId) 

GO
CREATE PROCEDURE sp_updateMountaineer
@name NVARCHAR(20),
@adress NVARCHAR (30),
@groupId INT,
@Id INT
AS
UPDATE Mountaineer SET [Name]=@name,[Adress]=@adress,[GroupId]=@groupId WHERE Mountaineer.[Id]=@Id

GO
CREATE PROCEDURE sp_deleteMountaineer
@Id INT
AS
DELETE Mountaineer  WHERE Mountaineer.[Id]=@Id
--end

--Mountain


GO
CREATE PROCEDURE sp_AddMountain
@name NVARCHAR(20),
@height FLOAT,
@country NVARCHAR (20)
AS
INSERT INTO Mountain([Name],[Height],[Country])VALUES(@name,@height,@country)

GO
CREATE PROCEDURE sp_updateMountain
@name NVARCHAR(20),
@height FLOAT,
@country NVARCHAR (20),
@Id INT
AS
UPDATE  Mountain SET  [Name]=@name,[Height]=@height,[Country]=@country WHERE Mountain.[Id]=@Id

GO
CREATE PROCEDURE sp_deleteMountain
@Id INT
AS
DELETE  Mountain WHERE Mountain.[Id]=@Id


--end
GO
CREATE PROCEDURE sp_Climbing
@MountaineerGroupID INT,
@MountainID INT,
@start DATE,
@end DATE
AS
INSERT INTO Climbing([MountaineerGroupID],[MountainID],[Start],[Edn])VALUES(@MountaineerGroupID,@MountainID,@start,@end)
-- end


--Create procedure General operation 

GO
CREATE PROCEDURE sp_listGroup
AS
BEGIN
SELECT MountaineerGroup.[Name] ,Mountain.[Name] ,Climbing.[Start]  FROM MountaineerGroup JOIN Climbing ON MountaineerGroup.[Id]=Climbing.[MountaineerGroupID]
JOIN Mountain ON Mountain.[Id]=Climbing.MountainID ORDER BY Climbing.[Start]
END;

GO
CREATE PROCEDURE sp_getСlimbersRangeDate
@startRange DATE,
@endRange DATE
AS
BEGIN
SELECT Mountaineer.[Name],Climbing.[Start] FROM Mountaineer JOIN MountaineerGroup ON Mountaineer.[GroupId]=MountaineerGroup.[Id]
JOIN Climbing ON Climbing.[MountaineerGroupID]=MountaineerGroup.[Id] WHERE Climbing.[Start] >= @startRange AND Climbing.[Start]<=@endRange
END;


GO
CREATE PROCEDURE sp_getCountClimbing
AS
BEGIN
SELECT Mountaineer.[Name],Mountain.[Name],COUNT(Mountain.[Id]) FROM Mountaineer JOIN Climbing ON Mountaineer.[GroupId]=Climbing.[MountaineerGroupID] 
JOIN Mountain ON Mountain.[Id]=Climbing.[MountainID] GROUP BY Mountaineer.[Name],Mountain.[Name]
END;

GO
CREATE PROCEDURE sp_countMountaineerOnMountain
AS
BEGIN
SELECT Mountain.[Name],COUNT(Mountaineer.[Id]) FROM Mountaineer JOIN Climbing ON Mountaineer.[GroupId]=Climbing.[MountaineerGroupID] 
JOIN Mountain ON Mountain.[Id]=Climbing.[MountainID] GROUP BY Mountain.[Name]
END;

GO
Alter PROCEDURE sp_updateInfoClimbing
@MountaineerGroupID INT,
@MountainID INT,
@start DATE,
@end DATE,
@isSuccess BIT
AS
BEGIN
UPDATE Climbing SET [MountaineerGroupID]=@MountaineerGroupID,[Start]=@start,[Edn]=@end,[IsSuccess]=@isSuccess
WHERE [MountaineerGroupID]=@MountaineerGroupID AND [MountainID]=@MountainID AND [Start]=@start 
END;



GO 
ALTER PROCEDURE sp_addNewGroup
@groupName NVARCHAR(20),
@MountainID INT,
@start DATE
AS
DECLARE @groupId INT
BEGIN TRANSACTION
INSERT INTO MountaineerGroup VALUES (@groupName)
SELECT @groupId= SCOPE_IDENTITY()
COMMIT TRANSACTION 
INSERT INTO Climbing([MountaineerGroupID],[MountainID],[Start])VALUES(@groupId,@MountainID,@start)

--end





SELECT * from Climbing 

--Предоставить возможность добавления нового альпиниста в состав указанной группы; 