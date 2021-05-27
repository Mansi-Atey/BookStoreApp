USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spLogin]    Script Date: 27-05-2021 23:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spLogin]  
(  
    
   @Email varchar (50),  
   @Password varchar(50)
  ) 
as  
begin  
     begin try
   Select COUNT(*)from [user] where Email=@Email and Password=@Password
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