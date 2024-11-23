USE master;

-- Drop database
IF DB_ID('Students') IS NOT NULL DROP DATABASE Students;

-- If database could not be created due to open connections, abort
IF @@ERROR = 3702 
   RAISERROR('Database cannot be dropped because there are still open connections.', 127, 127) WITH NOWAIT, LOG;

-- Create database
CREATE DATABASE Students;
GO

USE Students;
GO

CREATE TABLE students (
    id bigint IDENTITY(1,1) PRIMARY KEY,
    first_name nvarchar(100) NOT NULL,
    last_name nvarchar(100) NOT NULL,
    date_of_birth date NOT NULL,
    email nvarchar(255) UNIQUE NOT NULL,
    identification nvarchar(255) UNIQUE NOT NULL
);



