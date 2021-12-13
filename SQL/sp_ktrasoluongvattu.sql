USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_ktrasoluongvattu]    Script Date: 12/13/2021 03:35:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_ktrasoluongvattu]
@MAPHIEU NCHAR(8),
@MAVT NCHAR(4),
@SOLUONG INT
AS
BEGIN
	IF(@SOLUONG<=(SELECT SOLUONG FROM CTDDH WHERE MASODDH= @MAPHIEU AND MAVT= @MAVT))
		return 1;
	ELSE
		RAISERROR(N'SỐ LƯỢNG VẬT TƯ VƯỢT QUÁ SỐ LƯỢNG ĐẶT HÀNG !',16,1)
END
GO

