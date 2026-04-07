SELECT (
    SELECT DISTINCT salary
    FROM Employee
    ORDER BY salary DESC
    LIMIT 1 OFFSET 1
) as SecondHighestSalary;

/*
SELECT (
    SELECT DISTINCT salary
    FROM (
        SELECT salary,
        DENSE_RANK() OVER (ORDER BY salary DESC) ranking
        FROM Employee
    )
    WHERE ranking = 2
) as SecondHighestSalary
*/