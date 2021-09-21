/*
1.	What is an object in SQL?
An object is any SQL Server resource that is used to store or reference data

2.	What is Index? What are the advantages and disadvantages of using Indexes?
Index is used to speed up the searching(selecting) queries. using index can increase the speed of looking up data, but it does not help speeding up the insertion and deletion operation of data.

3.	What are the types of Indexes?
clustered indexing and non-clustered indexing.

4.	Does SQL Server automatically create indexes when a table is created? If yes, under which constraints?
Yes, primary key (clustered index) or unique constraint (non-clustered index) is specified.

5.	Can a table have multiple clustered index? Why?
No.

6.	Can an index be created on multiple columns? Is yes, is the order of columns matter?
Yes. Yes, the order matters. It will sort starting from the leftmost column.

7.	Can indexes be created on views?
No. 

8.	What is normalization? What are the steps (normal forms) to achieve normalization?
Database Normalization is a process of organizing data to minimize redundancy (data duplication), which in turn ensures data consistency. 
First, second, Third normal form.

9.	What is denormalization and under which scenarios can it be preferable?


10.	How do you achieve Data Integrity in SQL Server?
FK constraint enforces referential integrity by guaranteeing that changes cannot be made to data in the primary key table if those changes invalidate the link to data in the foreign key table 
Domain integrity specifies that all columns in a relational database must be declared upon a defined domain. 
Entity integrity is an integrity rule which states that every table must have a primary key and that the column or columns chosen to be the primary key should be unique and not null.


11.	What are the different kinds of constraint do SQL Server have?
1. NOT NULL 
2. Unique
3. PRIMARY KEY 
4. Foriegn Key
5. Check Constraints	


12.	What is the difference between Primary Key and Unique Key?
Primary key will not accept NULL values whereas Unique key can accept one NULL value;
A table can have only primary key whereas there can be multiple unique key on a table;

13.	What is foreign key?
A foreign key is a column or group of columns in a relational database table that provides a link between data in two tables. It refers to the primary key in another table. It is used to prevent actions that would destroy links between tables.

14.	Can a table have multiple foreign keys?
Yes.

15.	Does a foreign key have to be unique? Can it be null?
Yes. Yes, only one null can be allowed.

16.	Can we create indexes on Table Variables or Temporary Tables?


17.	What is Transaction? What types of transaction levels are there in SQL Server?
Transaction is a logical unit of work. Read committed/Read uncommitted/Repeatable read/Serializable/Snapshot

Completely
Not at all


*/


/*
1.	Write an sql statement that will display the name of each customer 
and the sum of order totals placed by that customer during the year 2002
*/
Create table customer(cust_id int,  iname varchar (50));
create table "order" (order_id int,cust_id int,amount money,order_date smalldatetime)

select c.iname, sum(o.amount)
from customer c join order o on c.cust_id = o.cust_id
where o.order_date between '2002-01-01 00:00:00' and '2002-12-31 23:59:59'
group by c.iname




/*
 2.  The following table is used to store information about company’s personnel:
Create table person (id int, firstname varchar(100), lastname varchar(100)) 
write a query that returns all employees whose last names  start with “A”.
*/

select id, firstname, lastname
from person 
where lastname like 'A%'


/*
3.  The information about company’s personnel is stored in the following table:
Create table person(person_id int primary key, manager_id int null, name varchar(100)not null)
The filed managed_id contains the person_id of the employee’s manager.
Please write a query that would return the names of all top managers(an employee 
who does not have  a manger, and the number of people that report directly to this manager.
*/

select m.name, count(m.person_id)
from person e left join person m on e.manager_id = m.person_id
where m.name is not null
group by m.name


/*
4.  List all events that can cause a trigger to be executed.
*/
/*
DML statements (INSERT, UPDATE, DELETE) on a particular table or view, issued by any user

DDL statements (CREATE or ALTER primarily) issued either by a particular schema/user or 
by any schema/user in the database

Database events, such as logon/logoff, errors, or startup/shutdown, also issued either by a 
particular schema/user or by any schema/user in the database
*/


/*
5. Generate a destination schema in 3rd Normal Form.  Include all necessary fact, join, and 
dictionary tables, and all Primary and Foreign Key relationships.  The following assumptions can be made:
*/

--a. Each Company can have one or more Divisions.
create table Company(ID int primary key)
create table Divisions(ID int primary key)
create table Affiliation(CompID int foreign key references Company(ID), DivID int foreign key references Divisions(ID))


--b. Each record in the Company table represents a unique combination 
create table Company(ID int primary key)


--c. Physical locations are associated with Divisions.
create table Divisions(ID int primary key, LocID int foreign key references Locations(ID))
create table Locations(ID int primary key, LocName varchar(50))

--d. Some Company Divisions are collocated at the same physical of Company Name and Division Name.


--e. Contacts can be associated with one or more divisions and the address, but are differentiated by suite/mail drop records.status of each association should be separately maintained and audited.




