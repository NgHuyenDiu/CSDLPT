USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoSuaDDH]    Script Date: 11/21/2021 09:09:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undoSuaDDH]
 @MasoDDH nchar(8), @NGAY nvarchar(50), @NhaCC nvarchar(100), @MANV int, @MAKHO nchar(4)
AS
BEGIN
	update DatHang set NGAY= @NGAY, NhaCC= @NhaCC, MANV= @MANV, MAKHO = @MAKHO where MasoDDH= @MasoDDH
END

GO

