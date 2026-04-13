SELECT Worker.name as Employee
FROM Employee as Worker
INNER JOIN Employee AS Manager
    ON Worker.managerId = manager.Id
WHERE Worker.salary > Manager.salary