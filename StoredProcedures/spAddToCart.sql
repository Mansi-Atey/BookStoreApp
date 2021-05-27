USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddToCart]    Script Date: 27-05-2021 23:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddToCart]  
(  
    @BookID int,
   @SelectBookQuantity int 
  ) 
as  
begin  
     begin try
   Insert into [cart] values(@BookID,@SelectBookQuantity)  
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