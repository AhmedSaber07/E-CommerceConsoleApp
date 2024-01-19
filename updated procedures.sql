use EcommerceProject

---------------------------Get all orders--------------------------
create or alter proc GetOrder 
as 
select *from orders


------------------------Get Orders By Id------------------------
create or alter proc Get_Order_By_ID @orderID int
as 
select*from orders
where @orderID=id


------------------------Get Orders By UserId------------------------
create or alter proc Get_Order_By_UserID @userid int
as 
select*from orders
where @userid=UserId

---------------------------------Create User (Register)-------------
CREATE PROC user_register @userid int,@firstname varchar(10),@lastname varchar(10),@password varchar(30),@userType varchar(10),@userCity varchar(20),@userstreet varchar(20),@userBuildingNumber int,@email varchar(30)


--------------------------Get User By Email (Check Email If Exist Or Not)----------
create or alter proc userBYemail @useremail varchar(30)

as
select *
from users 
where Email=@useremail

userBYemail 'ali@gmail'



--------------------------Get User By Email and Password (Log In)---------
create or alter proc getUser @useremail varchar(30),@userpass varchar(30)
as 
select *
from users
where @useremail=Email AND @userpass=password

--------------------------------Get All Users------------------------
create proc getAllUser 
as
select*
from users


---------Get User Type OF User By Id (Check Authorize if admin or customer)--

create proc checkedUser @userid int
as 
select type
from users 
where id=@userid