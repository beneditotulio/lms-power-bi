CREATE DATABASE LibraryDB
GO

USE LibraryDB
GO

--DATABASE BACKUP SCRIPT
DECLARE @BackupPath NVARCHAR(255)
DECLARE @BackupFileName NVARCHAR(255)
DECLARE @DateTimeStamp NVARCHAR(50)

-- Define the backup path
SET @BackupPath = 'C:\IP\workspace\'

-- Generate the current date and time as a string (YYYYMMDD_HHMMSS)
SET @DateTimeStamp = REPLACE(CONVERT(NVARCHAR(50), GETDATE(), 120), ':', '')

-- Construct the backup filename with the current date and time
SET @BackupFileName = @BackupPath + 'LibraryDB_' + @DateTimeStamp + '.bak'

-- Backup the database to the dynamically generated filename
BACKUP DATABASE YourDatabaseName
TO DISK = @BackupFileName
WITH INIT; -- INIT creates a new backup set
GO


/*
begin region
25/09/2023
Created by IP
*/
CREATE TABLE Authors (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    AuthorName NVARCHAR(255),
    DateOfBirth DATE,
    CountryOfOrigin NVARCHAR(100),
    Biography NVARCHAR(MAX), -- Author's biography
    Website NVARCHAR(255),   -- Author's website URL
    Email NVARCHAR(255),     -- Author's contact email
    Phone NVARCHAR(20)       -- Author's contact phone number
    -- Add any other relevant author information columns here
);

/*
end region
25/09/2023
Created by IP
*/