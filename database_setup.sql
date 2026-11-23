-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'db_OOP')
    CREATE DATABASE db_OOP;

USE db_OOP;


-- Create the login info table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tbl_logInfo' and xtype='U')
    CREATE TABLE tbl_logInfo (
        id_info INT IDENTITY(1,1) PRIMARY KEY,
        user_name NVARCHAR(100) NOT NULL,
        pass_word NVARCHAR(100) NOT NULL,
        is_active BIT DEFAULT 1
    );


-- Insert a default test account so everyone can log in immediately

    INSERT INTO tbl_logInfo (user_name, pass_word) VALUES ('nat', '123');

drop table tbl_logInfo;
select * from tbl_logInfo;

