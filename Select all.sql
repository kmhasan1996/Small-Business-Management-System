
  select * from Categories
  select * from Products
  select * from Customers
  select * from Suppliers

  select * from Purchases
  select * from PurchaseDetails

   select * from Sales
  select * from SaleDetails

  insert into Sales values(1,21-11-19,'0001')
  insert into SaleDetails values(1,1,5,1000,6250)

  insert into Purchases values(1,21-11-19,'0001','0001')
  insert into PurchaseDetails values(1,1,21-11-19,21-11-19,5,1000,1250,6250,'Hi')
    insert into PurchaseDetails values(5,32,21-11-19,21-11-19,5,1000,1250,6250,'Hi')

	delete from Purchases
	delete from PurchaseDetails