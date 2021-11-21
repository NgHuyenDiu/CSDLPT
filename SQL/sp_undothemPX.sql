USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemPX]    Script Date: 11/21/2021 09:12:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undothemPX]
@MAPX nchar(8)
AS
BEGIN
	delete from PhieuXuat where MAPX=@MAPX
END

GO

