USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaPN]    Script Date: 11/21/2021 09:13:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undoxoaPN]
@MAPN nchar(8), @NGAY NVARCHAR(50), @MasoDDH nchar(8), @MANV int , @MAKHO nchar(4)
AS
BEGIN
	Insert into PhieuNhap (MAPN, NGAY, MasoDDH, MANV, MAKHO) values(@MAPN, @NGAY, @MasoDDH, @MANV, @MAKHO )
END

GO

