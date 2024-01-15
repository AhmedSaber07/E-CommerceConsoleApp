-------------------------------------------------------------------------------
------------------------------Name : Mohammed khaled---------------------------

Create or alter proc DeleteProduct @ProductID int
as 
	delete from Products where Id=@ProductID

-----Test-----
DeleteProduct 3
--------------------------------------------------------------

Create or alter proc GetAllProducts 
as 
	select * from Products

-----Test-----
GetAllProducts
-----------------------------------------------------------------------

Create or alter proc GetProductById @ProductID int 
as 
	select * from Products where Id=@ProductID

-----Test-----
GetProductById 1
------------------------------------------------------------------------

Create or alter proc GetProductByName @ProductName varChar(50)
as 
	select * from Products where ProductName=@ProductName

-----Test-----
GetProductByName 'Product1'
----------------------------------------------------------------------------

create or alter proc GetProductsByCategoryName @CategoryName varchar(50)
as 
	select p.* from Products p , Categories c where c.Id=p.CategoryId and c.CategoryName=@CategoryName

-----Test-----
GetProductsByCategoryName 'mobile'
-----------------------------------------------------------------------------

create or alter proc CreateOrder @Quantity int , @TotalPrice money,@OrderId int
as 
	if not exists (select Id from Users where Id=@OrderId)
		select 'There is no user found with this id'
	else 
	insert into Orders(Quantity,TotalPrice,OrderDate,UserId) Values (@Quantity, @TotalPrice,GetDate(),@OrderId)

-----Test-----
CreateOrder 2,15.2,2
--------------------------------------------------------------------------------

Create or Alter proc UpdateOrder 
@OrderId int , @Quantity int ,@TotalPrice money ,@OrderDate Date,@UserId int
as 
begin
	update Orders
	set Quantity=@Quantity,
		TotalPrice=@TotalPrice,
		OrderDate=@OrderDate,
		UserId=@UserId
	where Id=@OrderId
end

-----Test
UpdateOrder 2,4,200,'2023-12-12',1
----------------------------------------------------------------------------------

Create or alter proc DeleteOrder @OrderId int
as 
	delete from Orders where id=@OrderId

-----Test
DeleteOrder 2
