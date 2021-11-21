USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undochinhsuaPX]    Script Date: 11/21/2021 09:08:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[sp_undochinhsuaPX]
@MAPX nchar(8),@NGAY NVARCHAR(50), @HOTENKH nvarchar(100) , @MANV int, @MAKHO nchar(4)
AS
BEGIN
	Update PhieuXuat Set NGAY= @NGAY, HOTENKH=@HOTENKH, MANV=@MANV , MAKHO=@MAKHO Where MAPX=@MAPX
END

GO

