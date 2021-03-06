USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddTowishList]    Script Date: 27-05-2021 23:22:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddTowishList]  
(  
    @BookID int,
   @UserID int 
  ) 
as  
begin  
     begin try
   Insert into [WishList] values(@BookID,@UserID)  
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