USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_undoxoaCTDDH]    Script Date: 11/21/2021 09:12:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_undoxoaCTDDH]
 @MasoDDH nchar(8),@MAVT nchar(4), @SOLUONG int, @DONGIA float
AS
BEGIN
	insert into  CTDDH(MasoDDH, MAVT, SOLUONG, DONGIA) values( @MasoDDH, @MAVT, @SOLUONG, @DONGIA  ) 
END

GO

