-- #Q1: Join will be preferred because it execuetes faster.

/*
#Q2: CTE is short for Common Table Expression. 
     It is a substitute for a view when the general use of a view is not required(no need to store the definition in metadata).
     It improves readability and ease in maintenance of complex queries; 
     It can be used to created a recursive query.
*/

/*
#Q3: A table variable is a local variable that has some similarities to temp tables. 
     A table variable is scoped to the stored procedure, batch, or user-defined function just 
     like any local variable. The variable will no longer exist after the procedure exits. 
     Table variables are created and stored in the tempdb database.
*/


/*
#Q4: Truncate doesn't fire triggers; There may be WHERE clause in DELETE command to filter the records 
     whereas there may not be WHERE clause in TRUNCATE command; Truncate is DDL whereas delete is DML; 
     Truncate resets identity values, whereas delete doesn't; 
     Truncate is faster compared to delete as it makes less use of the transaction log; 
*/


/*
#Q5: An identity column is a column in a database table that is made up of values generated 
     by the database instead of users. Truncate resets identity values, whereas delete doesn't.
*/


/*
#Q6: The DELETE statement removes rows one at a time and records an entry in the transaction log for each deleted row.	
     TRUNCATE TABLE removes the data by deallocating the data pages used to store the table data 
     and records only the page deallocations in the transaction log.
*/




--#1
select City from Customers
intersect
select city from Employees


--#2
-- Subquery
select distinct c.city
from Customers c
where c.city not in (
select e.city
from Employees e
)
-- no subquery
select city from Customers
except
select city from Employees


--#3
select productID, sum(quantity)
from [Order Details]
group by productID


--#4
select o.ShipCity, sum(od.Quantity)
from Orders o left join [Order Details] od
on o.OrderID = od.OrderID
group by o.ShipCity


--#5



--Subquery no Union
select a.City
from (
select City, count(CustomerID) [Count]
from Customers
group by City
having count(CustomerID) >= 2) a


--#6
select c.City, count(od.ProductID)
from Customers c join Orders o
on c.City = o.ShipCity
join [Order Details] od
on o.OrderID = od.OrderID
group by c.City
having count(od.ProductID) >= 2


--#7
select distinct c.ContactName, c.City, o.ShipCity
from Customers c join Orders o
on c.CustomerID = o.CustomerID
where c.City != o.ShipCity


--#8
select top 5 ProductID, od.UnitPrice, c.City, sum(Quantity) Quantity
from [Order Details] od join Orders o
on od.OrderID = o.OrderID
join Customers c
on c.CustomerID = o.CustomerID
group by ProductID, od.UnitPrice, c.City
order by sum(Quantity) desc


--#9
--subquery
select City 
from Employees 
where City not in 
(select o.ShipCity
from Orders o)


--#9b
select e.City
from Orders o right join Employees e on e.City = o.ShipCity
where o.ShipCity is null


--#10
select City
from
(select e.City, o.EmployeeID, count(o.OrderID) Num_Order, rank() over(order by count(o.OrderID) desc) ranking
from Employees e join Orders o on e.EmployeeID = o.EmployeeID
group by e.City, o.EmployeeID) dt1
join
(select o.ShipCity, sum(od.Quantity) TotalQuant, rank() over(order by sum(od.Quantity) desc) ranking
from [Order Details] od join Orders o on o.OrderID = od.OrderID
group by o.ShipCity) dt2
on dt1.City = dt2.ShipCity
where dt1.ranking = 1 and dt2.ranking = 1 and dt1.City = dt2.ShipCity


--#11 
-- use Shippers as an example
with CTE as
(select ShipperID, CompanyName, Phone, ROW_NUMBER() over (partition by CompanyName, Phone order by CompanyName) rownum
from Shippers )
delete from CTE
where rownum > 1;


--#12 
select m.empid
from Employee e right join Employee m on e.mgrid = m.empid
where e.empid is null


--#13 
with CTE as
(select e.deptid, count(e.EmployeeID) EmpCount, rank() over(order by count(e.EmployeeID) desc) ranking
from Employee e
group by e.deptid)
select deptid, EmpCount 
from CTE
where ranking = 1


--#14
with CTE as
(select d.deptname, e.empid, e.salary, DENSE_RANK() over(partition by e.deptid order by e.salary desc) ranking
from Employee e join Dept d on e.deptid = d.deptid)
select deptname, empid, salary from CTE
where ranking <= 3
