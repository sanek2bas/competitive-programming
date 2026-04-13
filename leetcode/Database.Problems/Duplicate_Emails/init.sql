DROP TABLE IF EXISTS Person;
CREATE TABLE Person(
    id INT PRIMARY KEY,
    email VARCHAR(100)
);

INSERT INTO Person(
    id, email)
VALUES
    (1, 'a@b.com'),
    (2, 'c@d.com'),
    (3, 'a@b.com');