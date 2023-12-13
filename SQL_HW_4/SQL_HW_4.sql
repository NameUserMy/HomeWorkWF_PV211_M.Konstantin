
BEGIN /************************_Students_*******************/

CREATE DATABASE Students

Use Students

BEGIN --Create table ([Studens],[Marks])

CREATE TABLE [Students](
[Id] INT PRIMARY KEY IDENTITY(1,1), 
[Name]NVARCHAR(30) CHECK([Name]<>'')NOT NULL,
[Age] INT CHECK([Age]>0)NOT NULL,
)

CREATE TABLE [Marks](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Mark] SMALLINT NOT NULL,
[StudentId] INT NOT NULL,
FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id])
)
END;

BEGIN --Fill info for table
INSERT INTO [Students] VALUES ('Petya','18'),
('Helga','22'),('Elis','20'),('Nicolos','19'),
('John','22'),('Bob','20')

INSERT INTO [Marks] VALUES ('120','1'),('110','1'),('120','1'),
('80','2'),('80','2'),('100','3'),('95','4'),('95','6')
END;



SELECT  [Name]  FROM [Students]   WHERE Students.[Age]>(SELECT AVG([Students].[Age]) FROM [Students])

SELECT [Age],  Count([Name]) AS 'Couunt Student'  FROM [Students] GROUP BY [Age]

SELECT [Age] FROM [Students] GROUP BY [Age] HAVING Count([Name])>1   

SELECT [Name]  FROM [Students],[Marks] WHERE [Students].[Id] = [Marks].[StudentId]  GROUP BY [Name]      
HAVING AVG([Mark])>80 

SELECT [Name]   FROM [Students],[Marks] WHERE [Students].[Id] = [Marks].[StudentId]  
GROUP BY [Name] HAVING MAX([Mark])>90

SELECT [Name]   FROM [Students],[Marks] WHERE [Students].[Id] = [Marks].[StudentId]  
GROUP BY [Name] HAVING SUM([Mark])>200


SELECT [Age],  Count([Name]) AS 'Couunt Student'  FROM [Students],[Marks] WHERE [Students].[Id]=[Marks].[StudentId] AND [Age]=20  
GROUP BY [Age] HAVING AVG([Mark])>85


SELECT [Mark],  Count([Name]) AS 'Couunt MARK'  FROM [Students],[Marks] WHERE [Students].[Id]=[Marks].[StudentId] GROUP BY [Mark] HAVING Count([Name])>1

SELECT  [Name]  FROM [Students]   WHERE Students.[Age]>(SELECT AVG([Students].[Age]) FROM [Students])

SELECT [Age] FROM [Students] GROUP BY [Age] HAVING Count([Name])>1

SELECT [Name]  FROM [Students],[Marks] WHERE [Students].[Id] = [Marks].[StudentId]  GROUP BY [Name]      
HAVING AVG([Mark])>80 
/*----------------------------------------------------------------------*/
END;


BEGIN /************************_Courses_*******************/

CREATE DATABASE Courses

USE Courses



BEGIN --Create table ([Studens],[Marks],[Courses],[StudentsOnCourses](Many to many))
CREATE TABLE [Students](
[Id] INT PRIMARY KEY IDENTITY(1,1), 
[Name]NVARCHAR(30) CHECK([Name]<>'')NOT NULL,
[Age] INT CHECK([Age]>0)NOT NULL,
)

CREATE TABLE [Marks](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Mark] SMALLINT DEFAULT 0 NOT NULL,
[StudentMarkId] INT NOT NULL,
[Credit] SMALLINT DEFAULT 0 NOT NULL,
FOREIGN KEY ([StudentMarkId]) REFERENCES [Students]([Id])
)

CREATE TABLE [Courses](
[Id] INT PRIMARY KEY IDENTITY(1,1),
[Title]NVARCHAR(30) CHECK([Title]<>'')NOT NULL,
)

CREATE TABLE [StudentsOnCourses](
[StudentId] INT  NOT NULL,
[CoursesId] INT  NOT NULL,
CONSTRAINT PK_StudentsOnCourses PRIMARY KEY ([StudentId],[CoursesId]),
FOREIGN KEY ([StudentId]) REFERENCES [Students](Id),
FOREIGN KEY ([CoursesId]) REFERENCES [Courses](Id),
)


END;


BEGIN --Fill info for table
INSERT INTO [Students] VALUES ('Petya','18'),
('Helga','22'),('Elis','20'),('Nicolos','19'),
('John','22'),('Bob','20'),('Nataly','32'),('Olga','25')

INSERT INTO [Marks] VALUES ('120','1','0'),('110','1','10'),('120','1','2'),
('80','2','12'),('80','2','18'),('100','3','33'),('95','4','12'),('95','6','8'),('75','8','8')

INSERT INTO [Courses] VALUES ('English'),('Management'),('3D graphics'),('information Technology'),('Programming')

INSERT INTO [StudentsOnCourses] ([StudentId],[CoursesId]) VALUES ('1','1'),('1','2'),('7','1'),('7','2'),('5','1'),('5','5'),('8','3')

END;


SELECT AVG([Age]) AS 'AVG age students' FROM [Students]

SELECT [Title], COUNT([Students].[Name]) AS 'Count Students in Group' FROM [Courses],[Students],[StudentsOnCourses] 
WHERE [StudentsOnCourses].CoursesId=[Courses].Id AND [StudentsOnCourses].StudentId=[Students].Id  GROUP BY [Title]

SELECT [Title], MAX([Marks].[Mark]) AS 'MAX Mark' FROM [Courses],[Students],[StudentsOnCourses],[Marks] 
WHERE [StudentsOnCourses].CoursesId=[Courses].[Id] AND [StudentsOnCourses].StudentId=[Students].[Id] AND [Marks].StudentMarkId=[Students].[Id]  GROUP BY [Title]

SELECT SUM([Marks].[Credit]) AS 'Credit count' FROM [Marks]

SELECT [Name]  FROM [Students],[Marks] WHERE [Students].[Id] = [Marks].[StudentMarkId]  GROUP BY [Name]      
HAVING AVG([Mark])>90

SELECT [Title], COUNT([Students].[Name]) AS 'Count Students in Group MArk > 80' FROM [Courses],[Students],[StudentsOnCourses],[Marks] 
WHERE [StudentsOnCourses].CoursesId=[Courses].Id AND [StudentsOnCourses].StudentId=[Students].Id AND [Marks].StudentMarkId=[Students].[Id]  GROUP BY [Title]
HAVING MAX([Mark])>80

SELECT [Name]  FROM [Students] WHERE [Students].[Age]=(SELECT MAX([Age]) FROM [Students]) 

SELECT [Title] FROM [Courses],[Students],[StudentsOnCourses],[Marks] 
WHERE [StudentsOnCourses].CoursesId=[Courses].Id AND [StudentsOnCourses].StudentId=[Students].Id AND [Marks].StudentMarkId=[Students].[Id]  GROUP BY [Title]
HAVING AVG([Mark])<80  

/*-------------------------------------------------------------*/
END;

--SELECT COUNT(DISTINCT [Age]) FROM [Students] GROUP BY [Name],[Age]




 
