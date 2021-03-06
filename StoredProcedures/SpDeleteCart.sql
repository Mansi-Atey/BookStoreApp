USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCartByCartId]    Script Date: 27-05-2021 23:20:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[DeleteCartByCartId]
(
    @CartId int
)
as
begin
 begin try
 if exists (select * from cart where cartId=@CartId)
 delete from cart where cartId=@CartId
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