
CREATE TABLE #Employee (
	first_name varchar,
	last_name varchar, 
	dep_name varchar,
	salary int,
	primary key(first_name, last_name))
INSERT INTO Employee VALUES('Jane', 'Marshall', 'IT', 35000)
INSERT INTO Employee VALUES('Adam', 'Marks', 'Sales', 27500)
INSERT INTO Employee VALUES('Alice', 'Mathers', 'IT', 32500)
INSERT INTO Employee VALUES('George', 'Flanders', 'HR', 27000)
INSERT INTO Employee VALUES('Thomas', 'Bjorn', 'Sales', 42500)
INSERT INTO Employee VALUES('Marcus', 'Channing', 'IT', 37500)

SELECT dep_name, SUM(salary) AS total_salary, COUNT(first_name) AS no_employee
FROM #Employee
GROUP BY dep_name

CREATE TABLE #Employee (
	id int
	first_name varchar,
	last_name varchar, 
	dep_name varchar,
	salary int,
	primary key(id)
	)

SELECT dep_name, SUM(salary) AS total_salary, COUNT(id) AS no_employee
FROM #Employee
GROUP BY dep_name


1. The candidate key, employee's name in the original table cannot uniquely identify each employee record, because name could be replicate.
Introducing a unique id as primary key for the table would eleminate the problem of inserting a record with the same name.
2. This can eleminate the anomaly on select, update and delete query when filtering a record using where clause.