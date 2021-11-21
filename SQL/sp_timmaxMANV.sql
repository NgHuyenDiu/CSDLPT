USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_timmaxMANV]    Script Date: 11/21/2021 09:15:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_timmaxMANV]
AS
BEGIN
	SELECT MAX(MANV) FROM LINK2.QLVT_DATHANG.dbo.NhanVien
	
END

GO

