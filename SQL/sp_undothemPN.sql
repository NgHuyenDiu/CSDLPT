USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemPN]    Script Date: 11/21/2021 09:11:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undothemPN]
@MAPN nchar(8)
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
BEGIN TRY
	delete from CTPN where MAPN= @MAPN 
	delete from PhieuNhap where MAPN= @MAPN
COMMIT TRANSACTION
END TRY
BEGIN CATCH
   ROLLBACK
	DECLARE @ErrorMessage VARCHAR(2000)
	SELECT @ErrorMessage = 'Lỗi: ' + ERROR_MESSAGE()
	RAISERROR( @ErrorMessage, 16, 1)
END CATCH

GO

