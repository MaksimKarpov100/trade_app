DROP DATABASE IF EXISTS trade;
CREATE DATABASE trade CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE trade;

CREATE TABLE Role (
RoleID INT PRIMARY KEY, 
RoleName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE OrderStatus (
StatusID INT PRIMARY KEY, 
StatusName VARCHAR(100) NOT NULL UNIQUE)
;
CREATE TABLE Unit (
UnitID INT PRIMARY KEY, 
UnitName VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Category (
CategoryID INT PRIMARY KEY, 
CategoryName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Manufacturer (
ManufacturerID INT PRIMARY KEY, 
ManufacturerName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Supplier (
SupplierID INT PRIMARY KEY, 
SupplierName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE ProductStatus (
ProductStatusID INT PRIMARY KEY, 
ProductStatusName VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE User (
  UserID INT PRIMARY KEY AUTO_INCREMENT,
  UserSurname VARCHAR(100) NOT NULL,
  UserName VARCHAR(100) NOT NULL,
  UserPatronymic VARCHAR(100) NULL,
  UserLogin VARCHAR(100) NOT NULL UNIQUE,
  UserPassword VARCHAR(100) NOT NULL,
  UserRole INT NOT NULL,
  FOREIGN KEY (UserRole) REFERENCES Role(RoleID)
);

CREATE TABLE PickupPoint (
  PickupPointID INT PRIMARY KEY AUTO_INCREMENT,
  Address VARCHAR(255) NOT NULL
);

CREATE TABLE Product (
  ProductArticleNumber VARCHAR(100) PRIMARY KEY,
  ProductName TEXT NOT NULL,
  ProductDescription TEXT NOT NULL,
  CategoryID INT NOT NULL,
  ProductPhoto VARCHAR(255) NULL,
  ManufacturerID INT NOT NULL,
  SupplierID INT NOT NULL,
  UnitID INT NOT NULL,
  ProductCost DECIMAL(19,4) NOT NULL,
  ProductMaxDiscount TINYINT NULL,
  ProductCurrentDiscount TINYINT NULL,
  ProductQuantityInStock INT NOT NULL,
  ProductStatusID INT NOT NULL,
  FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
  FOREIGN KEY (ManufacturerID) REFERENCES Manufacturer(ManufacturerID),
  FOREIGN KEY (SupplierID) REFERENCES Supplier(SupplierID),
  FOREIGN KEY (UnitID) REFERENCES Unit(UnitID),
  FOREIGN KEY (ProductStatusID) REFERENCES ProductStatus(ProductStatusID)
);

CREATE TABLE `Order` (
  OrderID INT PRIMARY KEY,
  OrderStatusID INT NOT NULL,
  OrderDate DATETIME NOT NULL,
  OrderDeliveryDate DATETIME NOT NULL,
  OrderPickupPointID INT NOT NULL,
  OrderClientName VARCHAR(255) NULL,
  OrderCode INT NOT NULL,
  FOREIGN KEY (OrderStatusID) REFERENCES OrderStatus(StatusID),
  FOREIGN KEY (OrderPickupPointID) REFERENCES PickupPoint(PickupPointID)
);

CREATE TABLE OrderProduct (
  OrderID INT NOT NULL,
  ProductArticleNumber VARCHAR(100) NOT NULL,
  Quantity INT NOT NULL,
  PRIMARY KEY (OrderID, ProductArticleNumber),
  FOREIGN KEY (OrderID) REFERENCES `Order`(OrderID),
  FOREIGN KEY (ProductArticleNumber) REFERENCES Product(ProductArticleNumber)
);