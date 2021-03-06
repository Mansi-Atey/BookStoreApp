USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[spAddBooks]    Script Date: 27-05-2021 23:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spAddBooks]  
(  
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
   Insert into [book] values(@BookName,@BookDiscription,@BookPrice,@AuthorName,@Quantity,@BookImage)  
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