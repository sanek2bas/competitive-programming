DROP TABLE IF EXISTS Person;
CREATE TABLE Person(
    id INT PRIMARY KEY,
    email VARCHAR(100)
);

INSERT INTO Person(
    id, email)
VALUES
    (1, 'john@example.com'),
    (2, 'bob@example.com'),
    (3, 'john@example.com');