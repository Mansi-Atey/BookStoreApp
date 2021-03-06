USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddBooks]    Script Date: 10-06-2021 14:40:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddImage]  
(  
  @BookID int,
   @BookImage varchar(50)
   
)  
as  
begin  
     begin try
	if exists (select * from book where BookID=@BookID)
	update book
	set BookImage=@BookImage
	where BookID=@BookID	
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