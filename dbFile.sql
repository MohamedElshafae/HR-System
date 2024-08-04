--
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE hr;

--
-- Create table `Jobs`
--
CREATE TABLE Jobs (
  Id char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  JobTitle varchar(100) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create table `Departments`
--
CREATE TABLE Departments (
  Id char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  DepartmentName varchar(100) NOT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create table `Employees`
--
CREATE TABLE Employees (
  Id char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  FirstName varchar(50) NOT NULL,
  LastName varchar(50) NOT NULL,
  Email varchar(100) NOT NULL,
  Phone varchar(15) DEFAULT NULL,
  NationalID varchar(20) DEFAULT NULL,
  DepartmentID char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  JobID char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  HireDate date DEFAULT NULL,
  DateOfBirth date DEFAULT NULL,
  Gender varchar(50) DEFAULT NULL,
  Address varchar(50) DEFAULT NULL,
  ManagerID char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `Email` on table `Employees`
--
ALTER TABLE Employees
ADD UNIQUE INDEX Email (Email);

--
-- Create index `NationalID` on table `Employees`
--
ALTER TABLE Employees
ADD UNIQUE INDEX NationalID (NationalID);

--
-- Create foreign key
--
ALTER TABLE Employees
ADD CONSTRAINT Employee_ibfk_1 FOREIGN KEY (DepartmentID)
REFERENCES Departments (Id) ON DELETE CASCADE;

--
-- Create foreign key
--
ALTER TABLE Employees
ADD CONSTRAINT Employee_ibfk_2 FOREIGN KEY (JobID)
REFERENCES Jobs (Id) ON DELETE CASCADE;

--
-- Create foreign key
--
ALTER TABLE Employees
ADD CONSTRAINT Employee_ibfk_3 FOREIGN KEY (ManagerID)
REFERENCES Employees (Id) ON DELETE CASCADE;

--
-- Create table `Attachments`
--
CREATE TABLE Attachments (
  Id char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  UploadedDate date DEFAULT NULL,
  FilePath varchar(255) DEFAULT NULL,
  EmployeeID char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  FileType int NOT NULL,
  PRIMARY KEY (Id)
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
REFERENCES Employees (Id) ON DELETE CASCADE;

--
-- Create table `AspNetUsers`
--
CREATE TABLE AspNetUsers (
  Id varchar(255) NOT NULL,
  Discriminator varchar(13) NOT NULL,
  FirstName longtext DEFAULT NULL,
  LastName longtext DEFAULT NULL,
  EmployeeId char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  UserName varchar(256) DEFAULT NULL,
  NormalizedUserName varchar(256) DEFAULT NULL,
  Email varchar(256) DEFAULT NULL,
  NormalizedEmail varchar(256) DEFAULT NULL,
  EmailConfirmed tinyint(1) NOT NULL,
  PasswordHash longtext DEFAULT NULL,
  SecurityStamp longtext DEFAULT NULL,
  ConcurrencyStamp longtext DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `EmailIndex` on table `AspNetUsers`
--
ALTER TABLE AspNetUsers
ADD INDEX EmailIndex (NormalizedEmail);

--
-- Create index `IX_AspNetUsers_EmployeeId` on table `AspNetUsers`
--
ALTER TABLE AspNetUsers
ADD UNIQUE INDEX IX_AspNetUsers_EmployeeId (EmployeeId);

--
-- Create index `UserNameIndex` on table `AspNetUsers`
--
ALTER TABLE AspNetUsers
ADD UNIQUE INDEX UserNameIndex (NormalizedUserName);

--
-- Create foreign key
--
ALTER TABLE AspNetUsers
ADD CONSTRAINT FK_AspNetUsers_Employees_EmployeeId FOREIGN KEY (EmployeeId)
REFERENCES Employees (Id) ON DELETE CASCADE;

--
-- Create table `AspNetUserTokens`
--
CREATE TABLE AspNetUserTokens (
  UserId varchar(255) NOT NULL,
  LoginProvider varchar(255) NOT NULL,
  Name varchar(255) NOT NULL,
  Value longtext DEFAULT NULL,
  PRIMARY KEY (UserId, LoginProvider, Name)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create foreign key
--
ALTER TABLE AspNetUserTokens
ADD CONSTRAINT FK_AspNetUserTokens_AspNetUsers_UserId FOREIGN KEY (UserId)
REFERENCES AspNetUsers (Id) ON DELETE CASCADE;

--
-- Create table `AspNetUserLogins`
--
CREATE TABLE AspNetUserLogins (
  LoginProvider varchar(255) NOT NULL,
  ProviderKey varchar(255) NOT NULL,
  ProviderDisplayName longtext DEFAULT NULL,
  UserId varchar(255) NOT NULL,
  PRIMARY KEY (LoginProvider, ProviderKey)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `IX_AspNetUserLogins_UserId` on table `AspNetUserLogins`
--
ALTER TABLE AspNetUserLogins
ADD INDEX IX_AspNetUserLogins_UserId (UserId);

--
-- Create foreign key
--
ALTER TABLE AspNetUserLogins
ADD CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY (UserId)
REFERENCES AspNetUsers (Id) ON DELETE CASCADE;

--
-- Create table `AspNetUserClaims`
--
CREATE TABLE AspNetUserClaims (
  Id int NOT NULL AUTO_INCREMENT,
  UserId varchar(255) NOT NULL,
  ClaimType longtext DEFAULT NULL,
  ClaimValue longtext DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `IX_AspNetUserClaims_UserId` on table `AspNetUserClaims`
--
ALTER TABLE AspNetUserClaims
ADD INDEX IX_AspNetUserClaims_UserId (UserId);

--
-- Create foreign key
--
ALTER TABLE AspNetUserClaims
ADD CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY (UserId)
REFERENCES AspNetUsers (Id) ON DELETE CASCADE;

--
-- Create table `AspNetRoles`
--
CREATE TABLE AspNetRoles (
  Id varchar(255) NOT NULL,
  Name varchar(256) DEFAULT NULL,
  NormalizedName varchar(256) DEFAULT NULL,
  ConcurrencyStamp longtext DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `RoleNameIndex` on table `AspNetRoles`
--
ALTER TABLE AspNetRoles
ADD UNIQUE INDEX RoleNameIndex (NormalizedName);

--
-- Create table `AspNetUserRoles`
--
CREATE TABLE AspNetUserRoles (
  UserId varchar(255) NOT NULL,
  RoleId varchar(255) NOT NULL,
  PRIMARY KEY (UserId, RoleId)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `IX_AspNetUserRoles_RoleId` on table `AspNetUserRoles`
--
ALTER TABLE AspNetUserRoles
ADD INDEX IX_AspNetUserRoles_RoleId (RoleId);

--
-- Create foreign key
--
ALTER TABLE AspNetUserRoles
ADD CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY (RoleId)
REFERENCES AspNetRoles (Id) ON DELETE CASCADE;

--
-- Create foreign key
--
ALTER TABLE AspNetUserRoles
ADD CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY (UserId)
REFERENCES AspNetUsers (Id) ON DELETE CASCADE;

--
-- Create table `AspNetRoleClaims`
--
CREATE TABLE AspNetRoleClaims (
  Id int NOT NULL AUTO_INCREMENT,
  RoleId varchar(255) NOT NULL,
  ClaimType longtext DEFAULT NULL,
  ClaimValue longtext DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `IX_AspNetRoleClaims_RoleId` on table `AspNetRoleClaims`
--
ALTER TABLE AspNetRoleClaims
ADD INDEX IX_AspNetRoleClaims_RoleId (RoleId);

--
-- Create foreign key
--
ALTER TABLE AspNetRoleClaims
ADD CONSTRAINT FK_AspNetRoleClaims_AspNetRoles_RoleId FOREIGN KEY (RoleId)
REFERENCES AspNetRoles (Id) ON DELETE CASCADE;