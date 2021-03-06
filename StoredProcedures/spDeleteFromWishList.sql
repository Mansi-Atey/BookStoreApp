USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteFromWishList]    Script Date: 27-05-2021 23:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spDeleteFromWishList]
(
    @WishListId int
)
as
begin
 begin try
 if exists (select * from WishList where wishlistId=@WishListId)
 delete from WishList where wishListId=@WishListId
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