USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undosuaPN]    Script Date: 11/21/2021 09:09:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undosuaPN]
@MAPN nchar(8), @NGAY NVARCHAR(50), @MasoDDH nchar(8), @MANV int , @MAKHO nchar(4)
AS
BEGIN
	Update PhieuNhap Set NGAY=@NGAY , MasoDDH=@MasoDDH , MANV=@MANV, MAKHO=@MAKHO Where MAPN=@MAPN
END

GO

