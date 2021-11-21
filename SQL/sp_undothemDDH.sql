USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undothemDDH]    Script Date: 11/21/2021 09:11:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undothemDDH]
 @MasoDDH nchar(8)
AS
BEGIN
	DELETE FROM DatHang WHERE MasoDDH= @MasoDDH
END

GO

