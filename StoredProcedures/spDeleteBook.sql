USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBook]    Script Date: 27-05-2021 23:23:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spDeleteBook]
(
    @BookID int
)
as
begin
 begin try
 if exists (select * from book where bookId=@BookID)
 delete from book where bookId=@BookID
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
