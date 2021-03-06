USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCustomerDetails]    Script Date: 27-05-2021 23:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spDeleteCustomerDetails]
(
    @CustomerId int
)
as
begin
 begin try
 if exists (select * from CustomerDetails where customerId=@CustomerId)
 delete from CustomerDetails where customerId=@CustomerId
 end try
 begin catch
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
 end catch
 end
