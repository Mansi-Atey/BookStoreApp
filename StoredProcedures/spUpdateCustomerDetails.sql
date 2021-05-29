USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBook]    Script Date: 28-05-2021 19:55:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateCustomerDetails]  
(  
   @CustomerId int,
   @Name varchar (50), 
   @Address varchar (50),  
   @Pincode int,  
   @PhoneNumber varchar(50),
   @Locality varchar (225),
   @City varchar(50),
   @Landmark varchar(50),
   @AddressType varchar(50)
   
)  
as  
begin  
     begin try
if exists(select CustomerId from [CustomerDetails] where CustomerId=@CustomerId)
		Update [CustomerDetails] 
		set Name=@Name ,
			PhoneNumber=@PhoneNumber,
			Address=@Address,
			Locality=@Locality,
			Landmark=@Landmark,
			Pincode=@Pincode,
			City=@City,
			AddressType=@AddressType 
		where CustomerId=@CustomerId
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