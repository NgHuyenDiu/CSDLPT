USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaCTPX]    Script Date: 12/13/2021 03:47:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undoxoaCTPX]
@MAPX nchar(8), @MAVT NCHAR(4), @SOLUONG INT , @DONGIA FLOAT,@LOAI CHAR(1)
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
BEGIN TRY
	INSERT INTO CTPX (MAPX, MAVT, SOLUONG, DONGIA) VALUES(@MAPX, @MAVT, @SOLUONG , @DONGIA )	
	EXEC sp_capnhatsoluongton @MAVT, @SOlUONG, @LOAI
COMMIT TRANSACTION
END TRY
BEGIN CATCH
   ROLLBACK
	DECLARE @ERRORMESSAGE VARCHAR(2000)
	SELECT @ERRORMESSAGE = 'LỖI: ' + ERROR_MESSAGE()
	RAISERROR( @ERRORMESSAGE, 16, 1)
END CATCH

GO

