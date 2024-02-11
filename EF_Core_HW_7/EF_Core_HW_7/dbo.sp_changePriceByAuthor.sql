CREATE PROCEDURE dbo.sp_changePriceByAuthor
@id INT,
@price DECIMAL(18,2)
AS
BEGIN
UPDATE Books SET Books.Price=@price FROM Books JOIN  AythorsBooks ON Books.Id=AythorsBooks.BooksId
WHERE AythorsBooks.AuthorsId=@id
END;