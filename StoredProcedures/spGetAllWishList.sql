USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllWishList]    Script Date: 27-05-2021 23:26:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetAllWishList]  
(  
   @UserId int
)  
as  
begin  
  begin try
  if exists (select UserId from WishList where UserId = @UserId)
	begin
		select Book.BookId, book.BookName, book.AuthorName,book.BookDiscription, book.BookPrice,book.BookImage
		from Book inner join WishList on Book.BookId = WishList.BookId 
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
End 