DROP TABLE IF EXISTS Customers CASCADE;
CREATE TABLE Customers(
    id INT PRIMARY KEY,
    name VARCHAR(100)
);

DROP TABLE IF EXISTS Orders CASCADE;
CREATE TABLE Orders(
    id INT PRIMARY KEY,
    customerId INT,
    FOREIGN KEY (customerId) REFERENCES Customers(id)
);

INSERT INTO Customers (
    id, name)
VALUES
(1, 'Joe'),
(2, 'Henry'),
(3, 'Sam'),
(4, 'Max');

INSERT INTO Orders (
    id, customerId)
VALUES
(1, 3),
(2, 1);