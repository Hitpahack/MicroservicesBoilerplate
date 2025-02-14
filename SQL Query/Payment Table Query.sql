CREATE DATABASE PaymentDB;
GO
USE PaymentDB;
GO
CREATE TABLE Payments (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-increment primary key
    OrderId INT NOT NULL,  -- Foreign Key from OrderService
    Amount DECIMAL(18,2) NOT NULL,  -- Payment Amount
    Status NVARCHAR(50) NOT NULL,  -- "Pending", "Completed", "Failed"
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE()  -- Timestamp
);
GO
