/*DROP TABLE Invoice
DROP TABLE Address
DROP TABLE OrderItem
DROP TABLE [Order]
DROP TABLE OrderStatus
DROP TABLE Item
*/

CREATE DATABASE Avesdo

USE Avesdo

CREATE TABLE Item(
ItemID INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(255),
Description NVARCHAR(1000),
UnitCost FLOAT DEFAULT 0.00
)

CREATE TABLE OrderStatus(
OrderStatusID INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(255)
)

CREATE TABLE [Order](
OrderID INT IDENTITY(1,1) PRIMARY KEY,
CustomerID INT, 
OrderStatusID INT REFERENCES OrderStatus(OrderStatusID) DEFAULT 1,
OrderDate DATETIME
)

CREATE TABLE OrderItem(
OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
OrderID INT REFERENCES [Order](OrderID),
ItemID INT REFERENCES Item(ItemID),
Quantity INT DEFAULT 1
)

CREATE TABLE Address(
AddressID INT IDENTITY(1,1) PRIMARY KEY,
Street NVARCHAR(255),
Country NVARCHAR(255) DEFAULT 'Canada',
Province NVARCHAR(255) DEFAULT 'ON',
PostalCode NVARCHAR(255)
)

CREATE TABLE Invoice(
InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
OrderID INT REFERENCES [Order](OrderID),
AddressID INT REFERENCES Address(AddressID),
SubTotal FLOAT,
Total AS (SubTotal*1.13)
)

INSERT INTO OrderStatus(Name) VALUES 
('Open'),
('Pending'),
('Awaiting Payment'),
('Shipped'),
('Delivered'),
('Completed'),
('Cancelled'),
('Refunded')

INSERT INTO Item(Name,Description,UnitCost) VALUES
('Small Pizza', 'Canadian', 11.99),
('Medium Pizza', 'Canadian', 12.99),
('Large Pizza', 'Canadian', 14.99),
('Small Pizza', 'Meat Lover', 11.99),
('Medium Pizza', 'Meat Lover', 12.99),
('Large Pizza', 'Meat Lover', 14.99),
('Small Pizza', 'Vegetarian', 11.99),
('Medium Pizza', 'Vegetarian', 12.99),
('Large Pizza', 'Vegetarian', 14.99)

INSERT INTO Address(Street,PostalCode) VALUES
('340 Orchard Mill Cres.','N4P 2T3'),
('435 Batavia Pl.','K2C 7H3'),
('19 Goldenview Rd.','N7L 9S3')