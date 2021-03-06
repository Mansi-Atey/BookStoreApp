USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddToCart]    Script Date: 03-06-2021 15:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddToCart]  
(  
    @UserId int,
    @BookID int,
   @TotalQuantity int 
  ) 
as  
begin  
     begin try
   Insert into [cart] values(@UserId,@BookID,@TotalQuantity)  
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