DROP TABLE IF EXISTS Scores CASCADE;
CREATE TABLE Scores (
    id INT PRIMARY KEY,
    score DECIMAL
);

INSERT INTO Scores (
    id, score) 
VALUES
(1, 3.50),
(2, 3.65),
(3, 4.00),
(4, 3.85),
(5, 4.00),
(6, 3.65);