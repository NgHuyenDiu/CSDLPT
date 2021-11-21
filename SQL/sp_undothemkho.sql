USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemkho]    Script Date: 11/21/2021 09:11:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undothemkho]
 @MAKHO nchar(4)
AS
BEGIN
	delete from  Kho WHERE MAKHO= @MAKHO
END

GO

