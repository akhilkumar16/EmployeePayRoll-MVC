/* for creating database */
create database Employeepayroll;
/* for table creation*/
create table Employee(
EmpId INT IDENTITY,
[Name] VARCHAR(100),
ProfileImage varchar(255),
Gender VARCHAR(100),
Department VARCHAR(100),
Salary BIGINT Default'0',
Startdate DATETIME,
Notes VARCHAR(200)
);
select *from Employee; /* command to exceute the table */
insert into Employee values('Dell','string','male','systems','300000','',' its a brand'); /* inserting values into the table */
/* for creation of stored procedures for code reuseing */
/* inserts values to the table*/
create procedure sp_Add(        
    @Name VARCHAR(100),         
    @Profile VARCHAR(100),
	@Gender VARCHAR(100) ,       
    @Department VARCHAR(100),
	@Salary BIGINT, 
	@Startdate DATETIME,
	@Notes VARCHAR(200)       
)        
as
begin
insert into Employee([Name],ProfileImage,Gender,Department,Salary,Startdate,Notes)
values (@Name,@Profile,@Gender,@Department,@Salary,@Startdate,@Notes)
end;
exec sp_Add 'hp','jpg pic','male','laptops','350000',' ',' this is also a brand ';
/* for updation of the values in tables */
alter procedure sp_UPDATE( 
	@EmpId int,      
    @Name VARCHAR(100),         
    @Profile VARCHAR(100),
	@Gender VARCHAR(100) ,       
    @Department VARCHAR(100),
	@Salary BIGINT, 
	@Startdate DATETIME,
	@Notes VARCHAR(200)       
)        
as
begin
update Employee set 					
   [Name]=@Name,
   ProfileImage=@Profile,
   Gender=@Gender,
   Department=@Department,
   Salary=@Salary,
   Startdate=@Startdate,
   Notes=@Notes
   where EmpId=@EmpId;       

end;
/* for getting all the list of details */
create procedure sp_GETALL
as
begin
select * from Employee
end;
exec sp_GETALL;
/* for deleting the values in the table */
create procedure sp_Delete(
@EmpId Int
)
as
begin
delete from Employee where EmpId=@EmpId /* where is the clouse to check the condition */
end;
exec sp_Delete '2';
create procedure sp_GETBYID(
@EmpId int
)
as
begin
select*from Employee where EmpId=@EmpId
end