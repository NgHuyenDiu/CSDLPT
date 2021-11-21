USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undochinhsuaVT]    Script Date: 11/21/2021 09:09:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undochinhsuaVT]
@MAVT nchar(4), @TENVT nvarchar(30), @DVT nvarchar(15), @SOLUONGTON int
AS
BEGIN
	Update Vattu set TENVT=@TENVT, DVT= @DVT ,SOLUONGTON = @SOLUONGTON where MAVT=@MAVT
END

GO

