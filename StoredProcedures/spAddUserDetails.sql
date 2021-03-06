USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddUserDetails]    Script Date: 29-05-2021 23:30:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddUserDetails]  
(  
   @FirstName varchar (50), 
   @LastName varchar (50),  
   @Email varchar (225),  
   @Password varchar(50)
)  
as  
begin  
     begin try
   Insert into [user] values(@FirstName,@LastName,@Email,@Password)  
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