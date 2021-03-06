USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllCustomerDetails]    Script Date: 09-06-2021 12:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spGetAllCustomerDetails]  
(  
   @UserId int
)  
as  
begin  
  begin try
  if exists (select UserId from CustomerDetails where UserId = @UserId)
	begin
		--select [User].UserId, FirstName, LastName,Email,Password
		--from [User] inner join Customer on [User].UserId = Customer.CustomerId 
		--where [User].UserId = @UserId
		select * from CustomerDetails where UserId=@UserId
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