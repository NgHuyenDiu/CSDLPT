USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemNV]    Script Date: 11/21/2021 09:11:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undothemNV]
@MANV int
AS
BEGIN
	delete from NhanVien where MANV = @MANV
END

GO

