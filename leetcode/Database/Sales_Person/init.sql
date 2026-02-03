CREATE TABLE IF NOT EXISTS SalesPerson (
    sales_id INT PRIMARY KEY,
    name VARCHAR(255),
    salary INT,
    commission_rate INT,
    hire_date DATE
);

CREATE TABLE IF NOT EXISTS Compane(
    com_id INT PRIMARY KEY,
    name VARCHAR(255),
    city VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS Orders (
    order_id INT PRIMARY KEY,
    order_date DATE, 
    com_id INT REFERENCES Company(com_id),
    sales_id INT REFERENCES SalesPerson(sales_id),
    amount INT
);