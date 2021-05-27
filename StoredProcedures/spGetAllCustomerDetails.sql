USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateCart]    Script Date: 27-05-2021 22:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetAllCustomerDetails]  
(  
   @CustomerId int
)  
as  
begin  
  begin try
  select * from [CustomerDetails]
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