DROP TABLE IF EXISTS Person CASCADE
CREATE TABLE Person(
    personId INT PRIMARY KEY,
    lastName VARCHAR(100),
    firstName VARCHAR(100)
);

DROP TABLE IF EXISTS Address CASCADE
CREATE TABLE Address(
    addressId INT PRIMARY KEY,
    personId INT,
    city VARCHAR(100),
    state VARCHAR(100),
    FOREIGN KEY (personId) REFERENCES Person(personId)
);

INSERT INTO Person (
    personsId, lastName, firstName)
VALUES
(1, 'Wang', 'Allen'),
(2, 'Alice', 'Bob');

INSERT INTO Address (
    addressId, personsId, city, state)
VALUES
(1, 2, 'New York City', 'New York'),
(2, 3, 'Leetcode', 'California);