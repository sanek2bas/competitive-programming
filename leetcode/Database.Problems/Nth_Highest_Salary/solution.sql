SELECT NthHighestSalary(2);

CREATE OR REPLACE FUNCTION NthHighestSalary(N INT) RETURNS TABLE (Salary INT)
AS $$
BEGIN
    RETURN QUERY (
        SELECT DISTINCT salary
        FROM (
            SELECT salary,
            DENSE_RANK() OVER (ORDER BY salary DESC) ranking
            FROM Employee
        )
        WHERE ranking = N
    );
END;
$$ LANGUAGE plpgsql;