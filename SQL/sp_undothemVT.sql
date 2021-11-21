USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemVT]    Script Date: 11/21/2021 09:12:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undothemVT]
@MAVT nchar(4)
AS
BEGIN
	Delete from Vattu where MAVT=@MAVT
END

GO

