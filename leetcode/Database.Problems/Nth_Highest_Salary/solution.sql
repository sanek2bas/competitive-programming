CREATE OR REPLACE FUNCTION NthHighestSalary(N INT) 
RETURNS TABLE (salary INT)
AS $$
BEGIN
    RETURN QUERY (
        SELECT DISTINCT ranked.salary
        FROM (
            SELECT salary,
            DENSE_RANK() OVER (ORDER BY salary DESC) ranking
            FROM Employee
        ) as ranked
        WHERE ranking = N
    );
END;
$$ LANGUAGE plpgsql;

SELECT * FROM NthHighestSalary(2);