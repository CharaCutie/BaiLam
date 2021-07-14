/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [StudentID]
      ,[StudentName]
      ,[BirthOfDate]
      ,[Addresses]
      ,[Picture]
  FROM [Users].[dbo].[DBSession]