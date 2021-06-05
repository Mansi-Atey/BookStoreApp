USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCart]    Script Date: 04-06-2021 10:24:02 ******/
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
if exists (select UserId from cart )
begin
select cart.cartId,book.BookID, book.BookName, book.AuthorName, book.BookPrice, book.BookImage from book inner join  cart on book.BookID=cart.BookID
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