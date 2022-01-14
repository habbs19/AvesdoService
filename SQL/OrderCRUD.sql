CREATE OR ALTER   PROCEDURE [dbo].[OrderCRUD](
@Operation TINYINT,
@OrderID INT = NULL,
@CustomerID INT = NULL,
@OrderDate DATETIME = NULL,
@OrderStatusID INT = NULL,
@ItemID INT = NULL,
@OrderItemID INT = NULL, 
@Quantity INT = NULL,
@AddressID INT = NULL
) AS 
BEGIN
/*
	Operation 1 = Create Order
	Operation 2 = Add Order Item
	Operation 3 = Remove Order Item
	Operation 4 = Get Orders
	Operation 5 = Get Order
	Operation 6 = Delete Order
	Operation 7 = Update Order Status
*/
	BEGIN TRY
		IF(@Operation = 1)
			INSERT INTO [Order](CustomerID,OrderDate) 
			OUTPUT inserted.OrderID,inserted.CustomerID,inserted.OrderDate,inserted.OrderStatusID
			VALUES(@CustomerID,@OrderDate)
		IF(@Operation = 2)
			INSERT INTO [OrderItem](ItemID,OrderID,Quantity) 
			OUTPUT inserted.OrderID,inserted.Quantity,inserted.ItemID
			VALUES (@ItemID,@OrderID,@Quantity)
		IF(@Operation = 3)
			DELETE FROM [OrderItem] 
			OUTPUT deleted.OrderItemID,deleted.OrderID
			WHERE OrderItemID = @OrderItemID AND OrderID = @OrderID			
		IF(@Operation = 4)
			SELECT O.OrderID,O.CustomerID,O.OrderDate,O.OrderStatusID FROM [Order] O
		IF(@Operation = 5)
			SELECT O.CustomerID,O.OrderDate,O.OrderID,O.OrderStatusID FROM [Order] O WHERE O.OrderID = @OrderID
		IF(@Operation = 6)
			BEGIN
				DELETE FROM OrderItem WHERE OrderID = @OrderID
				DELETE FROM Invoice WHERE OrderID = @OrderID
				DELETE FROM [Order] 
				OUTPUT deleted.OrderID
				WHERE [Order].OrderID = @OrderID
			END
		IF(@Operation = 7)
			UPDATE [Order] SET [Order].OrderStatusID = @OrderStatusID WHERE [Order].OrderID = @OrderID 			
	END TRY
	BEGIN CATCH
		/*Handle/Log error*/
		SELECT ERROR_MESSAGE() AS 'Error'
	END CATCH
END
GO