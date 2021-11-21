USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaPX]    Script Date: 11/21/2021 09:13:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undoxoaPX]
@MAPX nchar(8),@NGAY NVARCHAR(50), @HOTENKH nvarchar(100) , @MANV int, @MAKHO nchar(4)
AS
BEGIN
	Insert into PhieuXuat (MAPX, NGAY, HOTENKH, MANV, MAKHO) values(@MAPX, @NGAY, @HOTENKH, @MANV, @MAKHO)
END

GO

