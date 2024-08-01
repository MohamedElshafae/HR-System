--
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE hr;

--
-- Create table `Roles`
--
CREATE TABLE Roles (
  RoleID int NOT NULL AUTO_INCREMENT,
  RoleTitle varchar(100) NOT NULL,
  PRIMARY KEY (RoleID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create table `Departments`
--
CREATE TABLE Departments (
  DepartmentID int NOT NULL AUTO_INCREMENT,
  DepartmentName varchar(100) NOT NULL,
  PRIMARY KEY (DepartmentID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create table `Employee`
--
CREATE TABLE Employee (
  EmployeeID int NOT NULL AUTO_INCREMENT,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  Email varchar(100) NOT NULL,
  Phone varchar(15) DEFAULT NULL,
  NationalID varchar(20) DEFAULT NULL,
  DepartmentID int DEFAULT NULL,
  RoleID int DEFAULT NULL,
  HireDate date DEFAULT NULL,
  DateOfBirth date DEFAULT NULL,
  Gender varchar(50) DEFAULT NULL,
  Address varchar(50) DEFAULT NULL,
  ManagerID int DEFAULT NULL,
  PRIMARY KEY (EmployeeID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `Email` on table `Employee`
--
ALTER TABLE Employee
ADD UNIQUE INDEX Email (Email);

--
-- Create index `NationalID` on table `Employee`
--
ALTER TABLE Employee
ADD UNIQUE INDEX NationalID (NationalID);

--
-- Create foreign key
--
ALTER TABLE Employee
ADD CONSTRAINT Employee_ibfk_1 FOREIGN KEY (DepartmentID)
REFERENCES Departments (DepartmentID) ON DELETE CASCADE;

--
-- Create foreign key
--
ALTER TABLE Employee
ADD CONSTRAINT Employee_ibfk_2 FOREIGN KEY (RoleID)
REFERENCES Roles (RoleID) ON DELETE CASCADE;

--
-- Create foreign key
--
ALTER TABLE Employee
ADD CONSTRAINT Employee_ibfk_3 FOREIGN KEY (ManagerID)
REFERENCES Employee (EmployeeID) ON DELETE CASCADE;

--
-- Create table `User`
--
CREATE TABLE User (
  UserName varchar(100) NOT NULL,
  Password varchar(100) NOT NULL,
  EmployeeID int DEFAULT NULL,
  PRIMARY KEY (UserName)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `EmployeeID1` on table `User`
--
ALTER TABLE User
ADD INDEX EmployeeID1 (EmployeeID);

--
-- Create foreign key
--
ALTER TABLE User
ADD CONSTRAINT User_ibfk_1 FOREIGN KEY (EmployeeID)
REFERENCES Employee (EmployeeID) ON DELETE CASCADE;

--
-- Create table `Attachments`
--
CREATE TABLE Attachments (
  AttachmentID int NOT NULL AUTO_INCREMENT,
  UploadedDate date DEFAULT NULL,
  FilePath varchar(255) DEFAULT NULL,
  EmployeeID int DEFAULT NULL,
  FileType int NOT NULL,
  PRIMARY KEY (AttachmentID)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create foreign key
--
ALTER TABLE Attachments
ADD CONSTRAINT Attachments_ibfk_1 FOREIGN KEY (EmployeeID)
REFERENCES Employee (EmployeeID) ON DELETE CASCADE;