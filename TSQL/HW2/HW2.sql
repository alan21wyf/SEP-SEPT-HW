-- #Q1: Result sets are the returned result from queriesincluding not only the data itself but also metadata like column names, types and sizes.

-- #Q2: Union all will not eliminate duplicate rows. It just pulls all the rows from all the tables and combines them into a table.

-- #Q3: INTERSECT EXCEPT MINUS

-- #Q4: UNION combines the results of two or more queries into a single result set that includes all the rows that belong to all queries in the union. JOIN retrieves data from two or more tables based on specified conditions.

-- #Q5: Inner join retrieves data that satisfy the specified conditions from two or more tables. Full joins combines all the rows of two or more tables and fills the missing values with null.

-- #Q6: Left join is a kind of outer join. The result set of a left outer join includes all the rows from the left table specified in the LEFT OUTER clause, not just the ones in which the joined columns match. 
--     When a row in the left table has no matching rows in the right table, the associated result set row contains null values for all select list columns coming from the right table. 

-- #Q7: The CROSS JOIN is used to generate a paired combination of each row of the first table with each row of the second table.

-- #Q8: The HAVING clause is used after the GROUP BY clause. The WHERE clause, in contrast, is used to qualify the rows that are returned before the data is aggregated or grouped. 
--      HAVING qualifies the aggregated data after the data has been grouped or aggregated.

-- #Q9: Yes.


use
AdventureWorks2019
go


-- #1
select count(p.ProductID)
from Production.Product p


-- #2
select count(p.ProductID)
from Production.Product p
where p.ProductSubcategoryID is not null


-- #3
select p.ProductSubcategoryID, count(p.ProductID) AS CountedProducts 
from Production.Product p
where p.ProductSubcategoryID is not null
group by p.ProductSubcategoryID


-- #4
select count(p.ProductID)
from Production.Product p
where p.ProductSubcategoryID is null


-- #5
select p.ProductID, sum(p.Quantity) as Quantity
from Production.ProductInventory p
group by p.ProductID


-- #6
select p.ProductID, sum(p.Quantity) as TheSum
from Production.ProductInventory p
where p.LocationID = 40
group by p.ProductID
having sum(p.Quantity) < 100


-- #7
select p.Shelf, p.ProductID , sum(p.Quantity) as TheSum
from Production.ProductInventory p
where p.LocationID = 40
group by p.shelf, p.ProductID
having sum(p.Quantity) < 100


-- #8
select p.ProductID, AVG(p.Quantity) TheAvg
from Production.ProductInventory p
where p.LocationID = 10
group by p.ProductID


-- #9
select p.ProductID, p.Shelf, AVG(p.Quantity) TheAvg
from Production.ProductInventory p
where p.LocationID = 10
group by p.Shelf, p.ProductID


-- #10
select p.ProductID, p.Shelf, AVG(p.Quantity) TheAvg
from Production.ProductInventory p
where p.Shelf not like 'N/A'
group by p.Shelf, p.ProductID


-- #11
select p.Color, p.Class, count(*) TheCount, avg(p.ListPrice) AvgPrice
from Production.Product p
where p.Color is not null and p.Class is not null
group by p.Color, p.Class


-- #12
select c.Name Country, s.Name Province
from Person.CountryRegion c join Person.StateProvince s on c.CountryRegionCode = s.CountryRegionCode


-- #13
select c.Name Country, s.Name Province
from Person.CountryRegion c join Person.StateProvince s on c.CountryRegionCode = s.CountryRegionCode
where c.Name in ('Germany', 'Canada')







use
Northwind
go


-- #14
select distinct p.ProductName
from [Order Details] od join Orders o 
	on od.OrderID = o.OrderID
join Products p 
	on od.ProductID = p.ProductID
where o.OrderDate > '1996-06-18'


-- #15
select top 5 o.ShipPostalCode, sum(od.Quantity) TheSum
from [Order Details] od join Orders o on od.OrderID = o.OrderID
group by o.ShipPostalCode
order by sum(od.Quantity) desc


-- #16
select o.ShipPostalCode, sum(od.Quantity) TheSum
from [Order Details] od join Orders o on od.OrderID = o.OrderID
where o.OrderDate > '2001-06-18'
group by o.ShipPostalCode
order by sum(od.Quantity) desc


-- #17
select c.City, count(c.CustomerID) NumofCus
from Customers c 
group by c.City


-- #18
select c.City, count(c.CustomerID) NumofCus
from Customers c 
group by c.City
having count(c.CustomerID) > 10

 
-- #19
select c.ContactName, o.OrderDate
from Orders o join Customers c on o.CustomerID = c.CustomerID
where o.OrderDate > '1998-01-01'


-- #20
select c.ContactName, max(o.OrderDate)
from Customers c join Orders o on c.CustomerID = o.CustomerID
group by c.ContactName


-- #21
select c.ContactName, sum(od.Quantity) TheSum
from Customers c join Orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName


-- #22
select c.ContactName, sum(od.Quantity) TheSum
from Customers c join Orders o on c.CustomerID = o.CustomerID join [Order Details] od on o.OrderID = od.OrderID
group by c.ContactName
having sum(od.Quantity) > 100


-- #23
select sl.CompanyName, sp.CompanyName
from Suppliers sl cross join Shippers sp

-- #24
select o.OrderDate, p.ProductName
from Orders o join [Order Details] od on o.OrderID = od.OrderID join Products p on od.ProductID = p.ProductID
order by o.OrderDate


-- #25
select e1.FirstName, e2.FirstName
from Employees e1 left outer join Employees e2 on e1.Title = e2.Title
where e1.EmployeeID != e2.EmployeeID


-- #26
select CONCAT(m.FirstName,m.LastName) FullName, count(*) TheCount
from Employees e join Employees m on e.ReportsTo = m.EmployeeID
group by CONCAT(m.FirstName,m.LastName)
having count(*) > 2


-- #27
select s.City, s.CompanyName, s.ContactName, 'Suppliers' as Type
from Suppliers s
Union
(select c.City, c.CompanyName, c.ContactName, 'Customers' as Type
from Customers c)


-- #28
select T1.F1 as Value
from T1 join T2 on T1.F1 = T2.F2
/*
result set will be:
	Value
	   2
	   3
*/


-- #29
select T1.F1, T2.F2
from T1 left join T2 on T1.F1 = T2.F2
/*
result set will be:
T1.F1	T2.F2
  1	     NULL
  2       2 
  3       3
*/
