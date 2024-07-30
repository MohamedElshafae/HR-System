CREATE DATABASE IF NOT EXISTS hrSystem;

USE hrSystem;

CREATE TABLE IF NOT EXISTS Departments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    location VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS Jobs (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description text
);

CREATE TABLE IF NOT EXISTS Employees (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    gender VARCHAR(10),
    job_id INT,
    email_address VARCHAR(255),
    phone_number VARCHAR(20),
    address VARCHAR(255),
    department_id INT,
    manager_id iNT,
    FOREIGN KEY (department_id) REFERENCES Departments(id),
    FOREIGN KEY (job_id) REFERENCES Jobs(id),
    FOREIGN KEY (manager_id) REFERENCES Employees(id)
);



CREATE TABLE IF NOT EXISTS AttachmentTypes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE IF NOT EXISTS Attachments (
    attachment_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    upload_date DATE,
    file_path VARCHAR(255),
    employee_id INT,
    type_id INT,
    FOREIGN KEY (employee_id) REFERENCES Employees(id),
    FOREIGN KEY (type_id) REFERENCES AttachmentTypes(id)
);



