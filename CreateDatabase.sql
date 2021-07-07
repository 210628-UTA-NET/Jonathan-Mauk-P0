CREATE TABLE Customer (
    CustomerId int IDENTITY,
    CustomerName VARCHAR(30) NOT NULL,
    CustomerAddress VARCHAR(50) NOT NULL,
    Email VARCHAR(30) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,

    PRIMARY KEY (CustomerId)
);

CREATE TABLE StoreFront (
    StoreId int IDENTITY,
    StoreName VARCHAR(30) NOT NULL,
    StoreAddress VARCHAR(50) NOT NULL,

    PRIMARY KEY (StoreId)
);

CREATE TABLE Product (
    ProductId INT IDENTITY,
    ProductName VARCHAR(20) NOT NULL,
    ProductPrice DECIMAL(10,2) NOT NULL,
    Description VARCHAR(255),
    Category VARCHAR(20)

    PRIMARY KEY (ProductId)
);

CREATE TABLE Orders (
    OrderId INT IDENTITY,
    TotalPrice DECIMAL(10,2),
    StoreId INT NOT NULL,
    CustomerId INT NOT NULL,

    FOREIGN KEY (StoreId) REFERENCES StoreFront,
    FOREIGN KEY (CustomerId) REFERENCES Customer,
    PRIMARY KEY (OrderId)
);

CREATE TABLE StoreLineItem (
    StoreLineItemId INT IDENTITY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    StoreId INT NOT NULL,

    FOREIGN KEY (ProductId) REFERENCES Product,
    FOREIGN KEY (StoreId) REFERENCES StoreFront,
    PRIMARY KEY (StoreLineItemId)
);

CREATE TABLE OrderLineItem (
    OrderLineItemId INT IDENTITY,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    OrderId INT NOT NULL,

    FOREIGN KEY (ProductId) REFERENCES Product,
    FOREIGN KEY (OrderId) REFERENCES Orders,
    PRIMARY KEY (OrderLineItemId)
);
