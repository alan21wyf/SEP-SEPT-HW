-- #1
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p

-- #2
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p
where p.ListPrice = 0

-- #3
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p
where p.Color is null

-- #4
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p
where p.Color is not null

-- #5
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p
where p.Color is not null and p.ListPrice > 0

-- #6
select concat(p.Name, p.Color) 
from Production.Product p
where p.Color is not null

-- #7
select concat('NAME:',p.Name,' -- COLOR:', p.Color) [Name And Color]
from Production.Product p
where p.Color is not null

-- #8
select p.ProductID, p.Name
from Production.Product p
where p.ProductID between 400 and 500

-- #9
select p.ProductID, p.Name, p.Color
from Production.Product p
where p.Color in ('black', 'blue')

-- #10
select p.ProductID, p.Name, p.Color, p.ListPrice
from Production.Product p
where p.Name like 'S%'

-- #11
select top 6 p.Name , p.ListPrice
from Production.Product p
where p.Name like 'S%t%'
Order by p.Name

-- #12
select p.Name , p.ListPrice
from Production.Product p
where p.Name like '[A, S]%'
Order by p.Name

-- #13
select p.Name, p.ListPrice 
from Production.Product p
where p.Name like 'SPO[^k]%'
Order by p.Name

-- #14
select distinct p.Color
from Production.Product p
order by p.Color desc

-- #15
select distinct p.ProductSubcategoryID, p.Color
from Production.Product p
where p.ProductSubcategoryID is not null and p.Color is not null
 
-- #16
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
EXCEPT
SELECT ProductSubCategoryID
      , LEFT([Name],35) AS [Name]
      , Color, ListPrice 
FROM Production.Product
WHERE Color IN ('Red','Black') AND ListPrice not BETWEEN 1000 AND 2000 AND ProductSubCategoryID = 1



-- #17
SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
WHERE ProductSubcategoryID <= 14 
AND (Name like 'HL%' OR Name like 'MOUNTAIN%' OR Name like 'Road%') 
AND Color is not null
AND ListPrice between 500 and 2000
EXCEPT
((SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
WHERE ProductSubcategoryID = 1
AND Color is not null
AND ListPrice != 539.99)
UNION
(SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
WHERE ProductSubcategoryID = 14
AND Color = 'Black'
AND Name not like '%58%')
UNION
(SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
WHERE ProductSubcategoryID = 12
AND Color = 'Black')
UNION
(SELECT ProductSubCategoryID, LEFT([Name],35) AS [Name], Color, ListPrice
FROM Production.Product
WHERE ProductSubcategoryID = 2
AND Name not like '%350%'))
ORDER BY ProductSubcategoryID desc, Name 

