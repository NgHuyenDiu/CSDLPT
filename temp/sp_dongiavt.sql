USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_dongiavt]    Script Date: 11/18/2021 01:49:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_dongiavt]
@MASODDH NCHAR(8)
AS
BEGIN
SELECT VT.MAVT, CT.DONGIA
FROM VATTU VT, (SELECT MAVT, CTDDH.DONGIA FROM CTDDH,DATHANG  WHERE CTDDH.MASODDH= DATHANG.MASODDH AND DATHANG.MASODDH= @MASODDH) CT
WHERE VT.MAVT= CT.MAVT
END
GO

