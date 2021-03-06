USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCart]    Script Date: 27-05-2021 23:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spUpdateCart]  
(  
   @CartID int,
   @BookID int,
   @SelectBookQuantity varchar (225),
   @UserID int,
   @TotalQuantity int
)  
as  
begin  
      begin try
 if exists (select BookId, UserID from cart where BookId=@BookID and UserID = @UserID)
 begin
 declare @count int
 select @count = @TotalQuantity + @TotalQuantity from cart where bookId = @BookID and UserID = @UserID
 if exists (select bookId from book where BookId = @BookID)
 begin
 update cart
 set @TotalQuantity = @count
 where BookId = @BookID and UserId =@UserID
 select * from book inner join cart on book.BookId = cart.BookId
 where UserID = @UserID
 END
 END
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