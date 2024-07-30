CREATE DATABASE IF NOT EXISTS hr;

USE hr;

CREATE TABLE Departments (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(100) NOT NULL 
);

CREATE TABLE Roles (
    RoleID int  PRIMARY KEY,
    RoleTitle VARCHAR(100) NOT NULL
    
);

create TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Phone VARCHAR(15),
    NationalID VARCHAR(20) UNIQUE,
    DepartmentID INT,
    RoleID INT,
    HireDate DATE,
    DateOfBirth DATE,
    Gender varchar(50),
    Address varchar(50),
    ManagerID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE,
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)ON DELETE CASCADE ,
    FOREIGN KEY (ManagerID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE
    
);



CREATE TABLE  AttachmentsType (
    AttachmentTypeID INT  PRIMARY KEY,
    TypeName varchar(255) NOT NULL DEFAULT 'DefaultType'
);

CREATE TABLE  Attachments (
    AttachmentID INT  PRIMARY KEY,
    UploadedDate DATE,
    FilePath VARCHAR(255),
    EmployeeID INT,
    AttachmentTypeID INT,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE,
    FOREIGN KEY (AttachmentTypeID) REFERENCES AttachmentsType(AttachmentTypeID) ON DELETE CASCADE
);

CREATE TABLE User (
    UserName VARCHAR(100) NOT NULL PRIMARY KEY,
    Password VARCHAR(100) NOT NULL,
    EmployeeID INT,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE

);



