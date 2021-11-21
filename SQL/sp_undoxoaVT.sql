USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaVT]    Script Date: 11/21/2021 09:14:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undoxoaVT]
@MAVT nchar(4), @TENVT nvarchar(30), @DVT nvarchar(15), @SOLUONGTON int
AS
BEGIN
	Insert into Vattu (MAVT, TENVT, DVT,SOLUONGTON) values( @MAVT, @TENVT, @DVT, @SOLUONGTON )
END

GO

