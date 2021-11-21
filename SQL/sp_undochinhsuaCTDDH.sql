USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undochinhsuaCTDDH]    Script Date: 11/21/2021 09:07:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undochinhsuaCTDDH]
 @SOLUONG int, @DONGIA float,  @MasoDDH nchar(8),@MAVT nchar(4)
AS
BEGIN
	UPDATE CTDDH SET SOLUONG = @SOLUONG, DONGIA=@DONGIA WHERE MasoDDH=@MasoDDH AND MAVT=@MAVT 
END

GO

