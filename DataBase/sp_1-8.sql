----------------------------------
--1- Create Category
----------------------------------
CREATE OR ALTER PROCEDURE sp_CreateCategory @Name NVARCHAR(50)
WITH ENCRYPTION
AS
	INSERT INTO Categories
	VALUES(@Name)

EXEC sp_CreateCategory 'Iphone'

----------------------------------
--2- Update Category
----------------------------------
CREATE OR ALTER PROCEDURE sp_UpdateCategory
@Id int, @Name NVARCHAR(50)
AS
	UPDATE Categories
	SET [CategoryName]= @Name
    WHERE Id = @Id

EXEC sp_UpdateCategory 10, 'Mac'

----------------------------------
--3- Delete Category
----------------------------------
CREATE OR ALTER PROCEDURE sp_DeleteCategory @Id int
WITH ENCRYPTION
AS
	 Delete from Categories
	where [Id]= @Id 

EXEC sp_DeleteCategory 'Mac'

----------------------------------
--4- Get All Category
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetAllCategory 
WITH ENCRYPTION
AS
	 Select* from Categories

EXEC sp_GetAllCategory 

----------------------------------
--5- Get Category By Id
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetCategoryById @Id INT
WITH ENCRYPTION
AS
	 Select* from Categories where [Id]= @Id

EXEC sp_GetCategoryById 2

----------------------------------
--6- Get Category By Name
----------------------------------
CREATE OR ALTER PROCEDURE sp_GetCategoryByName @Name NVARCHAR(50)
WITH ENCRYPTION
AS
	 Select* from Categories where [CategoryName]= @Name

EXEC sp_GetCategoryByName 'Mobile'

----------------------------------
--7- Create Product
----------------------------------
CREATE OR ALTER PROCEDURE sp_CreateProduct @Name NVARCHAR(50) ,@Quantity int,@Price float,@Description NVARCHAR(50),@CategoryId INT
WITH ENCRYPTION
AS
	INSERT INTO Products
	VALUES(@Name,@Quantity,@Price,@Description,@CategoryId )

EXEC sp_CreateProduct 'infinex',20,4000,'ssssssssssssssssssss',2

----------------------------------
--8- Update Product
----------------------------------
CREATE OR ALTER PROCEDURE sp_UpdateProduct @Id int, @Name NVARCHAR(50) ,@Quantity int,@Price Money,@Description NVARCHAR(50),@CategoryId INT
WITH ENCRYPTION
AS
	Update Products
	set [Quantity]=@Quantity
	, [Price]=@Price
	,[Description]=@Description,
	[CategoryId]=@CategoryId 
	where [Id]=@Id 

EXEC sp_UpdateProduct 'infinex',30,5000,'aaaaaaaaaaaaaaaaaaaaaa',2
