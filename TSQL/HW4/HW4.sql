--#Q1: A view is a virtual table generated from a SQL query and stored as an object. 
/*
1. Views provide an additional level of table security by restricting access to a predetermined set of rows and columns of a table.
2. A view can hide the complexity that exists in a multiple table join.
3. Views allows the user to select information from multiple tables without requiring the users to actually know how to perform a join.
4. Views can be used to store complex queries.
5. Views can also be used to rename the columns without affecting the base tables。
6. Different views can be created on the same table for different users.
*/

--2.Can data be modified through views?
--#Q2: No. You can only modify the data of the view but not the original data of the table.

--3.What is stored procedure and what are the benefits of using it?
--#Q3: A stored procedure is a prepared SQL code that you can save so the code can be reused over and over again.

--4.What is the difference between view and stored procedure?
--#Q4: A SQL View is a virtual table based on SQL SELECT query. Procedure is a group of TSQL statements compiled into a single execution plan.

--5.What is the difference between stored procedure and functions?
/*
--#Q5: The function must return a value but its not mandatory in Stored Procedure.
       Functions can have only input parameters for it whereas Procedures can have input or output parameters.
       Functions can be called from Procedure whereas Procedures cannot be called from a Function.
*/

--6.Can stored procedure return multiple result sets?
--#Q6: Yes, by using multiple select statements.

--7.Can stored procedure be executed as part of SELECT Statement? Why?
--#Q7: We cannot execute stored procedure as part of select statement because procedures can return any number of result sets (possibly zero) and change data.

--8.What is Trigger? What types of Triggers are there?
--#Q8: A trigger is a special type of stored procedure that automatically runs when an event occurs in the database server. 
--     DDL triggers, DML triggers, CLR triggers and Logon triggers.

--9.What are the scenarios to use Triggers?
--#Q9: Triggers are used to assess/evaluate data before or after data modification using DDL and DML statements.
-- These are also used to preserve data integrity, to control server operations, to audit a server and to implement business logic or business rule.

--10.What is the difference between Trigger and Stored Procedure?
--#Q10: A stored procedure is a user defined piece of code written in the local version of PL/SQL, which may return a value (making it a function) that is invoked by calling it explicitly.
-- A trigger is a stored procedure that runs automatically when various events happen (update, insert, delete).



select *
from Territories

select *
from Region

select *
from Employees

select concat(Lastname, firstname)
from Employees

select *
from Products

select *
from [Order Details]

select *
from EmployeeTerritories


--#1
insert Region values(5, 'Middle Earth')
insert Territories values('11111', 'Gondor', 5)
SET IDENTITY_INSERT Employees ON
insert into Employees(EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Region) values(10,'King','Aragorn','The king of Gondor','Mr.','1999-01-01','2000-01-01', 'Middle Earth')
insert EmployeeTerritories values(10,'11111')
SET IDENTITY_INSERT Employees OFF
GO

--#2
update Territories
set TerritoryDescription = 'Arnor'
where TerritoryID = '11111';

--#3
delete from EmployeeTerritories
where TerritoryID = '11111';

delete from Territories
where RegionID = 5;

delete from Region
where RegionID = 5;

go
--#4
create view view_product_order_Wu as
select p.ProductID, sum(od.Quantity) TotalQuant
from Products p join [Order Details] od
on p.ProductID = od.ProductID
group by p.ProductID;


--#5

drop procedure sp_product_order_quantity_Wu;

go
create procedure sp_product_order_quantity_Wu
@Productid int,
@TotalOrder int output
as
select @TotalOrder = sum(od.Quantity)
from [Order Details] od
where od.ProductID = @Productid
group by od.ProductID
go


declare @To int;
exec sp_product_order_quantity_Wu @Productid = 11, @TotalOrder = @To output;
PRINT isnull(@To, 'ProductID not exist, try another one.')
GO 


--#6


--#7


--#8


--#9


--#10


--#11


--#12


--#13


--#14
select concat([First Name], ' ', [Last Name], ' ', [Middle Name], '.')
from NameTable

--#15

create table #ScoresTable (Student varchar(20), Marks int, Sex varchar(10))

insert into #ScoresTable values('Ci', 70, 'F')
insert into #ScoresTable values('Bob', 80, 'M')
insert into #ScoresTable values('Li', 90, 'F')
insert into #ScoresTable values('Mi', 95, 'M')
insert into #ScoresTable values('Qi', 90, 'F')



select top 1 Student, Sex, Marks
from #ScoresTable
where Sex = 'F'
order by Marks desc


--#16
select Student, Marks, Sex
from
(select Student, Marks, Sex, DENSE_RANK() over (partition by Sex order by Marks desc) rnk
from #ScoresTable) dt



/*
1.	Design a Database for a company to Manage all its projects.
*/
create table Projects (ProjectCode int primary key, Title varchar(100), StartDate Date, EndDate Date, Budget decimal(18, 2), ManagerName varchar(255));

create table Countries (CountryID int primary key, CountryName varchar(50) not null);

create table Cities (CityID int primary key, CityName varchar(50) not null, CountryID int foreign key references Countries(CountryID) on delete set null, Population int);

create table Offices (
OfficeID int primary key, 
OfficeName varchar(50), 
CityID int foreign key references Cities(CityID) on delete set null, 
CountryID int foreign key references Countries(CountryID) on delete set null, 
"Address" varchar(100), 
PhoneNum varchar(20), 
NameofDirector varchar(50),
ReportTo int foreign key references Offices(OfficeID) on delete set null);
--report to is used to identify if a office is a regular office or the head office

create table Manage(
OfficeID int foreign key references Offices(OfficeID) on delete cascade,
ProjectID int foreign key references Projects(ProjectCode) on delete cascade,
primary key (OfficeID, ProjectID))



/*
2.	Design a database for a lending company which manages lending among people (p2p lending)
*/

create table Lenders(ID int primary key, LenderName varchar(50), AvailableMoney decimal(20, 2))

create table Borrowers(ID int primary key, CompanyName varchar(50), RiskValue decimal(20,2))

create table Loans(ID int primary key, Amount decimal(20, 2), RefundDeadline Date, InterestRate decimal(5,2), Purpose varchar(500))

create table LoanDetails(ID int foreign key references Loans(ID) on delete cascade, LenderID int foreign key references Lenders(ID) on delete set null, Amount decimal(20, 2), primary key (ID, LenderID))

create table BorrowerDetail (BorrowerID int foreign key references Borrowers(ID) on delete cascade, LoanID int foreign key references Loans(ID) on delete cascade, primary key(BorrowerID, LoanID))







/*
3.	Design a database to maintain the menu of a restaurant.
*/

create table Course(
ID int primary key, 
RecipeId int, 
CourseName varchar(20), 
CourseDesc varchar(100), 
Photo image, 
Price decimal(8,2))

create table Category(ID int primary key, CategoryName varchar(20), CateDesc varchar(100), CourseID int foreign key references Course(ID) on delete cascade, MgerName varchar(20))

create table Recipe(ID int primary key, IngredientName varchar(20), NeededAmount int, Measurement varchar(10), CurrentAmount int) 

create table Ingredients(ID int primary key, IngredName varchar(20))

create table RecipeDetails(ID int, RecipeID int foreign key references Recipe(ID) on delete set null, IngredID int foreign key references Ingredients(ID) on delete cascade, "Amount(g)" decimal(5,2), primary key(ID, RecipeID))

create table Inventory(IngredID int foreign key references Ingredients(ID), "Amount(g)" decimal(15,2), primary key(IngredID, "Amount(g)"))



-- Extra question
-- remove duplicate using dense_rank
drop table #Employee
create table #Employee (eID int IDENTITY, Empname varchar(20), Salary int, departmentname varchar(20))
insert into #Employee values('Smith', 4500, 'IT')
insert into #Employee values('Smith', 4500, 'IT')
insert into #Employee values('Ryan', 5500, 'IT')
insert into #Employee values('Ryan', 5500, 'IT')

alter table #Employee
alter column departmentname varchar(20) not null

alter table #Employee
add constraint dname_unique Unique(departmentname)

SELECT * FROM #Employee

select * from
(select Empname, Salary, DENSE_RANK() over (partition by Empname, Salary order by eID desc) rnk
from #Employee) dt
where rnk = 1