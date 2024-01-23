----------------------------------
--25- Get Product Quantity 
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetProductQuantity  @Id int
WITH ENCRYPTION
AS
	Select[Quantity] from Products where [Id]= @Id
	
EXEC sp_GetProductQuantity 2
----------------------------------
--26- Get Product Ordars 
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetProductOrdars  @Id int
WITH ENCRYPTION
AS
	Select COUNT(OrderId) from ProductOrders where [ProductId]= @Id
	
EXEC sp_GetProductOrdars 2
----------------------------------
--27- Get Users Email 
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetUserEmail  @Id int
WITH ENCRYPTION
AS
	Select[Email] from Users where [Id]= @Id
	
EXEC sp_GetUserEmail 2
----------------------------------
--28- Get Category products  
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetCategoryProducts  @Id int
WITH ENCRYPTION
AS
	Select count(Id) from Products where [CategoryId]= @Id
	
EXEC sp_GetCategoryProducts 2
----------------------------------
--29- Get Product Price 
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetProductPrice  @Id int
WITH ENCRYPTION
AS
	Select[Price] from Products where [Id]= @Id
	
EXEC sp_GetProductPrice 2
