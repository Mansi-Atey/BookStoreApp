USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCart]    Script Date: 09-06-2021 15:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetAllCart]
(
@UserId int
)  
as
begin
  begin try
		if exists (select UserId from cart where UserId=@UserId)
		begin
		select Book.BookID as BookID, book.BookName as BookName,book.AuthorName as AuthorName,Book.BookPrice as BookPrice,book.BookImage as BookImage,
		cart.TotalQuantity as TotalQuantity,
		cart.CartId as CartId from book inner join  cart on book.BookID=cart.BookID
		where UserId=@UserId	
		end
end try
 begin catch
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
 end catch
 end