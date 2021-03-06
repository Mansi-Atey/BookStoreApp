USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBook]    Script Date: 06-06-2021 18:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDeleteCartByCartId]
(
    @CartId int
)
as
begin
 begin try
 if exists(select CartId from [cart] where CartId=@CartId)
		delete from cart where CartId=@CartId
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
