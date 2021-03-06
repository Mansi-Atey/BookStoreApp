USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddCustomerDetails]    Script Date: 07-06-2021 11:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddCustomerDetails]  
(  
   @UserId int,
   @Name varchar (50), 
   @Type varchar (50),   
   @Landmark varchar(50),
   @Address varchar (225),
   @City varchar(50),
   @Pincode varchar(50),
   @PhoneNumber varchar(20),
   @Locality varchar(20)

)  
as  
begin  
     begin try
   Insert into [CustomerDetails] values(@UserId,@Name,@Address,@PinCode,@PhoneNumber,@Locality,@City,@Landmark,@Type)  
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