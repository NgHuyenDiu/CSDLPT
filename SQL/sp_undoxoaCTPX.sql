USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaCTPX]    Script Date: 11/20/2021 04:36:55 PM ******/
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
	Insert into CTPX (MAPX, MAVT, SOLUONG, DONGIA) values(@MAPX, @MAVT, @SOLUONG , @DONGIA )	
	EXEC sp_capnhatsoluongton @MAVT, @SOlUONG, @LOAI
COMMIT TRANSACTION
END TRY
BEGIN CATCH
   ROLLBACK
	DECLARE @ErrorMessage VARCHAR(2000)
	SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	RAISERROR( @ErrorMessage, 16, 1)
END CATCH

GO

