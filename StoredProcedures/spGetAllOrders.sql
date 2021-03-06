USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllWishList]    Script Date: 28-05-2021 20:01:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllOrders]  
(  
   @UserId int
)  
as  
begin  
  begin try
  if exists (select UserId from Orders where UserId = @UserId)
	begin
		select Cart.CartId
		from cart inner join Orders on Cart.CartId = Orders.OrderId 
		
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