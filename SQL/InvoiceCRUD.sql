CREATE OR ALTER PROCEDURE InvoiceCRUD(
@Operation TINYINT,
@OrderID INT = NULL,
@AddressID INT = NULL,
@InvoiceID INT = NULL,
@Error NVARCHAR(1000) = NULL OUTPUT
) AS 
BEGIN
/*
	Operation 1 = Create Invoice
	Operation 2 = Read Invoice
*/
	BEGIN TRY
		IF(@Operation = 1)
			BEGIN
				DECLARE @Subtotal FLOAT
				SELECT @Subtotal = SUM(I.UnitCost*O.Quantity) FROM OrderItem O
				INNER JOIN Item I ON I.ItemID = O.ItemID
				WHERE O.OrderID = @OrderID

				INSERT INTO Invoice(OrderID,SubTotal,AddressID)
				OUTPUT inserted.InvoiceID,inserted.AddressID,inserted.OrderID,inserted.SubTotal,inserted.Total
				VALUES(@OrderID,IIF(@Subtotal IS NULL,0,@Subtotal),@AddressID)
			END
			
		IF(@Operation = 2)
			SELECT I.AddressID,I.InvoiceID,I.OrderID,I.SubTotal,I.Total FROM Invoice I 
			WHERE OrderID = @OrderID OR InvoiceID = @InvoiceID
	END TRY
	BEGIN CATCH
		SET @Error = ERROR_MESSAGE()
	END CATCH
END