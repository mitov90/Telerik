CREATE PROC dbo.usp_CreateTempTableCountReports
AS
    CREATE TABLE tmpTable
        (
          [Full Name] NVARCHAR(41) ,
          [Project name] NVARCHAR(50) ,
          [Department name] NVARCHAR(50) ,
          startDate DATETIME ,
          endDate DATETIME ,
          [Reports] INT
        )
GO