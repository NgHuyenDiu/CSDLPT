USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undosuakho]    Script Date: 11/21/2021 09:09:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undosuakho]
 @MAKHO nchar(4),@TENKHO nvarchar(30), @DIACHI nvarchar(100), @MACN nchar(10)
AS
BEGIN
	UPDATE Kho SET TENKHO= @TENKHO,DIACHI= @DIACHI, MACN= @MACN WHERE MAKHO= @MAKHO
END

GO

