CREATE DATABASE QulixDatabase;
GO
USE [QulixDatabase];

	CREATE TABLE [dbo].[Companies](
	[Id] [int] NOT NULL UNIQUE,
	[Name] [nvarchar](50) NOT NULL,
	[LawForm] [nvarchar](50) NOT NULL);

	INSERT INTO [Companies] (Id, Name, LawForm)
	VALUES (1, 'Apple', 'OOO');

	INSERT INTO [Companies] (Id, Name, LawForm)
	VALUES (2, 'Intel', 'OAO');

	CREATE TABLE [dbo].[Employees](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50),
	[Date] [datetime] NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL)

	INSERT INTO [Employees] (Id, Surname, Name, MiddleName, Date, Position , CompanyId)
	VALUES (1, 'John', 'Smith','Aleksandrovich','2020-06-18T10:34:09', 'Developer' , 2);

	INSERT INTO [Employees] (Id, Surname, Name, MiddleName, Date, Position , CompanyId)
	VALUES (2, 'Alex', 'Williams','Victorovich','2020-06-19T10:34:09', 'QA' , 1);	

