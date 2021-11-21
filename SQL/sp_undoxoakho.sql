USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoakho]    Script Date: 11/21/2021 09:13:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undoxoakho]
 @MAKHO nchar(4),@TENKHO nvarchar(30), @DIACHI nvarchar(100), @MACN nchar(10)
AS
BEGIN
	insert into Kho(MAKHO, TENKHO,DIACHI,MACN) values(@MAKHO, @TENKHO,@DIACHI,  @MACN )
END

GO

