
----table for storing produt details
--alter TABLE ProductDetailsDB 
--(
--  Productid INT primary key identity(1,1),
--  ProducatName VARCHAR(255) unique,
--  VendorName VARCHAR(255) NOT NULL,
--  RetailPrice DECIMAL(18,2) NOT NULL,
--  SellingPrice DECIMAL(18,2) NOT NULL,
--  ProductCount INT NOT NULL,
--);

----for storing purchase details
--CREATE TABLE ProductCustomerDB (
--  Customerid INT primary key identity(1,1),
--  CustomerName VARCHAR(255) NOT NULL,
--  ProducatName VARCHAR(255) NOT NULL,
--  VendorName VARCHAR(255) NOT NULL,
--  PurchaseCount INT NOT NULL
--);

--insert into ProductCustomerDB values ('siva','hp',2)
--select * from ProductDetailsDB;
--select * from ProductCustomerDB;


----ubdate sales

--create or alter  procedure UbdatesalesStock (@ProducatName nvarchar(100),@VendorName nvarchar(100),@CustomerName nvarchar(100),@PurchaseCountCount int)
--as
--begin

--UPDATE ProductDetailsDB SET ProductCount = ProductCount - @PurchaseCountCount WHERE ProducatName = @ProducatName;

--insert into ProductCustomerDB values (@CustomerName,@ProducatName,@VendorName,@PurchaseCountCount)

--end

--exec UbdatesalesStock '


--insert product
create or alter procedure InsertProduct(@ProducatName nvarchar(100),@VendorName nvarchar(100),@RetailPrice DECIMAL(18,2),@SellingPrice DECIMAL(18,2),@ProductCount int)
as
begin

  insert into ProductDetailsDB (ProducatName,VendorName,RetailPrice,SellingPrice,ProductCount)values (@ProducatName,@VendorName,@RetailPrice,@SellingPrice,@ProductCount)
end

exec InsertProduct  'CPU','Dell',400,450,20
--select all records 
create or alter procedure SellectAllProducta
as
begin
    select * from ProductDetailsDB;
end

exec SellectAllProducta

--select product details with id
create or alter procedure SellectAllProductwithID(@Productid int)
as
begin
    select * from ProductDetailsDB where Productid = @Productid;
end

exec SellectAllProductwithID 1

--ubdate

create or alter  procedure UbdateProductStock (@Productid int,@ProducatName nvarchar(100),@VendorName nvarchar(100),@RetailPrice DECIMAL(18,2),@SellingPrice DECIMAL(18,2),@ProductCount int)
as
begin

  update ProductDetailsDB set ProducatName =@ProducatName,VendorName=@VendorName,RetailPrice=@RetailPrice, SellingPrice=@SellingPrice, ProductCount=@ProductCount where Productid=@Productid

end

exec UbdateProductStock 1,'Monitor','dell dell',100,150,5

--delete
create or alter procedure DeleteProduct (@Productid int)
as
begin

  delete from ProductDetailsDB where Productid=@Productid

end

exec DeleteProduct 1