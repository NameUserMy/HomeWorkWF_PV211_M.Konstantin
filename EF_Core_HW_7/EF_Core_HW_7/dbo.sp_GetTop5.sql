CREATE PROCEDURE dbo.sp_GetTop5
AS
BEGIN

SELECT  top(5) Customers.[Id],Customers.[Name] FROM Customers Join Orders On Orders.CustomerId=Customers.Id
WHERE CAST(Orders.OrderDate AS date) >=GETDATE()-30 OR CAST(Orders.OrderDate AS date)<=GETDATE()
Group By  Customers.[Id] ,Customers.[Name] Order BY  Sum([TotalCount]) DESC 
END;