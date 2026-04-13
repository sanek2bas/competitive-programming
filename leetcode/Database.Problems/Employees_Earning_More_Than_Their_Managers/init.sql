DROP TABLE IF EXISTS Employee;
CREATE TABLE Employee(
    id INT PRIMARY KEY,
    name VARCHAR(100),
    salary INT,
    managerId INT
);

INSERT INTO Employee(
    id, name, salary, managerId)
VALUES
    (1, 'Joe', 70000, 3),
    (2, 'Henry', 80000, 4),
    (3, 'Sam', 60000, Null),
    (4, 'Max', 90000, Null);