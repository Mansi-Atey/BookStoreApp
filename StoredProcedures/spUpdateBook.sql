USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBook]    Script Date: 27-05-2021 23:27:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spUpdateBook]  
(  
   @BookID int,
   @BookName varchar (50), 
   @BookDiscription varchar (50),  
   @BookPrice money,  
   @AuthorName varchar(50),
   @Quantity varchar (225),
   @BookImage varchar(50)
   
)  
as  
begin  
     begin try
 Update book   
   set BookName=@BookName,  
       BookDiscription=@BookDiscription,
       BookPrice=@BookPrice,
	   AuthorName=@AuthorName,
	   Quantity=@Quantity,
	   BookImage=@BookImage
   where bookId=@BookID 
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