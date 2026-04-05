DROP TABLE IF EXISTS Weather;
CREATE TABLE Weather(
    id INT PRIMARY KEY,
    recordDate DATE,
    temperature INT
);

INSERT INTO Weather(
    id, recordDate, temperature)
VALUES
(1, '2010-12-14', 3),
(2, '2010-12-16', 5),
(3, '2015-01-01', 10),
(4, '2015-01-02', 25),
(5, '2015-01-03', 20),
(6, '2015-01-04', 30);